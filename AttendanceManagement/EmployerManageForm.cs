using System.Data;

namespace AttendanceManagement
{
    /// <summary>
    /// 従業員の登録・編集フォーム
    /// </summary>
    public partial class EmployerManageForm : Form
    {
        #region "プロパティ"

        /// <summary>
        /// 設定ファイル情報のプロパティ
        /// </summary>
        public MalConfig? configuration { get; set; }

        #endregion

        #region "定数"

        /// <summary>
        /// 従業員情報のリストビューの新規追加用行の名前の値
        /// </summary>
        const string EMPLOYERS_NEW_USER_ROW_NAME_VALUE = "<新規追加>";

        /// <summary>
        /// 従業員情報のリストビューの新規追加用行のIDの値
        /// </summary>
        const string EMPLOYERS_NEW_USER_ROW_ID_VALUE = "";

        #endregion

        #region "コンストラクタ"

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public EmployerManageForm()
        {
            InitializeComponent();
        }

        #endregion

        #region "イベント"

        /// <summary>
        /// 登録・更新ボタンをクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegist_Click(object sender, EventArgs e)
        {
            if (lvEmployers.SelectedItems.Count == 0)
            {
                return;
            }
            var id = lvEmployers.SelectedItems[0].Text;

            // 入力検証
            if (validateEmployerInfo(id) == false)
            {
                return;
            }

            var param = new Dictionary<string, object>();
            param["id"] = txtID.Text;
            param["name"] = txtName.Text;
            param["memo"] = txtMemo.Text;
            param["is_disabled"] = cbDisabled.Checked ? 1 : 0;

            if (id == EMPLOYERS_NEW_USER_ROW_ID_VALUE)
            {
                insertEmployerInfo(param);
            }
            else
            {
                updateEmployerInfo(id, param);
            }

            MessageBox.Show("登録しました", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // リストビュー更新
            loadEmployersList();
        }

        /// <summary>
        /// 削除ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvEmployers.SelectedItems.Count == 0)
            {
                return;
            }
            var id = lvEmployers.SelectedItems[0].Text;
            if (id == EMPLOYERS_NEW_USER_ROW_ID_VALUE)
            {
                return;
            }

            if (MessageBox.Show("本当に削除してもよろしいですか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
            {
                return;
            }

            deleteEmployer(id);
            resetInputForm();
            loadEmployersList();
        }

        /// <summary>
        /// フォームロード時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployerManageForm_Load(object sender, EventArgs e)
        {
            initEmployersListViewColumn();
            loadEmployersList();
        }

        /// <summary>
        /// リストビューを選択
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvEmployers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvEmployers.SelectedItems.Count == 0)
            {
                return;
            }
            var id = lvEmployers.SelectedItems[0];
            loadEmployerInfo(id.Text);
        }

        #endregion

        #region "関数"

        /// <summary>
        /// 従業員情報のリストビューを初期化する
        /// </summary>
        private void initEmployersListViewColumn()
        {
            // リストビューのヘッダ設定
            lvEmployers.Columns.Add("ID", 68, HorizontalAlignment.Left);
            lvEmployers.Columns.Add("名前", 180, HorizontalAlignment.Left);
        }

        /// <summary>
        /// 従業員情報をリストビューへ読みだす
        /// </summary>
        private void loadEmployersList()
        {
            lvEmployers.Items.Clear();

            // 新規追加用の行
            lvEmployers.Items.Add(EMPLOYERS_NEW_USER_ROW_ID_VALUE).SubItems.Add(EMPLOYERS_NEW_USER_ROW_NAME_VALUE);

            if (configuration == null)
            {
                MessageBox.Show("configuration is not set", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var db = new SQLiteADOWrapper(configuration.getDBFilePath());
            var dt = db.ExecuteQuery(@"
                SELECT
                    *
                FROM
                    employers
                ORDER BY
                    id");
            if (dt == null)
            {
                return;
            }

            foreach (DataRow dr in dt.Rows)
            {
                var row = lvEmployers.Items.Add(dr["id"].ToString());
                row.SubItems.Add(dr["name"].ToString());
            }

            // 新規追加用の行をアクティブにしておく
            lvEmployers.Items[0].Selected = true;
        }

        /// <summary>
        /// 入力フォームをクリアする
        /// </summary>
        private void resetInputForm()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtMemo.Text = "";
            cbDisabled.Checked = false;

            resetValidateEmployerInfo();
        }

        /// <summary>
        /// リストビューで選択されている従業員情報を入力欄へ表示する
        /// </summary>
        private void loadEmployerInfo(string id)
        {
            resetInputForm();

            if (id == EMPLOYERS_NEW_USER_ROW_ID_VALUE)
            {
                return;
            }

            if (configuration == null)
            {
                MessageBox.Show("configuration is not set", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var db = new SQLiteADOWrapper(configuration.getDBFilePath());

            var param = new Dictionary<string, object> { { "id", id } };
            var dt = db.ExecuteQuery(@"
                SELECT
                    *
                FROM
                    employers
                WHERE
                    id = $id", param);
            if (dt == null)
            {
                return;
            }

            txtID.Text = dt.Rows[0]["id"].ToString();
            txtName.Text = dt.Rows[0]["name"].ToString();
            txtMemo.Text = dt.Rows[0]["memo"].ToString();
            if ((long)dt.Rows[0]["is_disabled"] == 1)
            {
                cbDisabled.Checked = true;
            }
        }

        /// <summary>
        /// 入力フォームの内容を登録する
        /// </summary>
        /// <param name="param"></param>
        private void insertEmployerInfo(Dictionary<string, object> param)
        {
            if (configuration == null)
            {
                MessageBox.Show("configuration is not set", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var db = new SQLiteADOWrapper(configuration.getDBFilePath());
            db.ExecuteNonQuery(@"
                INSERT INTO employers (
                     id
                    ,name
                    ,memo
                    ,is_disabled
                    ,created_at
                    ,updated_at
                ) VALUES (
                     $id
                    ,$name
                    ,$memo
                    ,$is_disabled
                    ,datetime('now', 'localtime')
                    ,datetime('now', 'localtime')
                )
            ", param);
        }

        /// <summary>
        /// 入力フォームの内容で更新する
        /// </summary>
        /// <param name="param"></param>
        private void updateEmployerInfo(string id, Dictionary<string, object> param)
        {
            if (configuration == null)
            {
                MessageBox.Show("configuration is not set", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            param.Add("old_id", id);
            var db = new SQLiteADOWrapper(configuration.getDBFilePath());
            db.ExecuteNonQuery(@"
                UPDATE employers
                SET
                     id = $id
                    ,name = $name
                    ,memo = $memo
                    ,is_disabled = $is_disabled
                    ,updated_at = datetime('now', 'localtime')
                WHERE
                    id = $old_id
            ", param);
        }

        /// <summary>
        /// 登録済みの従業員IDならtrue
        /// </summary>
        /// <param name="id"></param>
        private bool isExistEmployerID(string id)
        {
            if (configuration == null)
            {
                MessageBox.Show("configuration is not set", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            var param = new Dictionary<string, object>() { { "id", id } };
            var db = new SQLiteADOWrapper(configuration.getDBFilePath());
            var dt = db.ExecuteQuery(@"
                SELECT
                    *
                FROM
                    employers
                WHERE
                    id = $id", param);
            if (dt == null)
            {
                return true;
            }

            if (dt.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 従業員IDの検証
        /// </summary>
        /// <param name="current_id"></param>
        /// <returns></returns>
        private bool validateEmployerID(string current_id)
        {
            // ID未入力はエラー
            if (txtID.Text == "")
            {
                epEmployerInfo.SetError(txtID, "従業員IDは必ず入力してください");
                return false;
            }

            // ID登録済みならエラー: 新規の場合
            if (current_id == EMPLOYERS_NEW_USER_ROW_ID_VALUE && isExistEmployerID(txtID.Text))
            {
                epEmployerInfo.SetError(txtID, "すでに登録されている従業員IDです。");
                return false;
            }
            // ID登録済みならエラー: 更新の場合(ID変更の場合)
            if (current_id != EMPLOYERS_NEW_USER_ROW_ID_VALUE &&
                current_id != txtID.Text &&
                isExistEmployerID(txtID.Text))
            {
                epEmployerInfo.SetError(txtID, "すでに登録されている従業員IDです。");
                return false;
            }
            return true;
        }

        /// <summary>
        /// 従業員名の検証
        /// </summary>
        /// <param name="current_id"></param>
        /// <returns></returns>
        private bool validateEmployerName()
        {
            // 名前未入力はエラー
            if (txtName.Text == "")
            {
                epEmployerInfo.SetError(txtName, "名前は必ず入力してください");
                return false;
            }
            return true;
        }

        /// <summary>
        /// エラー表示をリセットする
        /// </summary>
        private void resetValidateEmployerInfo()
        {
            epEmployerInfo.SetError(txtID, null);
            epEmployerInfo.SetError(txtName, null);
        }

        /// <summary>
        /// 従業員入力フォームの検証
        /// </summary>
        /// <param name="current_id"></param>
        /// <returns></returns>
        private bool validateEmployerInfo(string current_id)
        {
            // 一度クリア
            resetValidateEmployerInfo();

            var ret = true;

            // 従業員ID
            if (validateEmployerID(current_id) == false)
            {
                ret = false;
            }

            // 名前
            if (validateEmployerName() == false)
            {
                ret = false;
            }

            return ret;
        }

        /// <summary>
        /// 選択中の従業員を削除する
        /// </summary>
        /// <param name="id"></param>
        private void deleteEmployer(string id)
        {
            if (id == EMPLOYERS_NEW_USER_ROW_ID_VALUE)
            {
                return;
            }

            if (configuration == null)
            {
                MessageBox.Show("configuration is not set", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var db = new SQLiteADOWrapper(configuration.getDBFilePath());

            var param = new Dictionary<string, object> { { "id", id } };
            db.ExecuteNonQuery(@"
                DELETE
                FROM
                    employers
                WHERE
                    id = $id", param);
        }


        #endregion

    }
}
