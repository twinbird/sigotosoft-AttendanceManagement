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
            lbEmployers = new ListBox();
            btnStartWork = new Button();
            lblCurrentTime = new Label();
            btnEndWork = new Button();
            label1 = new Label();
            menuMain = new MenuStrip();
            従業員設定ToolStripMenuItem = new ToolStripMenuItem();
            勤怠履歴ToolStripMenuItem = new ToolStripMenuItem();
            出力ToolStripMenuItem = new ToolStripMenuItem();
            設定ToolStripMenuItem = new ToolStripMenuItem();
            menuMain.SuspendLayout();
            SuspendLayout();
            // 
            // lbEmployers
            // 
            lbEmployers.FormattingEnabled = true;
            lbEmployers.ItemHeight = 15;
            lbEmployers.Location = new Point(24, 51);
            lbEmployers.Name = "lbEmployers";
            lbEmployers.Size = new Size(240, 349);
            lbEmployers.TabIndex = 0;
            // 
            // btnStartWork
            // 
            btnStartWork.Font = new Font("Yu Gothic UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            btnStartWork.ForeColor = Color.Green;
            btnStartWork.Location = new Point(287, 192);
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
            lblCurrentTime.Location = new Point(375, 61);
            lblCurrentTime.Name = "lblCurrentTime";
            lblCurrentTime.Size = new Size(234, 128);
            lblCurrentTime.TabIndex = 3;
            lblCurrentTime.Text = "7:30";
            // 
            // btnEndWork
            // 
            btnEndWork.Font = new Font("Yu Gothic UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            btnEndWork.ForeColor = Color.Red;
            btnEndWork.Location = new Point(287, 299);
            btnEndWork.Name = "btnEndWork";
            btnEndWork.Size = new Size(403, 101);
            btnEndWork.TabIndex = 2;
            btnEndWork.Text = "終業";
            btnEndWork.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 24F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(270, 29);
            label1.Name = "label1";
            label1.Size = new Size(148, 45);
            label1.TabIndex = 3;
            label1.Text = "現在時刻";
            // 
            // menuMain
            // 
            menuMain.Items.AddRange(new ToolStripItem[] { 従業員設定ToolStripMenuItem, 勤怠履歴ToolStripMenuItem, 出力ToolStripMenuItem, 設定ToolStripMenuItem });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Size = new Size(704, 24);
            menuMain.TabIndex = 6;
            menuMain.Text = "メニュー";
            // 
            // 従業員設定ToolStripMenuItem
            // 
            従業員設定ToolStripMenuItem.Name = "従業員設定ToolStripMenuItem";
            従業員設定ToolStripMenuItem.Size = new Size(109, 20);
            従業員設定ToolStripMenuItem.Text = "従業員登録・編集";
            従業員設定ToolStripMenuItem.Click += 従業員設定ToolStripMenuItem_Click;
            // 
            // 勤怠履歴ToolStripMenuItem
            // 
            勤怠履歴ToolStripMenuItem.Name = "勤怠履歴ToolStripMenuItem";
            勤怠履歴ToolStripMenuItem.Size = new Size(67, 20);
            勤怠履歴ToolStripMenuItem.Text = "勤怠履歴";
            勤怠履歴ToolStripMenuItem.Click += 勤怠履歴ToolStripMenuItem_Click;
            // 
            // 出力ToolStripMenuItem
            // 
            出力ToolStripMenuItem.Name = "出力ToolStripMenuItem";
            出力ToolStripMenuItem.Size = new Size(67, 20);
            出力ToolStripMenuItem.Text = "勤怠出力";
            出力ToolStripMenuItem.Click += 出力ToolStripMenuItem_Click;
            // 
            // 設定ToolStripMenuItem
            // 
            設定ToolStripMenuItem.Name = "設定ToolStripMenuItem";
            設定ToolStripMenuItem.Size = new Size(43, 20);
            設定ToolStripMenuItem.Text = "設定";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(704, 412);
            Controls.Add(label1);
            Controls.Add(lblCurrentTime);
            Controls.Add(btnEndWork);
            Controls.Add(btnStartWork);
            Controls.Add(lbEmployers);
            Controls.Add(menuMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuMain;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "まるそふと-勤怠管理-タイムカード";
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox lbEmployers;
        private Button btnStartWork;
        private Label lblCurrentTime;
        private Button btnEndWork;
        private Label label1;
        private MenuStrip menuMain;
        private ToolStripMenuItem 設定ToolStripMenuItem;
        private ToolStripMenuItem 従業員設定ToolStripMenuItem;
        private ToolStripMenuItem 勤怠履歴ToolStripMenuItem;
        private ToolStripMenuItem 出力ToolStripMenuItem;
    }
}