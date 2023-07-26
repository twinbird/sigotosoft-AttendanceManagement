using System.Data.SQLite;

namespace AttendanceManagement
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 設定ファイル情報
        /// </summary>
        private MalConfig mConfiguration;

        public MainForm()
        {
            InitializeComponent();

            mConfiguration = new MalConfig("AttendanceManagement.sqlite3");
        }

        /// <summary>
        /// 従業員設定のメニューをクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 従業員設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 従業員の登録・編集フォームを呼び出す
            var dlg = new EmployerManageForm();
            dlg.configuration = mConfiguration;
            dlg.ShowDialog();
        }

        /// <summary>
        /// 勤怠履歴のメニューをクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 勤怠履歴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 勤怠履歴フォームを呼び出す
            var dlg = new HistoryForm();
            dlg.ShowDialog();
        }

        /// <summary>
        /// 勤怠出力のメニューをクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 出力ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 勤怠の出力フォームを呼び出す
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
        /// DDLを実行してテーブルを作成
        /// </summary>
        private void execDDL()
        {
            var db = new SQLiteADOWrapper(mConfiguration.getDBFilePath());

            /* アプリバージョンテーブル */
            db.ExecuteNonQuery(@"
                CREATE TABLE IF NOT EXISTS version (
	                 version INTEGER PRIMARY KEY
	                ,created_at TEXT
	                ,updated_at TEXT
                )");

            /* 従業員テーブル */
            db.ExecuteNonQuery(@"
                CREATE TABLE IF NOT EXISTS employers (
	                 id TEXT PRIMARY KEY
	                ,name TEXT NOT NULL
                    ,memo TEXT
                    ,is_disabled INTEGER NOT NULL
	                ,created_at TEXT
	                ,updated_at TEXT
                )");

            /* 勤怠テーブル */
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