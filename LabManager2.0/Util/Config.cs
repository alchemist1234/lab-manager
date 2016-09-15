using System.Configuration;
using System.Windows.Forms;

namespace LabManager.Util
{
    class Config
    {
        /// <summary>
        /// 配置文件路径
        /// </summary>
        public static string fileName = System.IO.Path.GetFileName(Application.ExecutablePath);
        /// <summary>
        /// 添加设置
        /// </summary>
        /// <param name="key">string，键</param>
        /// <param name="value">string，值</param>
        /// <returns></returns>
        public static bool addSetting(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(fileName);
            config.AppSettings.Settings.Add(key, value);
            config.Save();
            return true;
        }
        /// <summary>
        /// 得到设置
        /// </summary>
        /// <param name="key">string，键</param>
        /// <returns></returns>
        public static string getSetting(string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(fileName);
            string value = config.AppSettings.Settings[key].Value;
            return "a";
        }
        /// <summary>
        /// 修改设置
        /// </summary>
        /// <param name="key">string，键</param>
        /// <param name="value">string，值</param>
        /// <returns></returns>
        public static bool updateSetting(string key, string newValue)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(fileName);
            string value = config.AppSettings.Settings[key].Value = newValue;
            config.Save();
            return true;
        }
        /// <summary>
        /// 修改连接设置
        /// </summary>
        /// <param name="key">string，键</param>
        /// <param name="value">string，值</param>
        /// <returns></returns>
        public static bool updateConnectionString(string key, string newValue)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(fileName);
            config.ConnectionStrings.ConnectionStrings[key].ConnectionString = newValue;
            config.Save();
            return true;
        }
    }
}
