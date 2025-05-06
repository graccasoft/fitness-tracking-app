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
    public partial class ActivityForm : Form {

        private readonly ActivityService activityService;
        private List<ActivityMetric> activityMetrics;

        public ActivityForm() {

            InitializeComponent();
            activityService = new ActivityService();
            this.activityMetrics = activityService.GetActivityMetricList();
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void ActivityForm_Load(object sender, EventArgs e) {
            //load activities in combobox
            foreach (var activity in activityMetrics) {
                cmbActivities.Items.Add(activity.Activity);
            }

        }

        private void saveActivity(){
            //validate inputs: must be numeric, greater than 0, less than 9999999 : txtMetric1, txtMetric2, txtMetric3
            if (!Validator.isNumeric(txtMetric1.Text) || !Validator.isNumeric(txtMetric2.Text) || !Validator.isNumeric(txtMetric3.Text)) {
                Notifications.warn("Metrics must be numbers");
                return;
            }
            if (Convert.ToDecimal(txtMetric1.Text) < 0 || Convert.ToDecimal(txtMetric2.Text) < 0 || Convert.ToDecimal(txtMetric3.Text) < 0) {
                Notifications.warn("Metrics cannot be negative");
                return;
            }
            if (Convert.ToDecimal(txtMetric1.Text) > 9999999 || Convert.ToDecimal(txtMetric2.Text) > 9999999 || Convert.ToDecimal(txtMetric3.Text) > 9999999) {
                Notifications.warn("Metrics exceed reasonable limits");
                return;
            }
        }


    }
}
