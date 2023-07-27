using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace AttendanceManagement
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// �ݒ�t�@�C�����
        /// </summary>
        private ConfigWrapper mConfiguration;

        /// <summary>
        /// �A�v���̃o�[�W����
        /// </summary>
        const string APP_VERSION = "1.0";

        public MainForm()
        {
            InitializeComponent();

            mConfiguration = new ConfigWrapper("AttendanceManagement.sqlite3");
        }

        #region "�C�x���g"

        /// <summary>
        /// �]�ƈ��ݒ�̃��j���[���N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void �]�ƈ��ݒ�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // �]�ƈ��̓o�^�E�ҏW�t�H�[�����Ăяo��
            var dlg = new employeeManageForm();
            dlg.configuration = mConfiguration;
            dlg.ShowDialog();

            // �]�ƈ�����ǂݒ���
            loademployeesList();
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
            dlg.configuration = mConfiguration;
            dlg.ShowDialog();
        }

        /// <summary>
        /// �o�΃{�^�����N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartWork_Click(object sender, EventArgs e)
        {
            var id = lvemployees.SelectedItems[0].Text;
            registAttendance(id);
            changeAttendanceButtonEnable();
        }

        /// <summary>
        /// �ދ΃{�^�����N���b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndWork_Click(object sender, EventArgs e)
        {
            var id = lvemployees.SelectedItems[0].Text;
            registLeave(id);
            changeAttendanceButtonEnable();
        }

        /// <summary>
        /// ���C���t�H�[���̃��[�h�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            setupDatabase();
            initForm();
            loademployeesList();
        }

        /// <summary>
        /// �\���^�C�}�[�̍X�V
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tiUpdateClock_Tick(object sender, EventArgs e)
        {
            displayClock();
        }

        /// <summary>
        /// �]�ƈ��̃��X�g��I��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvemployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvemployees.SelectedIndices.Count == 0)
            {
                return;
            }
            changeAttendanceButtonEnable();
        }

        #endregion

        #region "�֐�"

        /// <summary>
        /// �f�[�^�x�[�X��ݒ�
        /// </summary>
        private void setupDatabase()
        {
            execDDL();
            if (getDatabaseVersion() == "")
            {
                insertVersionRecord();
            }
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
	                 version TEXT PRIMARY KEY
	                ,created_at TEXT
	                ,updated_at TEXT
                )");

            /* �]�ƈ��e�[�u�� */
            db.ExecuteNonQuery(@"
                CREATE TABLE IF NOT EXISTS employees (
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
                     id INTEGER PRIMARY KEY AUTOINCREMENT
	                ,employee_id TEXT NOT NULL
	                ,work_start_date TEXT NOT NULL
	                ,work_end_date TEXT
	                ,created_at TEXT
	                ,updated_at TEXT
                )");
        }

        /// <summary>
        /// DB�t�@�C���̃A�v���o�[�W�������擾
        /// </summary>
        private string getDatabaseVersion()
        {
            var db = new SQLiteADOWrapper(mConfiguration.getDBFilePath());
            var dt = db.ExecuteQuery(@"
                SELECT
                    version
                FROM
                    version
            ");
            if (dt == null || dt.Rows.Count == 0)
            {
                return "";
            }
            return dt.Rows[0]["version"].ToString() ?? "";
        }

        /// <summary>
        /// �o�[�W���������X�V
        /// </summary>
        private void insertVersionRecord()
        {
            var db = new SQLiteADOWrapper(mConfiguration.getDBFilePath());

            var param = new Dictionary<string, object>() { { "version", APP_VERSION } };
            db.ExecuteNonQuery(@"
                INSERT INTO version (version, created_at, updated_at)
                VALUES ($version, datetime('now', 'localtime'), datetime('now', 'localtime'))
            ", param);

        }

        /// <summary>
        /// �t�H�[����������
        /// </summary>
        private void initForm()
        {
            displayClock();
            initemployeesListViewColumn();
            displayVersion();
        }

        /// <summary>
        /// �o�[�W��������\��
        /// </summary>
        private void displayVersion()
        {
            var dbver = getDatabaseVersion();
            var str = $"App Version {APP_VERSION}  DB Version {dbver}";
            lblVersion.Text = str;
        }

        /// <summary>
        /// ���v��\��
        /// </summary>
        private void displayClock()
        {
            var dt = DateTime.Now;
            lblCurrentTime.Text = dt.ToString("HH:mm:ss");
        }

        /// <summary>
        /// �]�ƈ����̃��X�g�r���[������������
        /// </summary>
        private void initemployeesListViewColumn()
        {
            // ���X�g�r���[�̃w�b�_�ݒ�
            lvemployees.Columns.Add("ID", 68, HorizontalAlignment.Left);
            lvemployees.Columns.Add("���O", 180, HorizontalAlignment.Left);
        }

        /// <summary>
        /// �]�ƈ��������X�g�r���[�֓ǂ݂���
        /// </summary>
        private void loademployeesList()
        {
            lvemployees.Items.Clear();

            var db = new SQLiteADOWrapper(mConfiguration.getDBFilePath());
            var dt = db.ExecuteQuery(@"
                SELECT
                    *
                FROM
                    employees
                ORDER BY
                    id");
            if (dt == null)
            {
                return;
            }

            foreach (DataRow dr in dt.Rows)
            {
                var row = lvemployees.Items.Add(dr["id"].ToString());
                row.SubItems.Add(dr["name"].ToString());
            }
        }

        /// <summary>
        /// �Ō�ɏo�΂����o�ދ΃��R�[�h��Ԃ�
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private DataRow? getLatestAttendance(string id)
        {
            var db = new SQLiteADOWrapper(mConfiguration.getDBFilePath());
            var param = new Dictionary<string, object>() { { "id", id } };
            var dt = db.ExecuteQuery(@"
                SELECT
                    *
                FROM
                    attendances
                WHERE
                    employee_id = $id
                ORDER BY
                     work_start_date DESC
                LIMIT 1", param);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }

            return dt.Rows[0];
        }

        /// <summary>
        /// �o�ދ΃{�^���̖�����Ԃ�ύX
        /// </summary>
        private void changeAttendanceButtonEnable()
        {
            var id = lvemployees.SelectedItems[0].Text;
            var latestRec = getLatestAttendance(id);
            if (latestRec == null)
            {
                // ���o�΂Ȃ̂ŏo�΂݂̂ł���
                btnStartWork.Enabled = true;
                btnEndWork.Enabled = false;
                return;
            }

            // �o�΂��ދ΂����Ă�����o�΂݂̂ł���
            if (latestRec["work_start_date"].ToString() != "" && latestRec["work_end_date"].ToString() != "")
            {
                btnStartWork.Enabled = true;
                btnEndWork.Enabled = false;
            }

            // �o�΂��Ă��鎞�ɂ͑ދ΂݂̂ł���
            if (latestRec["work_start_date"].ToString() != "" && latestRec["work_end_date"].ToString() == "")
            {
                btnStartWork.Enabled = false;
                btnEndWork.Enabled = true;
            }
        }

        /// <summary>
        /// �o�΃f�[�^��o�^
        /// </summary>
        private void registAttendance(string id)
        {
            var db = new SQLiteADOWrapper(mConfiguration.getDBFilePath());
            var param = new Dictionary<string, object>() {
                { "employee_id", id },
            };
            var ret = db.ExecuteNonQuery(@"
                INSERT INTO attendances (
                     employee_id
                    ,work_start_date
                    ,created_at
                    ,updated_at
                ) VALUES (
                     $employee_id
                    ,datetime('now', 'localtime')
                    ,datetime('now', 'localtime')
                    ,datetime('now', 'localtime')
                )
                ", param);
            if (ret == -1)
            {
                MessageBox.Show("�o�^�Ɏ��s���܂����B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// �ދ΃f�[�^��o�^
        /// </summary>
        private void registLeave(string id)
        {
            var rec = getLatestAttendance(id);
            if (rec == null)
            {
                MessageBox.Show("�o�^�Ɏ��s���܂����B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var attendance_id = rec["id"].ToString();
            if (attendance_id == null)
            {
                MessageBox.Show("�o�^�Ɏ��s���܂����B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            var db = new SQLiteADOWrapper(mConfiguration.getDBFilePath());
            var param = new Dictionary<string, object>() {
                { "employee_id", id },
                { "id", attendance_id },
            };
            var ret = db.ExecuteNonQuery(@"
                UPDATE attendances
                SET
                     work_end_date = datetime('now', 'localtime')
                    ,updated_at =  datetime('now', 'localtime')
                WHERE
                    id = $id
                AND
                    employee_id = $employee_id
                ", param);
            if (ret == -1)
            {
                MessageBox.Show("�o�^�Ɏ��s���܂����B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

    #endregion

}