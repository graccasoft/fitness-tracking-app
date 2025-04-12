using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitness_tracking_app.Models {
    internal class ActivityMetric: BaseEntity {
        public override string GetTableName() {
            return "activity_metrics";
        }

        public string Activity { get; set; }
        public string Metric1 { get; set; }
        public string Metric1Formulae { get; set; }
        public string Metric2 { get; set; }
        public string Metric2Formulae { get; set; }
        public string Metric3 { get; set; }
        public string Metric3Formulae { get; set; }

    }
}
