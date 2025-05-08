using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitness_tracking_app.Models {
    internal class UserActivityView {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public int Activity { get; set; }
        public int ActivityMetric { get; set; }
        public double Value { get; set; }
        public double Calories { get; set; }

    }
}
