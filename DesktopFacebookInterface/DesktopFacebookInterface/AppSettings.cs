using System;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace DesktopFacebookInterface
{
    public class AppSettings
    {
        public Point m_WindowLocation;
        public Size m_WindowSize;
        public bool m_RememberUser;
        public string m_UserAccessToken;
        private const string k_DefaultFileName = "appSettings.xml";
        private static readonly string sr_DefaultFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private AppSettings()
        {
            m_WindowLocation = new Point(0, 0);
            m_WindowSize = new Size(0, 0);
            m_RememberUser = false;
            m_UserAccessToken = null;
        }

        public static AppSettings LoadFile()
        {
            AppSettings appSettings;
            string filePath = string.Format(@"{0}\\{1}", sr_DefaultFolder, k_DefaultFileName);

            if (File.Exists(filePath))
            {
                using (Stream stream = new FileStream(filePath, FileMode.Open))
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

        public void SaveFile()
        {
            string filePath = string.Format(@"{0}\\{1}", sr_DefaultFolder, k_DefaultFileName);
            FileMode fileMode = File.Exists(filePath) ? FileMode.Truncate : FileMode.Create;

            using (Stream stream = new FileStream(filePath, fileMode))
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(stream, this);
            }
        }
    }
}
