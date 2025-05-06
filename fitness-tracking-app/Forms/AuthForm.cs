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
    public partial class AuthForm : Form {
        private readonly AuthService authService;
        public AuthForm() {
            InitializeComponent();
            authService = new AuthService();
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
            User user = authService.authenticate(new User() {
                Username = txtLoginUsername.Text,
                Password = txtLoginPassword.Text
            });
            if (user == null) {
                Notifications.warn("Invalid username or password");
                return;
            }
            var mainForm = new MainForm();
            MainForm.userId = user.Id;
            mainForm.Show();
            this.Hide();
        }

        private void btnRegister_Click(object sender, EventArgs e) {


            var user = new User();
            user.FirstName = txtFirstName.Text;
            user.LastName = txtLastName.Text;
            user.Username = txtUsername.Text;
            user.Password = txtPassword.Text;
            var savedUser = authService.register(user);

            if (savedUser != null) {
                Notifications.info("User registered successfully");
                togglePanels();
            }
        }
    }
}
