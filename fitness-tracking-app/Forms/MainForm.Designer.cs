namespace fitness_tracking_app.Forms {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel1 = new Panel();
            btnMyProgress = new Button();
            btnActivityTracker = new Button();
            label1 = new Label();
            btnMyGoals = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnMyProgress);
            panel1.Controls.Add(btnActivityTracker);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnMyGoals);
            panel1.Location = new Point(0, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(241, 596);
            panel1.TabIndex = 1;
            // 
            // btnMyProgress
            // 
            btnMyProgress.Cursor = Cursors.Hand;
            btnMyProgress.FlatStyle = FlatStyle.Flat;
            btnMyProgress.Location = new Point(3, 189);
            btnMyProgress.Name = "btnMyProgress";
            btnMyProgress.Size = new Size(235, 41);
            btnMyProgress.TabIndex = 3;
            btnMyProgress.Text = "My Progress";
            btnMyProgress.UseVisualStyleBackColor = true;
            btnMyProgress.Click += btnMyProgress_Click;
            // 
            // btnActivityTracker
            // 
            btnActivityTracker.Cursor = Cursors.Hand;
            btnActivityTracker.FlatStyle = FlatStyle.Flat;
            btnActivityTracker.Location = new Point(3, 142);
            btnActivityTracker.Name = "btnActivityTracker";
            btnActivityTracker.Size = new Size(235, 41);
            btnActivityTracker.TabIndex = 2;
            btnActivityTracker.Text = "Activity Tracker";
            btnActivityTracker.UseVisualStyleBackColor = true;
            btnActivityTracker.Click += btnActivityTracker_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(21, 22);
            label1.Name = "label1";
            label1.Size = new Size(196, 25);
            label1.TabIndex = 1;
            label1.Text = "Fitness Tracking App";
            // 
            // btnMyGoals
            // 
            btnMyGoals.Cursor = Cursors.Hand;
            btnMyGoals.FlatStyle = FlatStyle.Flat;
            btnMyGoals.Location = new Point(3, 95);
            btnMyGoals.Name = "btnMyGoals";
            btnMyGoals.Size = new Size(235, 41);
            btnMyGoals.TabIndex = 0;
            btnMyGoals.Text = "My Goals";
            btnMyGoals.UseVisualStyleBackColor = true;
            btnMyGoals.Click += btnMyGoals_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(937, 600);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            IsMdiContainer = true;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fitness Tracking App";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button btnMyGoals;
        private Button btnMyProgress;
        private Button btnActivityTracker;
    }
}