using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace DesktopFacebookInterface
{
    public class ContestsXmlSerialization
    {
        public readonly List<ContestLogic> r_ContestsList;
        private readonly static string r_DefaultFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        private const string k_DefaultFileName = "ContestsFile.xml";

        public ContestsXmlSerialization(List<ContestLogic> i_ContestsList)
        {
            r_ContestsList = i_ContestsList;
        }

        public void SaveFile()
        {
            string path = String.Format(@"{0}\\{1}", r_DefaultFolder, k_DefaultFileName);
            FileMode fileModeToUse = File.Exists(path) ? FileMode.Truncate : FileMode.Create;

            using (Stream stream = new FileStream(path, fileModeToUse))
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(stream, this);
            }
        }

        public static ContestsXmlSerialization LoadFile()
        {
            ContestsXmlSerialization contestsFile = null;
            string path = String.Format(@"{0}\\{1}", r_DefaultFolder, k_DefaultFileName);

            if (File.Exists(path))
            {
                using (Stream stream = new FileStream(path, FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ContestsXmlSerialization));
                    contestsFile = serializer.Deserialize(stream) as ContestsXmlSerialization;
                }
            }

            return contestsFile;
        }
    }
}
