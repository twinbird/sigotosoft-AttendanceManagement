namespace AttendanceManagement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �]�ƈ��̓o�^�E�ҏW�{�^�����N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenEmployerManage_Click(object sender, EventArgs e)
        {
            // �]�ƈ��̓o�^�E�ҏW�t�H�[�����Ăяo��
            var dlg = new EmployerManageForm();
            dlg.ShowDialog();
        }
    }
}