using System.Text.RegularExpressions;

namespace fitness_tracking_app.Services {
    internal class Validator {

        public static Boolean isValidPassword(String password) {
            
            if (password.Trim().Length < 12) {
                return false;
            }

            Boolean hasNumbers = false;
            Boolean hasCaps = false;
            Boolean hasSmall = false;

            for (int x = 0; x < password.Length; x++) {
                if (password[x] >= 'a' && password[x] <= 'z') {
                    hasSmall = true;
                }
                if (password[x] >= 'A' && password[x] <= 'Z') {
                    hasCaps = true;
                }
                if (password[x] >= '0' && password[x] <= '9') {
                    hasNumbers = true;
                }
            }
            return hasNumbers && hasCaps && hasSmall;
        }

        public static Boolean isValidUsername(String username) {
            if (username.Trim().Length < 6) {
                return false;
            }
            //only letters and underscores

            return Regex.IsMatch(username, @"^[a-zA-Z_]+$");
        }

        public static bool ctlVerifyLength(Control ctl, int minLen, int maxLen, String error = "Error from ctlVerifyLength") {
            if ((ctl.Text.Trim().Length >= minLen && ctl.Text.Trim().Length <= maxLen))
                return true;
            MessageBox.Show(error);
            ctl.Focus();
            return false;
        }

        public static Boolean isNumeric(String input) {
            return input.All(char.IsDigit);
        }


    }
}
