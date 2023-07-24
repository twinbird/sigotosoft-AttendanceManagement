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

        /// <summary>
        /// �Αӂ̗������m�F�{�^�����N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenHistory_Click(object sender, EventArgs e)
        {
            // �Αӗ����t�H�[�����Ăяo��
            var dlg = new HistoryForm();
            dlg.ShowDialog();
        }

        /// <summary>
        /// �Αӂ̏o�̓{�^�����N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenExcelOutput_Click(object sender, EventArgs e)
        {
            // �Αӂ̏o�̓t�H�[�����Ăяo��
            var dlg = new AttendanceExportForm();
            dlg.ShowDialog();
        }
    }
}