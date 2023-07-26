using System.Data.SQLite;

namespace AttendanceManagement
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// �ݒ�t�@�C�����
        /// </summary>
        private MalConfig mConfiguration;

        public MainForm()
        {
            InitializeComponent();

            mConfiguration = new MalConfig("AttendanceManagement.sqlite3");
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
            dlg.configuration = mConfiguration;
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

        private void btnStartWork_Click(object sender, EventArgs e)
        {
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            execDDL();
        }

        /// <summary>
        /// DDL�����s���ăe�[�u�����쐬
        /// </summary>
        private void execDDL()
        {
            var db = new SQLiteADOWrapper(mConfiguration.getDBFilePath());

            /* �A�v���o�[�W�����e�[�u�� */
            db.ExecuteNonQuery(@"
                CREATE TABLE IF NOT EXISTS version (
	                 version INTEGER PRIMARY KEY
	                ,created_at TEXT
	                ,updated_at TEXT
                )");

            /* �]�ƈ��e�[�u�� */
            db.ExecuteNonQuery(@"
                CREATE TABLE IF NOT EXISTS employers (
	                 id TEXT PRIMARY KEY
	                ,name TEXT NOT NULL
                    ,memo TEXT
                    ,is_disabled INTEGER NOT NULL
	                ,created_at TEXT
	                ,updated_at TEXT
                )");

            /* �ΑӃe�[�u�� */
            db.ExecuteNonQuery(@"
                CREATE TABLE IF NOT EXISTS attendances (
	                 employer_id TEXT NOT NULL
	                ,work_start_date TEXT NOT NULL
	                ,work_end_date TEXT NOT NULL
	                ,created_at TEXT
	                ,updated_at TEXT
                )");
        }
    }
}