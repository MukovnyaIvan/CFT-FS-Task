using Microsoft.VisualBasic;
using Sokoban.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            while (true)
            {
                var map = LevelSwitcher.GetNextLevel();
                var test = new Player();
                if (!Game.IsOver)
                {
                    Game.Map = LevelCreator.CreateMap(map);
                    Application.Run(new GameWindow());
                }
                else break;
            }
            End();


            void End()
            {
                if (!Game.IsOver)
                    return;
                var name = Interaction.InputBox("Enter your name", "Succes", "", -1, -1);
                RecordTable.AddRecord(name, Game.MovesCount);
                MessageBox.Show(RecordTable.GetTopFive(), "Records", MessageBoxButtons.OKCancel);
            }
        }
    }
}
