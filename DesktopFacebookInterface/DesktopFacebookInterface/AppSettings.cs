using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DesktopFacebookInterface
{
    public class AppSettings
    {
        public Point WindowLocation { get; set; }
        public Size WindowSize { get; set; }
        public bool RememberUser { get; set; }
        public string UserAccessToken { get; set; }

        readonly static string defaultFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private AppSettings()
        {
            WindowLocation = new Point(900, 500);
            WindowSize = new Size(700, 400);
            RememberUser = false;
            UserAccessToken = null;
        }

        public void SaveFile()
        {
            string path = String.Format(@"{0}\appSettings.xml", defaultFolder);
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
            string path = String.Format(@"{0}\\appSettings.xml", defaultFolder);
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
