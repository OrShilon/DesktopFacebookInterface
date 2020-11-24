using System;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace DesktopFacebookInterface
{
    public class AppSettings
    {
        public Point m_WindowLocation { get; set; }
        public Size m_WindowSize { get; set; }
        public bool m_RememberUser { get; set; }
        public string m_UserAccessToken { get; set; }

        private readonly static string r_defaultFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private const string k_defaultFileName = "appSettings.xml";

        private AppSettings()
        {
            m_WindowLocation = new Point(0, 0);
            m_WindowSize = new Size(0, 0);
            m_RememberUser = false;
            m_UserAccessToken = null;
        }

        public void SaveFile()
        {
            string path = String.Format(@"{0}\\{1}", r_defaultFolder, k_defaultFileName);
            FileMode fileModeToUse = File.Exists(path) ? FileMode.Truncate : FileMode.Create;

            using (Stream stream = new FileStream(path, fileModeToUse))
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(stream, this);
            }
        }

        public static AppSettings LoadFile()
        {
            AppSettings appSettings;
            string path = String.Format(@"{0}\\{1}", r_defaultFolder, k_defaultFileName);
            if (File.Exists(path))
            {
                using (Stream stream = new FileStream(path, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                    appSettings = serializer.Deserialize(stream) as AppSettings;
                }
            }
            else
            {
                appSettings = new AppSettings();
            }

            return appSettings;
        }
    }
}
