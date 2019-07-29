using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BaseApplication.Crosscutting.Security
{
    public class RutHelper
    {
        public static bool IsRutOk(int rutBody, string dv)
        {
            var rut = string.Format("{0}{1}", rutBody, dv);

            return RutHelper.IsRutOk(rut);
        }
        public static bool IsRutOk(string rut)
        {
            rut = rut.Replace(".", "").Replace("-", "");
            const string RutRegex = "[0-9]+K?";
            Regex RegExRut = new Regex(RutRegex, RegexOptions.Compiled |
            RegexOptions.IgnoreCase);
            int[] coefs = { 3, 2, 7, 6, 5, 4, 3, 2 };

            // In case that rut is padded with spaces
            rut = rut.Trim().ToUpperInvariant();

            if (!RegExRut.IsMatch(rut)) { return false; }

            if (rut.Length > 9) { return false; }

            // If shorter than 9 characters (8 + control char) ...
            while (rut.Length < 9) { rut = "0" + rut; }

            int total = 0;

            for (int index = 0; index < rut.Length - 1; index++)
            {
                char curr = rut.Substring(index, 1).ToCharArray()[0];
                total += coefs[index] * (curr - '0');
            }

            int rest = 11 - (total % 11);

            if (rest == 11) rest = 0;

            if ((rest == 10) && rut.EndsWith("K")) { return true; }

            if (rut.Substring(rut.Length - 1, 1).ToCharArray()[0] == ('0' + rest))
            {
                return true;
            }

            return false;
        }

        public static string GetDv(string rut)
        {
            int suma = 0;
            for (int x = rut.Length - 1; x >= 0; x--)
                suma += int.Parse(char.IsDigit(rut[x]) ? rut[x].ToString() : "0") * (((rut.Length - (x + 1)) % 6) + 2);
            int numericDigit = (11 - suma % 11);
            string digit = numericDigit == 11 ? "0" : numericDigit == 10 ? "K" : numericDigit.ToString();
            return digit;
        }
    }
}
