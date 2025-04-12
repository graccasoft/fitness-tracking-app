using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitness_tracking_app.Models {
    internal class UserActivity : BaseEntity {
        public override string GetTableName() {
            return "user_activity";
        }
        public int UserId { get; set; }
        public int MetricId { get; set; }
        public double Value { get; set; }
        public string Metric { get; set; }

    }
}
