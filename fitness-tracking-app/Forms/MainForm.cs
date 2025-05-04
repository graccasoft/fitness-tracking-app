using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fitness_tracking_app.Forms {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
            this.FormClosed += MainForm_FormClosed;
        }

        private void btnMyGoals_Click(object sender, EventArgs e) {
            GoalsForm goalsForm = new GoalsForm();
            goalsForm.MdiParent = this;
            goalsForm.StartPosition = FormStartPosition.Manual;
            goalsForm.Location = new Point(300, 50);
            goalsForm.Show();
        }

        private void btnActivityTracker_Click(object sender, EventArgs e) {
            ActivityForm activityForm = new ActivityForm();
            activityForm.MdiParent = this;
            activityForm.StartPosition = FormStartPosition.Manual;
            activityForm.Location = new Point(250, 50);
            activityForm.Show();
        }

        private void btnMyProgress_Click(object sender, EventArgs e) {
            ReportForm reportForm = new ReportForm();
            reportForm.MdiParent = this;
            reportForm.StartPosition = FormStartPosition.Manual;
            reportForm.Location = new Point(250, 50);
            reportForm.Show();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e) {
            Application.Exit();
        }

    }
}
