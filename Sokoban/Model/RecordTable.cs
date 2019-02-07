using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    public static class RecordTable
    {
        public static string GetTopFive()
        {
            List<string> result = new List<string>(5);

            try
            {
                StreamReader reader = new StreamReader("RecordTable.txt");
                var line = reader.ReadLine();

                while (result.Count !=5 && line != null)
                {
                    result.Add(line);
                    line = reader.ReadLine();
                }

                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return MakeStringFronList(result);
        }

        public static void AddRecord(string name, int score)
        {
            if (name == "")
                return;

            try
            {
                StreamWriter writer = new System.IO.StreamWriter("RecordTable.txt", true);
                writer.WriteLine(name + ":   " + score);
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        private static string MakeStringFronList(List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var str in list)
            {
                sb.Append(str + "\n");
            }
            return sb.ToString();
        }
    }
}
