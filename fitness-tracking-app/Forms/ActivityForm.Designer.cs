namespace fitness_tracking_app.Forms {
    partial class ActivityForm {
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
            groupBox1 = new GroupBox();
            txtMetric3 = new TextBox();
            txtMetric2 = new TextBox();
            txtMetric1 = new TextBox();
            lblMetric3 = new Label();
            lblMetric2 = new Label();
            lblMetric1 = new Label();
            cmbActivities = new ComboBox();
            label1 = new Label();
            btnSaveActivity = new Button();
            btnCancel = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // lvActivities
            // 
            lvActivities.Location = new Point(12, 12);
            lvActivities.Name = "lvActivities";
            lvActivities.Size = new Size(579, 192);
            lvActivities.TabIndex = 0;
            lvActivities.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtMetric3);
            groupBox1.Controls.Add(txtMetric2);
            groupBox1.Controls.Add(txtMetric1);
            groupBox1.Controls.Add(lblMetric3);
            groupBox1.Controls.Add(lblMetric2);
            groupBox1.Controls.Add(lblMetric1);
            groupBox1.Controls.Add(cmbActivities);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 223);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(579, 144);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Record Activity";
            // 
            // txtMetric3
            // 
            txtMetric3.Location = new Point(293, 103);
            txtMetric3.Name = "txtMetric3";
            txtMetric3.Size = new Size(100, 23);
            txtMetric3.TabIndex = 7;
            // 
            // txtMetric2
            // 
            txtMetric2.Location = new Point(150, 103);
            txtMetric2.Name = "txtMetric2";
            txtMetric2.Size = new Size(110, 23);
            txtMetric2.TabIndex = 6;
            // 
            // txtMetric1
            // 
            txtMetric1.Location = new Point(13, 103);
            txtMetric1.Name = "txtMetric1";
            txtMetric1.Size = new Size(110, 23);
            txtMetric1.TabIndex = 5;
            // 
            // lblMetric3
            // 
            lblMetric3.AutoSize = true;
            lblMetric3.Location = new Point(293, 85);
            lblMetric3.Name = "lblMetric3";
            lblMetric3.Size = new Size(50, 15);
            lblMetric3.TabIndex = 4;
            lblMetric3.Text = "Metric 3";
            // 
            // lblMetric2
            // 
            lblMetric2.AutoSize = true;
            lblMetric2.Location = new Point(150, 85);
            lblMetric2.Name = "lblMetric2";
            lblMetric2.Size = new Size(50, 15);
            lblMetric2.TabIndex = 3;
            lblMetric2.Text = "Metric 2";
            // 
            // lblMetric1
            // 
            lblMetric1.AutoSize = true;
            lblMetric1.Location = new Point(13, 85);
            lblMetric1.Name = "lblMetric1";
            lblMetric1.Size = new Size(50, 15);
            lblMetric1.TabIndex = 2;
            lblMetric1.Text = "Metric 1";
            // 
            // cmbActivities
            // 
            cmbActivities.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbActivities.FormattingEnabled = true;
            cmbActivities.Location = new Point(13, 44);
            cmbActivities.Name = "cmbActivities";
            cmbActivities.Size = new Size(380, 23);
            cmbActivities.TabIndex = 1;
            cmbActivities.SelectedIndexChanged += cmbActivities_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 26);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Activity";
            label1.Click += label1_Click;
            // 
            // btnSaveActivity
            // 
            btnSaveActivity.Location = new Point(12, 373);
            btnSaveActivity.Name = "btnSaveActivity";
            btnSaveActivity.Size = new Size(132, 35);
            btnSaveActivity.TabIndex = 8;
            btnSaveActivity.Text = "Save Activity";
            btnSaveActivity.UseVisualStyleBackColor = true;
            btnSaveActivity.Click += btnSaveActivity_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(162, 373);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(132, 35);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // ActivityForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(604, 427);
            Controls.Add(btnCancel);
            Controls.Add(btnSaveActivity);
            Controls.Add(groupBox1);
            Controls.Add(lvActivities);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "ActivityForm";
            Text = "Your Activities";
            Load += ActivityForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListView lvActivities;
        private GroupBox groupBox1;
        private Label label1;
        private TextBox txtMetric3;
        private TextBox txtMetric2;
        private TextBox txtMetric1;
        private Label lblMetric3;
        private Label lblMetric2;
        private Label lblMetric1;
        private ComboBox cmbActivities;
        private Button btnSaveActivity;
        private Button btnCancel;
    }
}