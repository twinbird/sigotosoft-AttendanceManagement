namespace AttendanceManagement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �]�ƈ��ݒ�̃��j���[���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void �]�ƈ��ݒ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // �]�ƈ��̓o�^�E�ҏW�t�H�[�����Ăяo��
            var dlg = new EmployerManageForm();
            dlg.ShowDialog();
        }

        /// <summary>
        /// �Αӗ����̃��j���[���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void �Αӗ���ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // �Αӗ����t�H�[�����Ăяo��
            var dlg = new HistoryForm();
            dlg.ShowDialog();
        }

        /// <summary>
        /// �Αӏo�͂̃��j���[���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void �o��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // �Αӂ̏o�̓t�H�[�����Ăяo��
            var dlg = new AttendanceExportForm();
            dlg.ShowDialog();
        }
    }
}