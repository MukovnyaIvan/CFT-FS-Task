using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    public class LevelCreator
    {
        public static IGameEntity[,] CreateMap(string map, string separator = "\n")
        {
            var rows = map.Split(new[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            var width = GetMapWidth(rows);
            var result = new IGameEntity[width, rows.Length];
            var builder = new StringBuilder();

            for (var x = 0; x < width; x++)
                for (var y = 0; y < rows.Length; y++)
                {
                    if (x < rows[y].Length)
                    {
                        result[x, y] = CreateObjectWithSymbol(rows[y][x]);
                        continue;
                    }
                    result[x, y] = null;
                }

            Game.LevelCleared = false;
            return result;
        }

        private static int GetMapWidth(string[] map)
        {
            var maxRowLength = 0;

            foreach (var row in map)
            {
                if (row.Length > maxRowLength)
                    maxRowLength = row.Length;
            }
            return maxRowLength;
        }

        private static IGameEntity CreateObjectWithSymbol(char symbol)
        {
            switch (symbol)
            {
                case 'P':
                    return new Player();
                case 'W':
                    return new Wall();
                case 'B':
                    {
                        Game.BoxCount++;
                        return new Box();
                    }
                case 'D':
                    return new DestenationPoint();
                case ' ':
                    return null;
                default:
                    throw new Exception($"wrong character for map object: {symbol}");
            }

        }
    }
}
