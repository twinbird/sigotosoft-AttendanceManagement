namespace AttendanceManagement
{
    partial class AddAttendanceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnRegist = new Button();
            dtpWorkStartDate = new DateTimePicker();
            lblWorkStartDate = new Label();
            dtpWorkEndDate = new DateTimePicker();
            lblWorkEndDate = new Label();
            epInput = new ErrorProvider(components);
            cbemployee = new ComboBox();
            lblemployee = new Label();
            ((System.ComponentModel.ISupportInitialize)epInput).BeginInit();
            SuspendLayout();
            // 
            // btnRegist
            // 
            btnRegist.Location = new Point(151, 106);
            btnRegist.Name = "btnRegist";
            btnRegist.Size = new Size(75, 23);
            btnRegist.TabIndex = 3;
            btnRegist.Text = "登録";
            btnRegist.UseVisualStyleBackColor = true;
            btnRegist.Click += btnRegist_Click;
            // 
            // dtpWorkStartDate
            // 
            dtpWorkStartDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpWorkStartDate.Format = DateTimePickerFormat.Custom;
            dtpWorkStartDate.Location = new Point(80, 39);
            dtpWorkStartDate.Name = "dtpWorkStartDate";
            dtpWorkStartDate.Size = new Size(146, 23);
            dtpWorkStartDate.TabIndex = 1;
            // 
            // lblWorkStartDate
            // 
            lblWorkStartDate.AutoSize = true;
            lblWorkStartDate.Location = new Point(12, 43);
            lblWorkStartDate.Name = "lblWorkStartDate";
            lblWorkStartDate.Size = new Size(55, 15);
            lblWorkStartDate.TabIndex = 2;
            lblWorkStartDate.Text = "出勤日時";
            // 
            // dtpWorkEndDate
            // 
            dtpWorkEndDate.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtpWorkEndDate.Format = DateTimePickerFormat.Custom;
            dtpWorkEndDate.Location = new Point(80, 68);
            dtpWorkEndDate.Name = "dtpWorkEndDate";
            dtpWorkEndDate.Size = new Size(146, 23);
            dtpWorkEndDate.TabIndex = 2;
            // 
            // lblWorkEndDate
            // 
            lblWorkEndDate.AutoSize = true;
            lblWorkEndDate.Location = new Point(12, 72);
            lblWorkEndDate.Name = "lblWorkEndDate";
            lblWorkEndDate.Size = new Size(55, 15);
            lblWorkEndDate.TabIndex = 2;
            lblWorkEndDate.Text = "退勤日時";
            // 
            // epInput
            // 
            epInput.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            epInput.ContainerControl = this;
            // 
            // cbemployee
            // 
            cbemployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cbemployee.FormattingEnabled = true;
            cbemployee.Location = new Point(80, 10);
            cbemployee.Name = "cbemployee";
            cbemployee.Size = new Size(146, 23);
            cbemployee.TabIndex = 0;
            // 
            // lblemployee
            // 
            lblemployee.AutoSize = true;
            lblemployee.Location = new Point(14, 15);
            lblemployee.Name = "lblemployee";
            lblemployee.Size = new Size(43, 15);
            lblemployee.TabIndex = 5;
            lblemployee.Text = "従業員";
            // 
            // AddAttendanceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(265, 141);
            Controls.Add(cbemployee);
            Controls.Add(lblemployee);
            Controls.Add(lblWorkEndDate);
            Controls.Add(lblWorkStartDate);
            Controls.Add(dtpWorkEndDate);
            Controls.Add(dtpWorkStartDate);
            Controls.Add(btnRegist);
            Name = "AddAttendanceForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "勤怠手動登録";
            Load += AddAttendanceForm_Load;
            ((System.ComponentModel.ISupportInitialize)epInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRegist;
        private DateTimePicker dtpWorkStartDate;
        private Label lblWorkStartDate;
        private DateTimePicker dtpWorkEndDate;
        private Label lblWorkEndDate;
        private ErrorProvider epInput;
        private ComboBox cbemployee;
        private Label lblemployee;
    }
}