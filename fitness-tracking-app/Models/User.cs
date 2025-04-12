using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fitness_tracking_app.Models {
    internal class User : BaseEntity {

        public override String GetTableName() {
            return "users";
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public Gender gender { get; set; }
        public DateTime DateOfBirth { get; set; }


    }
}
