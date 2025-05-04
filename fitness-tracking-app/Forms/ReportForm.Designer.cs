namespace fitness_tracking_app.Forms {
    partial class ReportForm {
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
            lvActivities = new ListView();
            lblCarloriesBurned = new Label();
            lblTargetStatus = new Label();
            SuspendLayout();
            // 
            // lvActivities
            // 
            lvActivities.Location = new Point(12, 99);
            lvActivities.Name = "lvActivities";
            lvActivities.Size = new Size(579, 192);
            lvActivities.TabIndex = 1;
            lvActivities.UseCompatibleStateImageBehavior = false;
            // 
            // lblCarloriesBurned
            // 
            lblCarloriesBurned.AutoSize = true;
            lblCarloriesBurned.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCarloriesBurned.Location = new Point(12, 30);
            lblCarloriesBurned.Name = "lblCarloriesBurned";
            lblCarloriesBurned.Size = new Size(172, 21);
            lblCarloriesBurned.TabIndex = 2;
            lblCarloriesBurned.Text = "Total Calories burned";
            // 
            // lblTargetStatus
            // 
            lblTargetStatus.AutoSize = true;
            lblTargetStatus.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTargetStatus.Location = new Point(12, 60);
            lblTargetStatus.Name = "lblTargetStatus";
            lblTargetStatus.Size = new Size(162, 17);
            lblTargetStatus.TabIndex = 3;
            lblTargetStatus.Text = "Your have reached target";
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(607, 306);
            Controls.Add(lblTargetStatus);
            Controls.Add(lblCarloriesBurned);
            Controls.Add(lvActivities);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ReportForm";
            Text = "Your Progress";
            Load += ReportForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lvActivities;
        private Label lblCarloriesBurned;
        private Label lblTargetStatus;
    }
}