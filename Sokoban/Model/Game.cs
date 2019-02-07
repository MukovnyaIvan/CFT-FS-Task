using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban.Model
{
    public static class Game
    {
        public static IGameEntity[,] Map;
        public static IGameEntity[,] PrevMap;
        public static int Time;
        public static int MovesCount;
        public static bool IsOver;
        public static bool LevelCleared;
        public static int BoxCount;
        public static Keys KeyPressed;
        public static int MapWidth => Map.GetLength(0);
        public static int MapHeight => Map.GetLength(1);

        public static bool IsPointInBorders(int x, int y)
        {
            return 0 <= x && x < MapWidth
                && 0 <= y && y < MapHeight;
        }

        public static bool WillColideWithWall(int x, int y, ICommand command)
        {
            return Map[x + command.DeltaX, y + command.DeltaY] is Wall;
        }

        public static bool MoveBox(int x, int y, ICommand move)
        {
            var newX = x + move.DeltaX;
            var newY = y + move.DeltaY;
            var WillColideWithBox = Map[x + move.DeltaX, y + move.DeltaY] is Box;

            if (IsPointInBorders(newX, newY) && !WillColideWithWall(x,y,move) && !WillColideWithBox)
            {
                if (Map[newX, newY] is DestenationPoint)
                {
                    (Map[x, y] as Box).isSolid = true;
                    Move(x, y, newX, newY);
                    if (--BoxCount == 0)
                        LevelCleared = true;
                    return true;
                }
                if (!(Map[x, y] as Box).isSolid)
                {
                    Move(x, y, newX, newY);
                    return true;
                }
            }
            return false;
        }

        public static void Save()
        {
            Array.Copy(Map, PrevMap, Map.Length);
        }

        private static void Move(int x, int y, int newX, int newY)
        {
            Map[newX, newY] = Map[x, y];
            Map[x, y] = null;
        }
    }
}
