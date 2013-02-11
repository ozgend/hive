using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace L4D2Launcher.Helper
{
    public class DataHelper
    {

        public static List<string> LoadMaps()
        {
            try
            {   
                string filename = Path.GetFullPath(string.Format("{0}\\launchermaps.list", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)));
                string json = File.ReadAllText(filename, Encoding.UTF8);
                List<string> list = Deserialize<List<string>>(json);
                return list;
            }
            catch
            {
                return new List<string>();
            }

        }

        public static string Serialize<T>(T obj)
        {
            DataContractJsonSerializer serializer =
                  new DataContractJsonSerializer(obj.GetType());
            using (MemoryStream ms = new MemoryStream())
            {
                serializer.WriteObject(ms, obj);
                string retVal = Encoding.Default.GetString(ms.ToArray());
                return retVal;
            }
        }

        public static T Deserialize<T>(string json)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                DataContractJsonSerializer serializer =
                      new DataContractJsonSerializer(typeof(T));
                T obj = (T)serializer.ReadObject(ms);
                ms.Close();
                return obj;
            }
        }

    }
}
