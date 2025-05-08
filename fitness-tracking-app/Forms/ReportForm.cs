using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fitness_tracking_app.Models;
using fitness_tracking_app.Services;

namespace fitness_tracking_app.Forms {
    public partial class ReportForm : Form {
        private readonly ActivityService activityService;
        private readonly GoalService goalService;
        double totalCaloriesBurned = 0;
        double targetCalories = 0;
        private UserGoal userGoal;
        public ReportForm() {
            InitializeComponent();
            activityService = new ActivityService();
            goalService = new GoalService();
            
        }

        private void ReportForm_Load(object sender, EventArgs e) {
            
            userGoal = goalService.FetchUserGoal();
            this.ConfigureListView();
            this.PopulateActivitiesListView();
        }

        private void ConfigureListView()
        {
            lvActivities.View = View.Details;
            lvActivities.FullRowSelect = true;
            lvActivities.GridLines = true;
            lvActivities.BorderStyle = BorderStyle.FixedSingle;
            lvActivities.Columns.Add("Date", 150);
            lvActivities.Columns.Add("Activity", 150);
            lvActivities.Columns.Add("Activity Metric", 150);
            lvActivities.Columns.Add("Value", 50);
            lvActivities.Columns.Add("Calories", 100);
        }

        private void PopulateActivitiesListView()
        {
            lvActivities.Items.Clear();
            totalCaloriesBurned = 0;
            var activities = activityService.GetUserActivityViewByUserId(MainForm.userId); 

            foreach (var activity in activities)
            {
                var listItem = new ListViewItem(activity.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"));
                listItem.SubItems.Add(activity.Activity.ToString());
                listItem.SubItems.Add(activity.ActivityMetric.ToString());
                listItem.SubItems.Add(activity.Value.ToString());
                listItem.SubItems.Add(activity.Calories.ToString("F2"));

                lvActivities.Items.Add(listItem);
                totalCaloriesBurned += activity.Calories;
            }

            lblCaloriesBurned.Text = $"Total Calories Burned: {totalCaloriesBurned}";
            if (userGoal != null)
            {
                targetCalories = userGoal.Goal;
                lblTargetStatus.Text = $"Target Status: {totalCaloriesBurned}/{targetCalories}";

                if (totalCaloriesBurned >= targetCalories)
                {
                    lblTargetStatus.ForeColor = Color.Green;
                    lblTargetStatus.Text += " - Target Achieved!";
                }
                else
                {
                    lblTargetStatus.ForeColor = Color.Red;
                    lblTargetStatus.Text += " - Target Not Achieved!";
                }
            }
            else
            {
                lblTargetStatus.Text = "No target set.";
            }
        }
    }
}
