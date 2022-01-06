using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MookTRPG
{
    public static class IOHelper
    {


        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="pObject">存档对象</param>
        public static void SaveData(string fileName, object pObject)
        {
            string saveJsonStr = JsonConvert.SerializeObject(pObject);
            Stream s = new FileStream(fileName, FileMode.Create);
            UTF8Encoding utf8 = new UTF8Encoding(false);
            StreamWriter streamWriter = new StreamWriter(s, utf8);
            streamWriter.Write(saveJsonStr);
            streamWriter.Close();
            s.Close();
        }

        /// <summary>
        /// 读取List数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<T> LoadListData<T>(string fileName)
        {
            Stream s = new FileStream(fileName, FileMode.Open);
            UTF8Encoding utf8 = new UTF8Encoding(false);
            StreamReader streamReader = new StreamReader(s, utf8);
            string data = streamReader.ReadToEnd();
            s.Close();
            streamReader.Close();
            return JsonConvert.DeserializeObject<List<T>>(data);
        }
    }
}
