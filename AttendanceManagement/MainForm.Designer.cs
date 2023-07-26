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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnStartWork = new Button();
            lblCurrentTime = new Label();
            btnEndWork = new Button();
            label1 = new Label();
            menuMain = new MenuStrip();
            従業員設定ToolStripMenuItem = new ToolStripMenuItem();
            勤怠履歴ToolStripMenuItem = new ToolStripMenuItem();
            出力ToolStripMenuItem = new ToolStripMenuItem();
            tiUpdateClock = new System.Windows.Forms.Timer(components);
            lvemployees = new ListView();
            menuMain.SuspendLayout();
            SuspendLayout();
            // 
            // btnStartWork
            // 
            btnStartWork.Enabled = false;
            btnStartWork.Font = new Font("Yu Gothic UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            btnStartWork.ForeColor = Color.Green;
            btnStartWork.Location = new Point(287, 192);
            btnStartWork.Name = "btnStartWork";
            btnStartWork.Size = new Size(403, 101);
            btnStartWork.TabIndex = 1;
            btnStartWork.Text = "出勤";
            btnStartWork.UseVisualStyleBackColor = true;
            btnStartWork.Click += btnStartWork_Click;
            // 
            // lblCurrentTime
            // 
            lblCurrentTime.AutoSize = true;
            lblCurrentTime.Font = new Font("Yu Gothic UI", 72F, FontStyle.Bold, GraphicsUnit.Point);
            lblCurrentTime.ForeColor = SystemColors.Highlight;
            lblCurrentTime.Location = new Point(305, 61);
            lblCurrentTime.Name = "lblCurrentTime";
            lblCurrentTime.Size = new Size(402, 128);
            lblCurrentTime.TabIndex = 3;
            lblCurrentTime.Text = "17:30:03";
            // 
            // btnEndWork
            // 
            btnEndWork.Enabled = false;
            btnEndWork.Font = new Font("Yu Gothic UI", 48F, FontStyle.Bold, GraphicsUnit.Point);
            btnEndWork.ForeColor = Color.Red;
            btnEndWork.Location = new Point(287, 299);
            btnEndWork.Name = "btnEndWork";
            btnEndWork.Size = new Size(403, 101);
            btnEndWork.TabIndex = 2;
            btnEndWork.Text = "退勤";
            btnEndWork.UseVisualStyleBackColor = true;
            btnEndWork.Click += btnEndWork_Click;
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
            menuMain.Items.AddRange(new ToolStripItem[] { 従業員設定ToolStripMenuItem, 勤怠履歴ToolStripMenuItem, 出力ToolStripMenuItem });
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
            // tiUpdateClock
            // 
            tiUpdateClock.Enabled = true;
            tiUpdateClock.Interval = 1000;
            tiUpdateClock.Tick += tiUpdateClock_Tick;
            // 
            // lvemployees
            // 
            lvemployees.BorderStyle = BorderStyle.FixedSingle;
            lvemployees.FullRowSelect = true;
            lvemployees.GridLines = true;
            lvemployees.Location = new Point(12, 29);
            lvemployees.MultiSelect = false;
            lvemployees.Name = "lvemployees";
            lvemployees.Size = new Size(252, 371);
            lvemployees.TabIndex = 7;
            lvemployees.UseCompatibleStateImageBehavior = false;
            lvemployees.View = View.Details;
            lvemployees.SelectedIndexChanged += lvemployees_SelectedIndexChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(704, 412);
            Controls.Add(lvemployees);
            Controls.Add(label1);
            Controls.Add(lblCurrentTime);
            Controls.Add(btnEndWork);
            Controls.Add(btnStartWork);
            Controls.Add(menuMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuMain;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "まるそふと-勤怠管理-タイムカード";
            Load += MainForm_Load;
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnStartWork;
        private Label lblCurrentTime;
        private Button btnEndWork;
        private Label label1;
        private MenuStrip menuMain;
        private ToolStripMenuItem 従業員設定ToolStripMenuItem;
        private ToolStripMenuItem 勤怠履歴ToolStripMenuItem;
        private ToolStripMenuItem 出力ToolStripMenuItem;
        private System.Windows.Forms.Timer tiUpdateClock;
        private ListView lvemployees;
    }
}