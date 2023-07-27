using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceManagement
{
    public partial class AddAttendanceForm : Form
    {
        #region "プロパティ"

        /// <summary>
        /// 設定ファイル情報のプロパティ
        /// </summary>
        public ConfigWrapper? configuration { get; set; }

        /// <summary>
        /// デフォルトの従業員ID
        /// </summary>
        public string? employee_id { get; set; }

        #endregion

        public AddAttendanceForm()
        {
            InitializeComponent();
        }

        #region "イベント"

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAttendanceForm_Load(object sender, EventArgs e)
        {
            initEmployeesCombobox();
            cbemployee.SelectedValue = employee_id;
            setupWorkDatePicker();
        }

        /// <summary>
        /// 登録ボタンをクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegist_Click(object sender, EventArgs e)
        {
            if (validateInput() == false)
            {
                return;
            }
            if (registAttendance() == true)
            {
                MessageBox.Show("登録しました", "登録完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region "関数"

        /// <summary>
        /// 日時指定用のDateTimePickerを初期化
        /// </summary>
        private void setupWorkDatePicker()
        {
            var now = DateTime.Now;
            var start = new DateTime(now.Year, now.Month, now.Day, 8, 30, 00);
            var end = new DateTime(now.Year, now.Month, now.Day, 17, 30, 00);
            dtpWorkStartDate.Value = start;
            dtpWorkEndDate.Value = end;
        }

        /// <summary>
        /// 検証エラーメッセージをリセットする
        /// </summary>
        private void resetValidateInput()
        {
            epInput.SetError(dtpWorkStartDate, null);
            epInput.SetError(dtpWorkEndDate, null);
        }

        /// <summary>
        /// 入力検証
        /// </summary>
        /// <returns></returns>
        private bool validateInput()
        {
            resetValidateInput();
            var employee_id = cbemployee.SelectedValue.ToString() ?? "";

            // 出勤日時が退勤日時より後
            if (dtpWorkStartDate.Value > dtpWorkEndDate.Value)
            {
                epInput.SetError(dtpWorkStartDate, "出勤日時が退勤日時より後になっています");
                return false;
            }

            // 出勤日時か退勤日時が登録済みの勤怠の範囲にある
            if (isIncludeRegistedAttendanceRange(employee_id, dtpWorkStartDate.Value))
            {
                epInput.SetError(dtpWorkStartDate, "出勤日時が登録済みの勤務時間内になっています");
                return false;
            }
            if (isIncludeRegistedAttendanceRange(employee_id, dtpWorkEndDate.Value))
            {
                epInput.SetError(dtpWorkEndDate, "退勤日時が登録済みの勤務時間内になっています");
                return false;
            }

            // 出勤日時と退勤日時の間に登録済みの勤怠がある
            if (isIncludeRegistedAttendanceRange(employee_id, dtpWorkStartDate.Value, dtpWorkEndDate.Value))
            {
                epInput.SetError(dtpWorkStartDate, "出勤日時と退勤日時の間に登録済みの勤務があります");
                return false;
            }

            return true;
        }

        /// <summary>
        /// 従業員のコンボボックスを設定
        /// </summary>
        private void initEmployeesCombobox()
        {
            if (configuration == null)
            {
                return;
            }

            cbemployee.Items.Clear();
            cbemployee.DisplayMember = "Key";
            cbemployee.ValueMember = "Value";

            var db = new SQLiteADOWrapper(configuration.getDBFilePath());
            var dt = db.ExecuteQuery(@"
                SELECT
                    *
                FROM
                    employees
                WHERE
                    is_disabled = 0
                ORDER BY
                    id");
            if (dt == null)
            {
                return;
            }

            var dic = new Dictionary<string, string>();
            foreach (DataRow dr in dt.Rows)
            {
                var name = dr["name"].ToString() ?? "";
                var id = dr["id"].ToString() ?? "";
                var display = $"【{id}】{name}";
                dic[display] = id;
            }

            cbemployee.DataSource = dic.ToList();
        }

        /// <summary>
        /// 勤怠履歴を登録する
        /// </summary>
        private bool registAttendance()
        {
            if (configuration == null)
            {
                MessageBox.Show("登録に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var emp_id = cbemployee.SelectedValue.ToString();
            var start = dtpWorkStartDate.Value;
            var end = dtpWorkEndDate.Value;

            if (emp_id == null)
            {
                return false;
            }

            var db = new SQLiteADOWrapper(configuration.getDBFilePath());
            var param = new Dictionary<string, object>() {
                { "employee_id", emp_id },
                { "work_start_date", start },
                { "work_end_date", end },
            };
            var ret = db.ExecuteNonQuery(@"
                INSERT INTO attendances (
                     employee_id
                    ,work_start_date
                    ,work_end_date
                    ,created_at
                    ,updated_at
                ) VALUES (
                     $employee_id
                    ,$work_start_date
                    ,$work_end_date
                    ,datetime('now', 'localtime')
                    ,datetime('now', 'localtime')
                )
                ", param);
            if (ret == -1)
            {
                MessageBox.Show("登録に失敗しました。", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 登録済みの勤務時間に引数の日時が含まれていればtrue
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private bool isIncludeRegistedAttendanceRange(string employee_id, DateTime dat)
        {
            if (configuration == null)
            {
                return false;
            }

            var db = new SQLiteADOWrapper(configuration.getDBFilePath());
            var param = new Dictionary<string, object>() {
                { "employee_id", employee_id },
                { "dat1", dat },
                { "dat2", dat },
            };
            var dt = db.ExecuteQuery(@"
                SELECT
                    *
                FROM
                    attendances
                WHERE
                    employee_id = $employee_id
                AND
                    work_start_date <= $dat1
                AND
                    $dat2 <= coalesce(work_end_date, datetime('9999-12-31 23:59:59'))
                ", param);
            if (dt == null || dt.Rows.Count == 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 引数の日時に登録済みの勤務時間にが含まれていればtrue
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private bool isIncludeRegistedAttendanceRange(string employee_id, DateTime start, DateTime end)
        {
            if (configuration == null)
            {
                return false;
            }

            var db = new SQLiteADOWrapper(configuration.getDBFilePath());
            var param = new Dictionary<string, object>() {
                { "employee_id", employee_id },
                { "work_start_date", start },
                { "work_end_date", end },
            };
            var dt = db.ExecuteQuery(@"
                SELECT
                    *
                FROM
                    attendances
                WHERE
                    employee_id = $employee_id
                AND
                    $work_start_date <= work_start_date
                AND
                    work_end_date <= $work_end_date
                ", param);
            if (dt == null || dt.Rows.Count == 0)
            {
                return false;
            }

            return true;
        }

        #endregion

    }
}
