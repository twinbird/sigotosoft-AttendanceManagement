namespace AttendanceManagement
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnOpenEmployerManage = new Button();
            lbEmployers = new ListBox();
            btnStartWork = new Button();
            lblCurrentTime = new Label();
            btnEndWork = new Button();
            btnOpenExcelOutput = new Button();
            label1 = new Label();
            btnOpenHistory = new Button();
            SuspendLayout();
            // 
            // btnOpenEmployerManage
            // 
            btnOpenEmployerManage.Location = new Point(24, 400);
            btnOpenEmployerManage.Name = "btnOpenEmployerManage";
            btnOpenEmployerManage.Size = new Size(120, 23);
            btnOpenEmployerManage.TabIndex = 3;
            btnOpenEmployerManage.Text = "従業員の登録・編集";
            btnOpenEmployerManage.UseVisualStyleBackColor = true;
            btnOpenEmployerManage.Click += btnOpenEmployerManage_Click;
            // 
            // lbEmployers
            // 
            lbEmployers.FormattingEnabled = true;
            lbEmployers.ItemHeight = 15;
            lbEmployers.Location = new Point(24, 12);
            lbEmployers.Name = "lbEmployers";
            lbEmployers.Size = new Size(240, 379);
            lbEmployers.TabIndex = 0;
            // 
            // btnStartWork
            // 
            btnStartWork.Font = new Font("Yu Gothic UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            btnStartWork.ForeColor = Color.Green;
            btnStartWork.Location = new Point(287, 183);
            btnStartWork.Name = "btnStartWork";
            btnStartWork.Size = new Size(403, 101);
            btnStartWork.TabIndex = 1;
            btnStartWork.Text = "始業";
            btnStartWork.UseVisualStyleBackColor = true;
            // 
            // lblCurrentTime
            // 
            lblCurrentTime.AutoSize = true;
            lblCurrentTime.Font = new Font("Yu Gothic UI", 72F, FontStyle.Bold, GraphicsUnit.Point);
            lblCurrentTime.ForeColor = SystemColors.Highlight;
            lblCurrentTime.Location = new Point(375, 41);
            lblCurrentTime.Name = "lblCurrentTime";
            lblCurrentTime.Size = new Size(234, 128);
            lblCurrentTime.TabIndex = 3;
            lblCurrentTime.Text = "7:30";
            // 
            // btnEndWork
            // 
            btnEndWork.Font = new Font("Yu Gothic UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            btnEndWork.ForeColor = Color.Red;
            btnEndWork.Location = new Point(287, 290);
            btnEndWork.Name = "btnEndWork";
            btnEndWork.Size = new Size(403, 101);
            btnEndWork.TabIndex = 2;
            btnEndWork.Text = "終業";
            btnEndWork.UseVisualStyleBackColor = true;
            // 
            // btnOpenExcelOutput
            // 
            btnOpenExcelOutput.Location = new Point(581, 400);
            btnOpenExcelOutput.Name = "btnOpenExcelOutput";
            btnOpenExcelOutput.Size = new Size(109, 23);
            btnOpenExcelOutput.TabIndex = 5;
            btnOpenExcelOutput.Text = "勤怠の出力";
            btnOpenExcelOutput.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(270, 9);
            label1.Name = "label1";
            label1.Size = new Size(148, 45);
            label1.TabIndex = 3;
            label1.Text = "現在時刻";
            // 
            // btnOpenHistory
            // 
            btnOpenHistory.Location = new Point(163, 400);
            btnOpenHistory.Name = "btnOpenHistory";
            btnOpenHistory.Size = new Size(101, 23);
            btnOpenHistory.TabIndex = 4;
            btnOpenHistory.Text = "勤怠履歴を確認";
            btnOpenHistory.UseVisualStyleBackColor = true;
            btnOpenHistory.Click += btnOpenHistory_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(704, 435);
            Controls.Add(btnOpenHistory);
            Controls.Add(btnOpenExcelOutput);
            Controls.Add(label1);
            Controls.Add(lblCurrentTime);
            Controls.Add(btnEndWork);
            Controls.Add(btnStartWork);
            Controls.Add(lbEmployers);
            Controls.Add(btnOpenEmployerManage);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "まるそふと-勤怠管理-タイムカード";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOpenEmployerManage;
        private ListBox lbEmployers;
        private Button btnStartWork;
        private Label lblCurrentTime;
        private Button btnEndWork;
        private Button btnOpenExcelOutput;
        private Label label1;
        private Button btnOpenHistory;
    }
}