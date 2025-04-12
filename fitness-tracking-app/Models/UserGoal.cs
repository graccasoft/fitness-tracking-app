using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitness_tracking_app.Models {
    internal class UserGoal : BaseEntity {

        public override string GetTableName() {
            return "user_goal";
        }
        public int UserId { get; set; }
        public double goal { get; set; }

    }
}
