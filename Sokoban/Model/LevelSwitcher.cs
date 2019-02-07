using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    class LevelSwitcher
    {
        public static int CurrentLevel { get; private set; }

        public static string GetNextLevel()
        {
            if (CurrentLevel == 0)
                CurrentLevel = 1;
            try
            {
                StringBuilder builder = new StringBuilder();
                string currentFile = builder.Append("Level_").Append(CurrentLevel).Append(".txt").ToString();
                builder.Clear();
                Console.WriteLine(currentFile);
                var path = @"LevelPack\" + currentFile;
                StreamReader reader = new StreamReader(path);
                var line = reader.ReadLine();

                while (line != null)
                {
                    builder.Append(line);
                    builder.Append('\n');
                    line = reader.ReadLine();
                }
                CurrentLevel++;
                reader.Close();
                return builder.ToString();
            }
            catch (Exception e)
            {
                Game.IsOver = true;
            }
            return null;
        }
    }
}
