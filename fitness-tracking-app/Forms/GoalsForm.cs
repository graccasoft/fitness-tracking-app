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

namespace fitness_tracking_app.Forms {
    public partial class GoalsForm : Form {
        private readonly GoalService goalService;
        private UserGoal UserGoal;
        public GoalsForm() {
            InitializeComponent();
             goalService = new GoalService();
        }

        private void btnGoal_Click(object sender, EventArgs e) {
            if(txtGoal.Text == ""){
                Notifications.warn("Please enter a goal");  
                return;
            }
            if(!Validator.isNumeric(txtGoal.Text)){
                Notifications.warn("Goal must be a number");
                return;
            }
            decimal goal = Convert.ToDecimal(txtGoal.Text);
            if( goal < 0 ){
                Notifications.warn("Goal cannot be negative");
                return;
            }
            if( goal > 9999999 ){
                Notifications.warn("Goal exceeds reasonable limits");
                return;
            }
            SaveUserGoal(goal);
            Notifications.success("Goal saved successfully");
        }
         private FetchUserGoal(){
            var SavedGoal = repository.customQueryGet("WHERE userId = @userId", MainForm.userId);
            if( SavedGoal == null ){
                SavedGoal = new UserGoal();
                SavedGoal.UserId = MainForm.userId;
                SavedGoal.Goal = 0;
                repository.save(SavedGoal);
                this.UserGoal = SavedGoal;
            }else{
                this.UserGoal = SavedGoal;
            }
        }

        private SaveUserGoal(decimal goal){
            UserGoal.Goal = goal;
            repository.update(UserGoal);
        }
    }
}
