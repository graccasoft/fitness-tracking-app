namespace fitness_tracking_app.Forms {
    partial class GoalsForm {
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
            label1 = new Label();
            txtGoal = new TextBox();
            btnGoal = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 28);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 0;
            label1.Text = "Calories to burn";
            // 
            // txtGoal
            // 
            txtGoal.Location = new Point(34, 46);
            txtGoal.Name = "txtGoal";
            txtGoal.Size = new Size(224, 23);
            txtGoal.TabIndex = 1;
            // 
            // btnGoal
            // 
            btnGoal.Location = new Point(34, 86);
            btnGoal.Name = "btnGoal";
            btnGoal.Size = new Size(224, 36);
            btnGoal.TabIndex = 2;
            btnGoal.Text = "Save your goal";
            btnGoal.UseVisualStyleBackColor = true;
            btnGoal.Click += btnGoal_Click;
            // 
            // GoalsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(294, 171);
            Controls.Add(btnGoal);
            Controls.Add(txtGoal);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "GoalsForm";
            Text = "Set Goal";
            Load += GoalsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtGoal;
        private Button btnGoal;
    }
}