namespace AttendanceManagement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 従業員の登録・編集ボタンをクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenEmployerManage_Click(object sender, EventArgs e)
        {
            // 従業員の登録・編集フォームを呼び出す
            var dlg = new EmployerManageForm();
            dlg.ShowDialog();
        }

        /// <summary>
        /// 勤怠の履歴を確認ボタンをクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenHistory_Click(object sender, EventArgs e)
        {
            // 勤怠履歴フォームを呼び出す
            var dlg = new HistoryForm();
            dlg.ShowDialog();
        }

        /// <summary>
        /// 勤怠の出力ボタンをクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenExcelOutput_Click(object sender, EventArgs e)
        {
            // 勤怠の出力フォームを呼び出す
            var dlg = new AttendanceExportForm();
            dlg.ShowDialog();
        }
    }
}