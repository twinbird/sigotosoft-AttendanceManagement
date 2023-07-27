using Csv;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Data;


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
            sfd.FileName = exportDefaultFileName(dtpWorkStart.Value, dtpWorkEnd.Value) + ".csv";
            sfd.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            sfd.Title = "保存先を指定してください。";
            sfd.FilterIndex = 2;
            sfd.Filter = "CSVファイル(*.csv)|*.csv";


            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            exportCSV(sfd.FileName, dtpWorkStart.Value, dtpWorkEnd.Value);

            MessageBox.Show("出力しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Excelエクスポート
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.FileName = exportDefaultFileName(dtpWorkStart.Value, dtpWorkEnd.Value) + ".xlsx";
            sfd.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            sfd.Title = "保存先を指定してください。";
            sfd.FilterIndex = 2;
            sfd.Filter = "Excelファイル(*.xlsx)|*.xlsx";

            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            exportExcel(sfd.FileName, dtpWorkStart.Value, dtpWorkEnd.Value);

            MessageBox.Show("出力しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                { "work_start_date", Utils.startTime(startDate) },
                { "work_end_date", Utils.endTime(endDate) }
            };
            var dt = db.ExecuteQuery(@"
                SELECT
                     attendances.employee_id AS employee_id
                    ,employees.name AS name
                    ,attendances.work_start_date
                    ,attendances.work_end_date
                FROM
                    attendances
                INNER JOIN
                    employees
                ON
                    employees.id = attendances.employee_id
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
                    var row = new string[]
                    {
                        dr["employee_id"].ToString() ?? "",
                        dr["name"].ToString() ?? "",
                        dr["work_start_date"].ToString() ?? "",
                        dr["work_end_date"].ToString() ?? "",
                    };
                    rowsList.Add(row);
                }
            }
            var rows = rowsList;
            var csv = CsvWriter.WriteToText(columnNames, rows, ',');
            File.WriteAllText(savepath, csv);
        }

        /// <summary>
        /// Excelエクスポートを行う
        /// </summary>
        /// <param name="work_start_date"></param>
        /// <param name="work_end_date"></param>
        private void exportExcel(string savepath, DateTime work_start_date, DateTime work_end_date)
        {
            var dt = getAttendances(work_start_date, work_end_date);

            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Sheet1");

            // ヘッダ行
            setExcelRowHeader(sheet);

            if (dt != null)
            {
                var idx = 1;
                foreach (DataRow dr in dt.Rows)
                {
                    setExcelRowBody(workbook, sheet, dr, idx);
                    idx++;
                }
            }

            using (FileStream fs = File.Create(savepath))
            {
                workbook.Write(fs);
            }

        }

        /// <summary>
        /// Excelエクスポートの行ヘッダを設定する
        /// </summary>
        /// <param name="sheet"></param>
        private void setExcelRowHeader(ISheet sheet)
        {
            IRow row = sheet.CreateRow(0);
            ICell idCell = row.CreateCell(0);
            idCell.SetCellType(CellType.String);
            idCell.SetCellValue("従業員ID");

            ICell nameCell = row.CreateCell(1);
            nameCell.SetCellType(CellType.String);
            nameCell.SetCellValue("名前");

            ICell workStartDateCell = row.CreateCell(2);
            workStartDateCell.SetCellType(CellType.String);
            workStartDateCell.SetCellValue("出勤日時");

            ICell workEndDateCell = row.CreateCell(3);
            workEndDateCell.SetCellType(CellType.String);
            workEndDateCell.SetCellValue("退勤日時");
        }

        /// <summary>
        /// Excelエクスポートのデータ行を設定する
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="row"></param>
        private void setExcelRowBody(IWorkbook book, ISheet sheet, DataRow dr, int idx)
        {
            IRow row = sheet.CreateRow(idx);

            var workStartDate = dr[2].ToString() ?? "";
            var workEndDate = dr[3].ToString() ?? "";

            // 日付書式設定
            var format = book.CreateDataFormat();
            var style = book.CreateCellStyle();
            style.DataFormat = format.GetFormat("yyyy年MM月dd日HH時mm分ss秒");

            // 従業員ID
            ICell idCell = row.CreateCell(0);
            idCell.SetCellType(CellType.String);
            idCell.SetCellValue(dr[0].ToString());

            // 名前
            ICell nameCell = row.CreateCell(1);
            nameCell.SetCellType(CellType.String);
            nameCell.SetCellValue(dr[1].ToString());

            // 出勤日時
            ICell workStartDateCell = row.CreateCell(2);
            workStartDateCell.CellStyle = style;
            workStartDateCell.SetCellValue(DateTime.Parse(workStartDate));

            // 退勤日時
            ICell workEndDateCell = row.CreateCell(3);
            workEndDateCell.CellStyle = style;
            workEndDateCell.SetCellValue(DateTime.Parse(workEndDate));
        }

        /// <summary>
        /// エクスポート時のデフォルトファイル名を返す
        /// </summary>
        /// <param name="work_start_date"></param>
        /// <param name="work_end_date"></param>
        /// <returns></returns>
        private string exportDefaultFileName(DateTime work_start_date, DateTime work_end_date)
        {
            var ss = work_start_date.ToString("M");
            var es = work_end_date.ToString("M");

            return "勤怠" + ss + "～" + es;
        }

        #endregion

    }
}
