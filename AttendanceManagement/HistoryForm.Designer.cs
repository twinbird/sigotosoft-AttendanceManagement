namespace AttendanceManagement
{
    partial class HistoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryForm));
            cbemployee = new ComboBox();
            lblemployee = new Label();
            dtpWorkStart = new DateTimePicker();
            dtpWorkEnd = new DateTimePicker();
            lblRange = new Label();
            gbSearchQuery = new GroupBox();
            btnSearch = new Button();
            lblRangeMark = new Label();
            dgvHistory = new DataGridView();
            colWorkStart = new DataGridViewTextBoxColumn();
            colWorkEnd = new DataGridViewTextBoxColumn();
            colEdit = new DataGridViewButtonColumn();
            gbSearchQuery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            SuspendLayout();
            // 
            // cbemployee
            // 
            cbemployee.FormattingEnabled = true;
            cbemployee.Location = new Point(82, 26);
            cbemployee.Name = "cbemployee";
            cbemployee.Size = new Size(282, 23);
            cbemployee.TabIndex = 0;
            // 
            // lblemployee
            // 
            lblemployee.AutoSize = true;
            lblemployee.Location = new Point(33, 29);
            lblemployee.Name = "lblemployee";
            lblemployee.Size = new Size(43, 15);
            lblemployee.TabIndex = 1;
            lblemployee.Text = "従業員";
            // 
            // dtpWorkStart
            // 
            dtpWorkStart.Location = new Point(82, 63);
            dtpWorkStart.Name = "dtpWorkStart";
            dtpWorkStart.Size = new Size(124, 23);
            dtpWorkStart.TabIndex = 1;
            // 
            // dtpWorkEnd
            // 
            dtpWorkEnd.Location = new Point(240, 63);
            dtpWorkEnd.Name = "dtpWorkEnd";
            dtpWorkEnd.Size = new Size(124, 23);
            dtpWorkEnd.TabIndex = 2;
            // 
            // lblRange
            // 
            lblRange.AutoSize = true;
            lblRange.Location = new Point(45, 67);
            lblRange.Name = "lblRange";
            lblRange.Size = new Size(31, 15);
            lblRange.TabIndex = 1;
            lblRange.Text = "期間";
            // 
            // gbSearchQuery
            // 
            gbSearchQuery.Controls.Add(btnSearch);
            gbSearchQuery.Controls.Add(dtpWorkEnd);
            gbSearchQuery.Controls.Add(cbemployee);
            gbSearchQuery.Controls.Add(dtpWorkStart);
            gbSearchQuery.Controls.Add(lblemployee);
            gbSearchQuery.Controls.Add(lblRangeMark);
            gbSearchQuery.Controls.Add(lblRange);
            gbSearchQuery.Location = new Point(12, 12);
            gbSearchQuery.Name = "gbSearchQuery";
            gbSearchQuery.Size = new Size(451, 126);
            gbSearchQuery.TabIndex = 0;
            gbSearchQuery.TabStop = false;
            gbSearchQuery.Text = "検索";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(370, 92);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "検索";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // lblRangeMark
            // 
            lblRangeMark.AutoSize = true;
            lblRangeMark.Location = new Point(215, 68);
            lblRangeMark.Name = "lblRangeMark";
            lblRangeMark.Size = new Size(19, 15);
            lblRangeMark.TabIndex = 1;
            lblRangeMark.Text = "～";
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistory.Columns.AddRange(new DataGridViewColumn[] { colWorkStart, colWorkEnd, colEdit });
            dgvHistory.Location = new Point(12, 144);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.ReadOnly = true;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.RowTemplate.Height = 25;
            dgvHistory.Size = new Size(451, 478);
            dgvHistory.TabIndex = 1;
            // 
            // colWorkStart
            // 
            colWorkStart.HeaderText = "始業日時";
            colWorkStart.Name = "colWorkStart";
            colWorkStart.ReadOnly = true;
            colWorkStart.Width = 195;
            // 
            // colWorkEnd
            // 
            colWorkEnd.HeaderText = "終業日時";
            colWorkEnd.Name = "colWorkEnd";
            colWorkEnd.ReadOnly = true;
            colWorkEnd.Width = 195;
            // 
            // colEdit
            // 
            colEdit.HeaderText = "";
            colEdit.Name = "colEdit";
            colEdit.ReadOnly = true;
            colEdit.Text = "編集";
            colEdit.UseColumnTextForButtonValue = true;
            colEdit.Width = 58;
            // 
            // HistoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(475, 634);
            Controls.Add(dgvHistory);
            Controls.Add(gbSearchQuery);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "HistoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "まるそふと-勤怠管理-勤怠履歴";
            gbSearchQuery.ResumeLayout(false);
            gbSearchQuery.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cbemployee;
        private Label lblemployee;
        private DateTimePicker dtpWorkStart;
        private DateTimePicker dtpWorkEnd;
        private Label lblRange;
        private GroupBox gbSearchQuery;
        private Label lblRangeMark;
        private Button btnSearch;
        private DataGridView dgvHistory;
        private DataGridViewTextBoxColumn colWorkStart;
        private DataGridViewTextBoxColumn colWorkEnd;
        private DataGridViewButtonColumn colEdit;
    }
}