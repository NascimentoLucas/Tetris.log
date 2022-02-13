using System;
using System.IO;

namespace GazeusGamesEtapaTeste.Data
{
    public class Data
    {
        public static void Save(string path, string txt)
        {
            string folderPath = Path.GetDirectoryName(path);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(txt);
            }
        }

        public static string Open(string path)
        {
            string result = string.Empty;
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s;
                    while ((s = sr.ReadLine()) != null)
                    {
                        result += s;
                    }
                }
            }

            return result;
        }
    }
}
