using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BaseApplication.Crosscutting.Security.Auth.Models
{
    public static class IdentityHelper
    {
        //// Used for XSRF when linking external logins
        //public const string XsrfKey = "XsrfId";

        public static void SignIn(ApplicationUserManager manager, ApplicationUser user, bool isPersistent)
        {
            IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        //public const string ProviderNameKey = "providerName";
        //public static string GetProviderNameFromRequest(HttpRequest request)
        //{
        //    return request.QueryString[ProviderNameKey];
        //}

        //public const string CodeKey = "code";
        //public static string GetCodeFromRequest(HttpRequest request)
        //{
        //    return request.QueryString[CodeKey];
        //}

        //public const string UserIdKey = "userId";
        //public static string GetUserIdFromRequest(HttpRequest request)
        //{
        //    return HttpUtility.UrlDecode(request.QueryString[UserIdKey]);
        //}

        //public static string GetResetPasswordRedirectUrl(string code)
        //{
        //    return "/Account/ResetPassword?" + CodeKey + "=" + HttpUtility.UrlEncode(code);
        //}

        //public static string GetUserConfirmationRedirectUrl(string code, string userId)
        //{
        //    return "/Account/Confirm?" + CodeKey + "=" + HttpUtility.UrlEncode(code) + "&" + UserIdKey + "=" + HttpUtility.UrlEncode(userId);
        //}

        private static bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }

        public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
        {
            if (!String.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
            {
                response.Redirect(returnUrl);
            }
            else
            {
                response.Redirect("~/");
            }
        }
    }
}
