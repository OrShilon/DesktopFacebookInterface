using System;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace DesktopFacebookInterface
{
    public sealed class AppSettings
    {
        private static AppSettings m_AppSettings = null;
        private static readonly object sr_Lock = new object();
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
            if (m_AppSettings == null)
            {
                string filePath = string.Format(@"{0}\\{1}", sr_DefaultFolder, k_DefaultFileName);
                lock (sr_Lock)
                {
                    if (File.Exists(filePath))
                    {
                        using (Stream stream = new FileStream(filePath, FileMode.Open))
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                            m_AppSettings = serializer.Deserialize(stream) as AppSettings;
                        }
                    }
                    else
                    {
                        m_AppSettings = new AppSettings();
                        SaveFile();
                    }
                }
            }
            return m_AppSettings;
        }

        public static void SaveFile()
        {
            if (m_AppSettings != null)
            {
                string filePath = string.Format(@"{0}\\{1}", sr_DefaultFolder, k_DefaultFileName);
                FileMode fileMode = File.Exists(filePath) ? FileMode.Truncate : FileMode.Create;

                using (Stream stream = new FileStream(filePath, fileMode))
                {
                    XmlSerializer serializer = new XmlSerializer(m_AppSettings.GetType());
                    serializer.Serialize(stream, m_AppSettings);
                }
            }
        }
    }
}
