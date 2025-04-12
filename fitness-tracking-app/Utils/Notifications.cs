using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitness_tracking_app.Services {
    internal class Notifications {
        public static void info(String message) {
            MessageBox.Show(message, "Fitness Tracking App", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void warn(String message) {
            MessageBox.Show(message, "Fitness Tracking App", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
