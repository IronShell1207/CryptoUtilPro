using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoUtilPro
{

    public class SettingsK
    {
        public string ThemeLast { get; set; }
        public string IndexLast { get; set; }
    }
    public class CryptKey
    {
        public string NameTu { get; set; }
        public string CryptyKey { get; set; }
    }

    class JsonWorker
    {
        private static List<String> filesTO;
        private static List<CryptKey> cryKeys;
        public static string SetsPath
        {
            get
            {
                return DirCry + "Settings.json";
            }
        }
        public static List<String> FilesTo
        {
            get
            {
                if (filesTO != null)
                {
                    return filesTO;
                }
                filesTO = new List<String> { };
                return filesTO;
            }
            set { filesTO = value; }
        }
        public static string DirCry
        {
            get
            {
                string dir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\CryptCache\";
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                return dir;
            }
        }
        public static List<CryptKey> CryKeys
        {
            get
            {
                if (cryKeys == null)
                {
                    string path = DirCry + "jsnCry.json";
                    if (File.Exists(path))
                        cryKeys = ReadJsnFile(path);
                    else cryKeys = new List<CryptKey> { };
                }
                return cryKeys;
            }
        }
        #region writers/readers json
        public static List<CryptKey> ReadJsnFile(string path)
        {
            List<CryptKey> stations = new List<CryptKey> { };
            using (StreamReader jsReader = new StreamReader(path))
            {
                CryptKey station = new CryptKey();

                JsonReader json = new JsonTextReader(jsReader);
                JsonSerializer jsonSerializer = new JsonSerializer();
                var favoriteList = jsonSerializer.Deserialize<List<CryptKey>>(json);
                return favoriteList;
            }
        }
        public static void CreateJsnFile(List<CryptKey> listkeys, string path)
        {
            using (StreamWriter sw = new StreamWriter(path, false))
            {
                JsonWriter jsonWriter = new JsonTextWriter(sw);
                JsonSerializer jsnS = new JsonSerializer();
                jsnS.Serialize(jsonWriter, listkeys);
            }
        }
        #endregion

    }
}
