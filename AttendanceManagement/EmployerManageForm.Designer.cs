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
            lbEmployers = new ListBox();
            lblID = new Label();
            txtName = new TextBox();
            lblName = new Label();
            gbEmployer = new GroupBox();
            textBox1 = new TextBox();
            cbDisabled = new CheckBox();
            lblMemo = new Label();
            btnRegist = new Button();
            btnDelete = new Button();
            gbDataManage = new GroupBox();
            btnCSVImport = new Button();
            btnCSVExport = new Button();
            epID = new ErrorProvider(components);
            epName = new ErrorProvider(components);
            epMemo = new ErrorProvider(components);
            gbEmployer.SuspendLayout();
            gbDataManage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)epID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)epName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)epMemo).BeginInit();
            SuspendLayout();
            // 
            // txtID
            // 
            txtID.Location = new Point(86, 27);
            txtID.Name = "txtID";
            txtID.Size = new Size(153, 23);
            txtID.TabIndex = 0;
            // 
            // lbEmployers
            // 
            lbEmployers.FormattingEnabled = true;
            lbEmployers.ItemHeight = 15;
            lbEmployers.Location = new Point(12, 12);
            lbEmployers.Name = "lbEmployers";
            lbEmployers.Size = new Size(253, 394);
            lbEmployers.TabIndex = 0;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Location = new Point(13, 30);
            lblID.Name = "lblID";
            lblID.Size = new Size(67, 15);
            lblID.TabIndex = 3;
            lblID.Text = "従業員番号";
            // 
            // txtName
            // 
            txtName.Location = new Point(86, 61);
            txtName.Name = "txtName";
            txtName.Size = new Size(153, 23);
            txtName.TabIndex = 1;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(13, 64);
            lblName.Name = "lblName";
            lblName.Size = new Size(31, 15);
            lblName.TabIndex = 3;
            lblName.Text = "名前";
            // 
            // gbEmployer
            // 
            gbEmployer.Controls.Add(textBox1);
            gbEmployer.Controls.Add(cbDisabled);
            gbEmployer.Controls.Add(txtName);
            gbEmployer.Controls.Add(lblMemo);
            gbEmployer.Controls.Add(lblName);
            gbEmployer.Controls.Add(txtID);
            gbEmployer.Controls.Add(lblID);
            gbEmployer.Location = new Point(271, 12);
            gbEmployer.Name = "gbEmployer";
            gbEmployer.Size = new Size(271, 196);
            gbEmployer.TabIndex = 1;
            gbEmployer.TabStop = false;
            gbEmployer.Text = "従業員情報";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(86, 95);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(153, 70);
            textBox1.TabIndex = 2;
            // 
            // cbDisabled
            // 
            cbDisabled.AutoSize = true;
            cbDisabled.Location = new Point(86, 171);
            cbDisabled.Name = "cbDisabled";
            cbDisabled.Size = new Size(92, 19);
            cbDisabled.TabIndex = 3;
            cbDisabled.Text = "退職・入社前";
            cbDisabled.UseVisualStyleBackColor = true;
            // 
            // lblMemo
            // 
            lblMemo.AutoSize = true;
            lblMemo.Location = new Point(13, 95);
            lblMemo.Name = "lblMemo";
            lblMemo.Size = new Size(24, 15);
            lblMemo.TabIndex = 3;
            lblMemo.Text = "メモ";
            // 
            // btnRegist
            // 
            btnRegist.Location = new Point(449, 214);
            btnRegist.Name = "btnRegist";
            btnRegist.Size = new Size(93, 23);
            btnRegist.TabIndex = 2;
            btnRegist.Text = "登録・更新";
            btnRegist.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.ForeColor = Color.Red;
            btnDelete.Location = new Point(271, 383);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(130, 23);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "選択中の従業員を削除";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // gbDataManage
            // 
            gbDataManage.Controls.Add(btnCSVImport);
            gbDataManage.Controls.Add(btnCSVExport);
            gbDataManage.Location = new Point(271, 262);
            gbDataManage.Name = "gbDataManage";
            gbDataManage.Size = new Size(271, 102);
            gbDataManage.TabIndex = 3;
            gbDataManage.TabStop = false;
            gbDataManage.Text = "データの管理";
            // 
            // btnCSVImport
            // 
            btnCSVImport.Location = new Point(24, 59);
            btnCSVImport.Name = "btnCSVImport";
            btnCSVImport.Size = new Size(189, 23);
            btnCSVImport.TabIndex = 1;
            btnCSVImport.Text = "CSVからインポート";
            btnCSVImport.UseVisualStyleBackColor = true;
            // 
            // btnCSVExport
            // 
            btnCSVExport.Location = new Point(24, 30);
            btnCSVExport.Name = "btnCSVExport";
            btnCSVExport.Size = new Size(189, 23);
            btnCSVExport.TabIndex = 0;
            btnCSVExport.Text = "CSVでエクスポート";
            btnCSVExport.UseVisualStyleBackColor = true;
            // 
            // epID
            // 
            epID.ContainerControl = this;
            // 
            // epName
            // 
            epName.ContainerControl = this;
            // 
            // epMemo
            // 
            epMemo.ContainerControl = this;
            // 
            // EmployerManageForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(554, 414);
            Controls.Add(gbDataManage);
            Controls.Add(btnDelete);
            Controls.Add(btnRegist);
            Controls.Add(gbEmployer);
            Controls.Add(lbEmployers);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EmployerManageForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "まるそふと-勤怠管理-従業員の登録・編集";
            gbEmployer.ResumeLayout(false);
            gbEmployer.PerformLayout();
            gbDataManage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)epID).EndInit();
            ((System.ComponentModel.ISupportInitialize)epName).EndInit();
            ((System.ComponentModel.ISupportInitialize)epMemo).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtID;
        private ListBox lbEmployers;
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
        private ErrorProvider epID;
        private ErrorProvider epName;
        private Label lblMemo;
        private TextBox textBox1;
        private ErrorProvider epMemo;
    }
}