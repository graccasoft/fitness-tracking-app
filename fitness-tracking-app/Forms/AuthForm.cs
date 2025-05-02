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
    public partial class AuthForm : Form {
        public AuthForm() {
            InitializeComponent();
        }

        private void lblRegister_Click(object sender, EventArgs e) {
            togglePanels();
        }

        private void lblLogin_Click(object sender, EventArgs e) {
            togglePanels();
        }

        private void togglePanels() {
            registerPanel.Visible = !registerPanel.Visible;
            loginPanel.Visible = !loginPanel.Visible;
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            var mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }


        
    }
}
