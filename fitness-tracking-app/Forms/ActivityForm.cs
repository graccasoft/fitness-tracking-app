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

namespace fitness_tracking_app.Forms
{
    public partial class ActivityForm : Form
    {

        private readonly ActivityService activityService;
        private List<ActivityMetric> activityMetrics;

        public ActivityForm()
        {

            InitializeComponent();
            activityService = new ActivityService();
            this.activityMetrics = activityService.GetActivityMetricList();
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

            var activities = activityService.GetUserActivityViewByUserId(MainForm.userId); 

            foreach (var activity in activities)
            {
                var listItem = new ListViewItem(activity.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"));
                listItem.SubItems.Add(activity.Activity.ToString());
                listItem.SubItems.Add(activity.ActivityMetric.ToString());
                listItem.SubItems.Add(activity.Value.ToString());
                listItem.SubItems.Add(activity.Calories.ToString("F2"));

                lvActivities.Items.Add(listItem);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ActivityForm_Load(object sender, EventArgs e)
        {
            cmbActivities.DisplayMember = "Activity";
            cmbActivities.DataSource = activityMetrics;

        }
        private void cmbActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedActivity = cmbActivities.SelectedItem as ActivityMetric;

            if (selectedActivity != null)
            {
                lblMetric1.Text = selectedActivity.Metric1;
                lblMetric2.Text = selectedActivity.Metric2;
                lblMetric3.Text = selectedActivity.Metric3;
            }
        }

        private void btnSaveActivity_Click(object sender, EventArgs e)
        {
            if (txtMetric1.Text.Length == 0 || txtMetric2.Text.Length == 0 || txtMetric3.Text.Length == 0)
            {
                Notifications.warn("Enter all metrics, use 0 if not achieved");
                return;
            }
            if (!Validator.isNumeric(txtMetric1.Text) || !Validator.isNumeric(txtMetric2.Text) || !Validator.isNumeric(txtMetric3.Text))
            {
                Notifications.warn("Metrics must be numbers");
                return;
            }
            if (Convert.ToDecimal(txtMetric1.Text) < 0 || Convert.ToDecimal(txtMetric2.Text) < 0 || Convert.ToDecimal(txtMetric3.Text) < 0)
            {
                Notifications.warn("Metrics cannot be negative");
                return;
            }
            if (Convert.ToDecimal(txtMetric1.Text) > 9999999 || Convert.ToDecimal(txtMetric2.Text) > 9999999 || Convert.ToDecimal(txtMetric3.Text) > 9999999)
            {
                Notifications.warn("Metrics exceed reasonable limits");
                return;
            }

            var selectedActivity = cmbActivities.SelectedItem as ActivityMetric;
            //save UserActivity record
            var userActivity = new UserActivity();
            userActivity.UserId = MainForm.userId;
            userActivity.MetricId = selectedActivity.Id;

            if (Convert.ToDouble(txtMetric1.Text) > 0)
            {
                userActivity.Metric = "metric1";
                userActivity.Value = Convert.ToDouble(txtMetric1.Text);
                activityService.save(userActivity);
                Notifications.info("Activity saved successfully");
            }

            if (Convert.ToDouble(txtMetric2.Text) > 0)
            {
                userActivity.Metric = "metric2";
                userActivity.Value = Convert.ToDouble(txtMetric2.Text);
                activityService.save(userActivity);
                Notifications.info("Activity saved successfully");
            }
            if (Convert.ToDouble(txtMetric1.Text) > 0)
            {
                userActivity.Metric = "metric3";
                userActivity.Value = Convert.ToDouble(txtMetric3.Text);
                activityService.save(userActivity);
                Notifications.info("Activity saved successfully");
            }

            this.PopulateActivitiesListView();

        }
    }
}
