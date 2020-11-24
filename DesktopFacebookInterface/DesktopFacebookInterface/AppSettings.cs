﻿using System;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace DesktopFacebookInterface
{
    public class AppSettings
    {
        public Point WindowLocation { get; set; }
        public Size WindowSize { get; set; }
        public bool RememberUser { get; set; }
        public string UserAccessToken { get; set; }

        private readonly static string defaultFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private readonly static string defaultFileName = "appSettings.xml";

        private AppSettings()
        {
            WindowLocation = new Point(0, 0);
            WindowSize = new Size(0, 0);
            RememberUser = false;
            UserAccessToken = null;
        }

        public void SaveFile()
        {
            string path = String.Format(@"{0}\\{1}", defaultFolder, defaultFileName);
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
            string path = String.Format(@"{0}\\{1}", defaultFolder, defaultFileName);
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
