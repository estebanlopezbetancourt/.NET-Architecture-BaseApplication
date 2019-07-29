using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BaseApplication.Crosscutting.Security.Auth.Models
{
    // These help with sign and two factor (will possibly be moved into identity framework itself)
    public class SignInHelper
    {
        public SignInHelper(ApplicationUserManager userManager, IAuthenticationManager authManager)
        {
            UserManager = userManager;
            AuthenticationManager = authManager;
        }

        public ApplicationUserManager UserManager { get; private set; }
        public IAuthenticationManager AuthenticationManager { get; private set; }

        public void SignInAsync(ApplicationUser user, bool isPersistent, bool rememberBrowser)
        {
            // Clear any partial cookies from external or two factor partial sign ins
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie, DefaultAuthenticationTypes.TwoFactorCookie);
            var userIdentity = user.GenerateUserIdentity(UserManager);
            if (rememberBrowser)
            {
                var rememberBrowserIdentity = AuthenticationManager.CreateTwoFactorRememberBrowserIdentity(user.Id);
                AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, userIdentity, rememberBrowserIdentity);
            }
            else
            {
                AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = isPersistent }, userIdentity);
            }
        }

        public bool SendTwoFactorCode(string provider)
        {
            var userId = GetVerifiedUserId();
            if (userId == null)
            {
                return false;
            }

            var token = UserManager.GenerateTwoFactorToken(userId, provider);
            // See IdentityConfig.cs to plug in Email/SMS services to actually send the code
            UserManager.NotifyTwoFactorToken(userId, provider, token);
            return true;
        }

        public string GetVerifiedUserId()
        {
            var result = Task.Run(async () => { return await AuthenticationManager.AuthenticateAsync(DefaultAuthenticationTypes.TwoFactorCookie); }).Result;
            if (result != null && result.Identity != null && !String.IsNullOrEmpty(result.Identity.GetUserId()))
            {
                return result.Identity.GetUserId();
            }
            return null;
        }

        public bool HasBeenVerified()
        {
            return GetVerifiedUserId() != null;
        }

        public SignInStatus TwoFactorSignIn(string provider, string code, bool isPersistent, bool rememberBrowser)
        {
            var userId = GetVerifiedUserId();
            if (userId == null)
            {
                return SignInStatus.Failure;
            }
            var user = UserManager.FindById(userId);
            if (user == null)
            {
                return SignInStatus.Failure;
            }
            if (UserManager.IsLockedOut(user.Id))
            {
                return SignInStatus.LockedOut;
            }
            if (UserManager.VerifyTwoFactorToken(user.Id, provider, code))
            {
                // When token is verified correctly, clear the access failed count used for lockout
                UserManager.ResetAccessFailedCount(user.Id);
                SignInAsync(user, isPersistent, rememberBrowser);
                return SignInStatus.Success;
            }
            // If the token is incorrect, record the failure which also may cause the user to be locked out
            UserManager.AccessFailed(user.Id);
            return SignInStatus.Failure;
        }

        public SignInStatus ExternalSignIn(ExternalLoginInfo loginInfo, bool isPersistent)
        {
            var user = UserManager.Find(loginInfo.Login);
            if (user == null)
            {
                return SignInStatus.Failure;
            }
            if (UserManager.IsLockedOut(user.Id))
            {
                return SignInStatus.LockedOut;
            }
            return SignInOrTwoFactor(user, isPersistent);
        }

        private SignInStatus SignInOrTwoFactor(ApplicationUser user, bool isPersistent)
        {
            if (UserManager.GetTwoFactorEnabled(user.Id) &&
                !Task.Run(async () => { return await AuthenticationManager.TwoFactorBrowserRememberedAsync(user.Id); }).Result)
            {
                var identity = new ClaimsIdentity(DefaultAuthenticationTypes.TwoFactorCookie);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
                AuthenticationManager.SignIn(identity);
                return SignInStatus.RequiresTwoFactorAuthentication;
            }
            SignInAsync(user, isPersistent, false);
            return SignInStatus.Success;

        }

        public SignInStatus PasswordSignIn(string userName, string password, bool isPersistent, bool shouldLockout)
        {
            var user = UserManager.FindByName(userName);
            if (user == null)
            {
                return SignInStatus.Failure;
            }
            if (UserManager.IsLockedOut(user.Id))
            {
                return SignInStatus.LockedOut;
            }
            if (UserManager.CheckPassword(user, password))
            {
                return SignInOrTwoFactor(user, isPersistent);
            }
            if (shouldLockout)
            {
                // If lockout is requested, increment access failed count which might lock out the user
                UserManager.AccessFailed(user.Id);
                if (UserManager.IsLockedOut(user.Id))
                {
                    return SignInStatus.LockedOut;
                }
            }
            return SignInStatus.Failure;
        }
    }

    public enum SignInStatus
    {
        Success,
        LockedOut,
        RequiresTwoFactorAuthentication,
        Failure
    }
}
