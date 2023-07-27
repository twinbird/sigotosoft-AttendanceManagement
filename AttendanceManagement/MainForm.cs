using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace AttendanceManagement
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 設定ファイル情報
        /// </summary>
        private ConfigWrapper mConfiguration;

        /// <summary>
        /// アプリのバージョン
        /// </summary>
        const string APP_VERSION = "1.0";

        public MainForm()
        {
            InitializeComponent();

            mConfiguration = new ConfigWrapper("AttendanceManagement.sqlite3");
        }

        #region "イベント"

        /// <summary>
        /// 従業員設定のメニューをクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 従業員設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 従業員の登録・編集フォームを呼び出す
            var dlg = new employeeManageForm();
            dlg.configuration = mConfiguration;
            dlg.ShowDialog();

            // 従業員情報を読み直す
            loademployeesList();
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
            dlg.configuration = mConfiguration;
            dlg.ShowDialog();
        }

        /// <summary>
        /// 出勤ボタンをクリック
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
        /// 退勤ボタンをクリック
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
        /// メインフォームのロードイベント
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
        /// 表示タイマーの更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tiUpdateClock_Tick(object sender, EventArgs e)
        {
            displayClock();
        }

        /// <summary>
        /// 従業員のリストを選択
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

        #region "関数"

        /// <summary>
        /// データベースを設定
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
        /// DDLを実行してテーブルを作成
        /// </summary>
        private void execDDL()
        {
            var db = new SQLiteADOWrapper(mConfiguration.getDBFilePath());

            /* アプリバージョンテーブル */
            db.ExecuteNonQuery(@"
                CREATE TABLE IF NOT EXISTS version (
	                 version TEXT PRIMARY KEY
	                ,created_at TEXT
	                ,updated_at TEXT
                )");

            /* 従業員テーブル */
            db.ExecuteNonQuery(@"
                CREATE TABLE IF NOT EXISTS employees (
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
                     id INTEGER PRIMARY KEY AUTOINCREMENT
	                ,employee_id TEXT NOT NULL
	                ,work_start_date TEXT NOT NULL
	                ,work_end_date TEXT
	                ,created_at TEXT
	                ,updated_at TEXT
                )");
        }

        /// <summary>
        /// DBファイルのアプリバージョンを取得
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
        /// バージョン情報を更新
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
        /// フォームを初期化
        /// </summary>
        private void initForm()
        {
            displayClock();
            initemployeesListViewColumn();
            displayVersion();
        }

        /// <summary>
        /// バージョン情報を表示
        /// </summary>
        private void displayVersion()
        {
            var dbver = getDatabaseVersion();
            var str = $"App Version {APP_VERSION}  DB Version {dbver}";
            lblVersion.Text = str;
        }

        /// <summary>
        /// 時計を表示
        /// </summary>
        private void displayClock()
        {
            var dt = DateTime.Now;
            lblCurrentTime.Text = dt.ToString("HH:mm:ss");
        }

        /// <summary>
        /// 従業員情報のリストビューを初期化する
        /// </summary>
        private void initemployeesListViewColumn()
        {
            // リストビューのヘッダ設定
            lvemployees.Columns.Add("ID", 68, HorizontalAlignment.Left);
            lvemployees.Columns.Add("名前", 180, HorizontalAlignment.Left);
        }

        /// <summary>
        /// 従業員情報をリストビューへ読みだす
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
        /// 最後に出勤した出退勤レコードを返す
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
        /// 出退勤ボタンの無効状態を変更
        /// </summary>
        private void changeAttendanceButtonEnable()
        {
            var id = lvemployees.SelectedItems[0].Text;
            var latestRec = getLatestAttendance(id);
            if (latestRec == null)
            {
                // 初出勤なので出勤のみできる
                btnStartWork.Enabled = true;
                btnEndWork.Enabled = false;
                return;
            }

            // 出勤も退勤もしていたら出勤のみできる
            if (latestRec["work_start_date"].ToString() != "" && latestRec["work_end_date"].ToString() != "")
            {
                btnStartWork.Enabled = true;
                btnEndWork.Enabled = false;
            }

            // 出勤している時には退勤のみできる
            if (latestRec["work_start_date"].ToString() != "" && latestRec["work_end_date"].ToString() == "")
            {
                btnStartWork.Enabled = false;
                btnEndWork.Enabled = true;
            }
        }

        /// <summary>
        /// 出勤データを登録
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
                MessageBox.Show("登録に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 退勤データを登録
        /// </summary>
        private void registLeave(string id)
        {
            var rec = getLatestAttendance(id);
            if (rec == null)
            {
                MessageBox.Show("登録に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var attendance_id = rec["id"].ToString();
            if (attendance_id == null)
            {
                MessageBox.Show("登録に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("登録に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

    #endregion

}