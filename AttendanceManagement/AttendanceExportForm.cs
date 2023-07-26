using Csv;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceManagement
{
    /// <summary>
    /// 勤怠出力フォーム
    /// </summary>
    public partial class AttendanceExportForm : Form
    {
        public AttendanceExportForm()
        {
            InitializeComponent();
        }

        #region "プロパティ"

        /// <summary>
        /// 設定ファイル情報のプロパティ
        /// </summary>
        public ConfigWrapper? configuration { get; set; }

        #endregion


        #region "イベント"

        /// <summary>
        /// CSVエクスポート
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.FileName = "勤怠.csv";
            sfd.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            sfd.Title = "保存先を指定してください。";
            sfd.FilterIndex = 2;

            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            exportCSV(sfd.FileName, dtpWorkStart.Value, dtpWorkEnd.Value);
        }

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttendanceExportForm_Load(object sender, EventArgs e)
        {
            initForm();
        }

        #endregion

        #region "関数"

        /// <summary>
        /// フォームを初期化する
        /// </summary>
        private void initForm()
        {
            // 前月の1日を取得
            DateTime previousMonthFirstDay = DateTime.Now.AddMonths(-1);
            previousMonthFirstDay = new DateTime(previousMonthFirstDay.Year, previousMonthFirstDay.Month, 1);

            // 前月の1日の0時0分0秒に設定
            previousMonthFirstDay = previousMonthFirstDay.Date;

            // 前月の末日を求める
            DateTime previousMonthLastDay = previousMonthFirstDay.AddMonths(1).AddDays(-1);
            // 前月の末日の0時0分0秒に設定
            previousMonthLastDay = previousMonthLastDay.Date;

            // 開始は前月の1日にしておく
            dtpWorkStart.Value = previousMonthFirstDay;
            // 終了は前月末にしておく
            dtpWorkEnd.Value = previousMonthLastDay;
        }

        /// <summary>
        /// 勤怠情報を取得する
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        private DataTable? getAttendances(DateTime startDate, DateTime endDate)
        {
            if (configuration == null)
            {
                return null;
            }

            var db = new SQLiteADOWrapper(configuration.getDBFilePath());
            var param = new Dictionary<string, object>() {
                { "work_start_date", startDate.ToString("yyyy-MM-dd HH:mm:ss") },
                { "work_end_date", endDate.ToString("yyyy-MM-dd HH:mm:ss") }
            };
            var dt = db.ExecuteQuery(@"
                SELECT
                    *
                FROM
                    attendances
                INNER JOIN
                    employers
                ON
                    employers.id = attendances.employer_id
                WHERE
                    $work_start_date <= work_start_date
                AND
                    work_end_date <= $work_end_date
                ORDER BY
                    work_start_date", param);
            return dt;
        }

        /// <summary>
        /// CSVエクスポートを行う
        /// </summary>
        /// <param name="work_start_date"></param>
        /// <param name="work_end_date"></param>
        private void exportCSV(string savepath, DateTime work_start_date, DateTime work_end_date)
        {
            var dt = getAttendances(work_start_date, work_end_date);

            var columnNames = new[] { "従業員ID", "名前", "出勤日時", "退勤日時" };
            var rowsList = new List<string[]>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var row = new[]
                    {
                        dr["employer_id"].ToString(),
                        dr["name"].ToString(),
                        dr["work_start_time"].ToString(),
                        dr["work_end_time"].ToString(),
                    };
                    rowsList.Add(row);
                }
            }
            var rows = rowsList;
            var csv = CsvWriter.WriteToText(columnNames, rows, ',');
            File.WriteAllText(savepath, csv);

        }

        #endregion

    }
}
