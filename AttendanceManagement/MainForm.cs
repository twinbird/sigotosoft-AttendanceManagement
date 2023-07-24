namespace AttendanceManagement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
    }
}