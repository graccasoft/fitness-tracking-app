using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fitness_tracking_app.Services;
using fitness_tracking_app.Models;
namespace fitness_tracking_app.Forms {
    public partial class GoalsForm : Form {
        private readonly GoalService goalService;
        private UserGoal userGoal;
        public GoalsForm() {
            InitializeComponent();
            goalService = new GoalService();
            
        }

        private void btnGoal_Click(object sender, EventArgs e) {
            if (txtGoal.Text == "") {
                Notifications.warn("Please enter a goal");
                return;
            }
            if (!Validator.isNumeric(txtGoal.Text)) {
                Notifications.warn("Goal must be a number");
                return;
            }
            decimal goal = Convert.ToDecimal(txtGoal.Text);
            if (goal < 0) {
                Notifications.warn("Goal cannot be negative");
                return;
            }
            if (goal > 9999999) {
                Notifications.warn("Goal exceeds reasonable limits");
                return;
            }
            userGoal.Goal = (double)goal;
            goalService.SaveUserGoal(userGoal);
            Notifications.info("Goal saved successfully");
        }

        private void GoalsForm_Load(object sender, EventArgs e) {
            userGoal = goalService.FetchUserGoal();
            this.txtGoal.Text = userGoal.Goal.ToString();
        }
    }
}
