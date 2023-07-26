namespace AttendanceManagement
{
    partial class EmployerManageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployerManageForm));
            txtID = new TextBox();
            lblID = new Label();
            txtName = new TextBox();
            lblName = new Label();
            gbEmployer = new GroupBox();
            txtMemo = new TextBox();
            cbDisabled = new CheckBox();
            btnDelete = new Button();
            btnRegist = new Button();
            lblMemo = new Label();
            gbDataManage = new GroupBox();
            btnCSVImport = new Button();
            btnCSVExport = new Button();
            lvEmployers = new ListView();
            epEmployerInfo = new ErrorProvider(components);
            gbEmployer.SuspendLayout();
            gbDataManage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)epEmployerInfo).BeginInit();
            SuspendLayout();
            // 
            // txtID
            // 
            txtID.Location = new Point(72, 27);
            txtID.MaxLength = 10;
            txtID.Name = "txtID";
            txtID.Size = new Size(179, 23);
            txtID.TabIndex = 0;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(5, 30);
            lblID.Name = "lblID";
            lblID.Size = new Size(54, 15);
            lblID.TabIndex = 3;
            lblID.Text = "従業員ID";
            // 
            // txtName
            // 
            txtName.Location = new Point(72, 56);
            txtName.MaxLength = 50;
            txtName.Name = "txtName";
            txtName.Size = new Size(179, 23);
            txtName.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(5, 59);
            lblName.Name = "lblName";
            lblName.Size = new Size(31, 15);
            lblName.TabIndex = 3;
            lblName.Text = "名前";
            // 
            // gbEmployer
            // 
            gbEmployer.Controls.Add(txtMemo);
            gbEmployer.Controls.Add(cbDisabled);
            gbEmployer.Controls.Add(btnDelete);
            gbEmployer.Controls.Add(btnRegist);
            gbEmployer.Controls.Add(txtName);
            gbEmployer.Controls.Add(lblMemo);
            gbEmployer.Controls.Add(lblName);
            gbEmployer.Controls.Add(txtID);
            gbEmployer.Controls.Add(lblID);
            gbEmployer.Location = new Point(271, 12);
            gbEmployer.Name = "gbEmployer";
            gbEmployer.Size = new Size(278, 220);
            gbEmployer.TabIndex = 1;
            gbEmployer.TabStop = false;
            gbEmployer.Text = "従業員情報";
            // 
            // txtMemo
            // 
            txtMemo.Location = new Point(72, 85);
            txtMemo.MaxLength = 1000;
            txtMemo.Multiline = true;
            txtMemo.Name = "txtMemo";
            txtMemo.Size = new Size(179, 70);
            txtMemo.TabIndex = 2;
            // 
            // cbDisabled
            // 
            cbDisabled.AutoSize = true;
            cbDisabled.Location = new Point(86, 161);
            cbDisabled.Name = "cbDisabled";
            cbDisabled.Size = new Size(159, 19);
            cbDisabled.TabIndex = 3;
            cbDisabled.Text = "無効にする(退職・休職など)";
            cbDisabled.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.ForeColor = Color.Red;
            btnDelete.Location = new Point(13, 192);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(76, 23);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "削除";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnRegist
            // 
            btnRegist.Location = new Point(172, 192);
            btnRegist.Name = "btnRegist";
            btnRegist.Size = new Size(93, 23);
            btnRegist.TabIndex = 2;
            btnRegist.Text = "登録";
            btnRegist.UseVisualStyleBackColor = true;
            btnRegist.Click += btnRegist_Click;
            // 
            // lblMemo
            // 
            lblMemo.AutoSize = true;
            lblMemo.Location = new Point(5, 85);
            lblMemo.Name = "lblMemo";
            lblMemo.Size = new Size(24, 15);
            lblMemo.TabIndex = 3;
            lblMemo.Text = "メモ";
            // 
            // gbDataManage
            // 
            gbDataManage.Controls.Add(btnCSVImport);
            gbDataManage.Controls.Add(btnCSVExport);
            gbDataManage.Location = new Point(271, 300);
            gbDataManage.Name = "gbDataManage";
            gbDataManage.Size = new Size(278, 102);
            gbDataManage.TabIndex = 3;
            gbDataManage.TabStop = false;
            gbDataManage.Text = "データの管理";
            // 
            // btnCSVImport
            // 
            btnCSVImport.Location = new Point(35, 59);
            btnCSVImport.Name = "btnCSVImport";
            btnCSVImport.Size = new Size(206, 23);
            btnCSVImport.TabIndex = 1;
            btnCSVImport.Text = "CSVからインポート";
            btnCSVImport.UseVisualStyleBackColor = true;
            btnCSVImport.Click += btnCSVImport_Click;
            // 
            // btnCSVExport
            // 
            btnCSVExport.Location = new Point(35, 30);
            btnCSVExport.Name = "btnCSVExport";
            btnCSVExport.Size = new Size(206, 23);
            btnCSVExport.TabIndex = 0;
            btnCSVExport.Text = "CSVでエクスポート";
            btnCSVExport.UseVisualStyleBackColor = true;
            btnCSVExport.Click += btnCSVExport_Click;
            // 
            // lvEmployers
            // 
            lvEmployers.FullRowSelect = true;
            lvEmployers.GridLines = true;
            lvEmployers.Location = new Point(12, 16);
            lvEmployers.MultiSelect = false;
            lvEmployers.Name = "lvEmployers";
            lvEmployers.Size = new Size(253, 390);
            lvEmployers.TabIndex = 5;
            lvEmployers.UseCompatibleStateImageBehavior = false;
            lvEmployers.View = View.Details;
            lvEmployers.SelectedIndexChanged += lvEmployers_SelectedIndexChanged;
            // 
            // epEmployerInfo
            // 
            epEmployerInfo.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            epEmployerInfo.ContainerControl = this;
            // 
            // EmployerManageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 414);
            Controls.Add(lvEmployers);
            Controls.Add(gbDataManage);
            Controls.Add(gbEmployer);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EmployerManageForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "まるそふと-勤怠管理-従業員の登録・編集";
            Load += EmployerManageForm_Load;
            gbEmployer.ResumeLayout(false);
            gbEmployer.PerformLayout();
            gbDataManage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)epEmployerInfo).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtID;
        private Label lblID;
        private TextBox txtName;
        private Label lblName;
        private GroupBox gbEmployer;
        private CheckBox cbDisabled;
        private Button btnRegist;
        private Button btnDelete;
        private GroupBox gbDataManage;
        private Button btnCSVImport;
        private Button btnCSVExport;
        private Label lblMemo;
        private TextBox txtMemo;
        private ListView lvEmployers;
        private ErrorProvider epEmployerInfo;
    }
}