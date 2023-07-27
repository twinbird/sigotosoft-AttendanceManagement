using System.Configuration;
using System.Reflection;

namespace AttendanceManagement
{
    /// <summary>
    /// 設定ファイル管理
    /// </summary>
    public class ConfigWrapper
    {
        /// <summary>
        /// データベースファイルへのファイルパスが記述されている設定ファイル(App.config)のキー
        /// </summary>
        const string mAppSettingDatabaseFilePathKey = "DatabaseFilePath";
        
        /// <summary>
        /// デフォルトのデータベースディレクトリ名(%USERPROFILE%\AppData\Local以下のディレクトリ)
        /// </summary>
        const string mDefaultDatabaseFileDirName = "sigoto_soft";

        /// <summary>
        /// デフォルトのデータベースディレクトリ名(%USERPROFILE%\AppData\Local\sigoto_soft以下のディレクトリ)
        /// </summary>
        const string mDefaultDatabaseFileDirProjectName = "AttendanceManagement";

        /// <summary>
        /// データベースファイルへのパス
        /// </summary>
        string mDatabaseFilePath = "";

        /// <summary>
        /// デフォルトのデータベースファイル名
        /// </summary>
        string mDefaultDatabaseFileName = "";

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="databaseFileName">このアプリケーションのデフォルトデータベースファイル名</param>
        public ConfigWrapper(string databaseFileName)
        {
            mDefaultDatabaseFileName = databaseFileName;
        }

        /// <summary>
        /// データベースファイルへのパスを取得する
        /// </summary>
        /// <returns></returns>
        public string getDBFilePath()
        {
            if (mDatabaseFilePath != "")
            {
                return mDatabaseFilePath;
            }

            var dbpath = ConfigurationManager.AppSettings[mAppSettingDatabaseFilePathKey];
            if (dbpath == null || dbpath == "")
            {
                dbpath = initializeDBFilePath();
            }

            mDatabaseFilePath = dbpath;

            return mDatabaseFilePath;
        }

        /// <summary>
        /// データベースファイルへのパス設定を初期化する
        /// </summary>
        /// <returns></returns>
        private string initializeDBFilePath()
        {
            // データベースファイルの保存先ディレクトリを作成
            var defaultDirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                mDefaultDatabaseFileDirName,
                mDefaultDatabaseFileDirProjectName);
            Directory.CreateDirectory(defaultDirPath);

            // データベースファイルへのパスを作成
            var dbpath = Path.Combine(defaultDirPath, mDefaultDatabaseFileName);

            // 設定ファイルへ保存
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[mAppSettingDatabaseFilePathKey].Value = dbpath;
            config.Save();

            return dbpath;
        }
    }
}
