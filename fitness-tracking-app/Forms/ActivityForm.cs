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
    }
}
