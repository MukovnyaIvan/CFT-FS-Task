using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban.Model
{
    public class GameState
    {
        public const int ElementSize = 26;
        public List<EntityAnimation> Animations = new List<EntityAnimation>();
        private Point VIPLocation;

        public void BeginAct()
        {
            Animations.Clear();
            AddPriorityCommand();

            for (var x = 0; x < Game.MapWidth; x++)
                for (var y = 0; y < Game.MapHeight; y++)
                {
                    var entity = Game.Map[x, y];
                    if (entity == null || (VIPLocation.X == x && VIPLocation.Y == y))
                        continue;

                    var command = entity.Act(x, y);

                    if (!Game.IsPointInBorders(x + command.DeltaX, y + command.DeltaY))
                        throw new Exception($"{entity.GetType()} falls out of the game field");

                    var animation = new EntityAnimation
                    {
                        Command = command,
                        Entity = entity,
                        Location = new Point(x * ElementSize, y * ElementSize),
                        Destenation = new Point(x + command.DeltaX, y + command.DeltaY)
                    };
                    Animations.Add(animation);
                }

           Animations = Animations.OrderByDescending(z => z.Entity.DrawingPriority).ToList();
        }

        public void EndAct()
        {
            foreach (var action in Animations)
            {
                if (action.Destenation.X != action.Destenation.X - action.Command.DeltaX || action.Destenation.Y != action.Destenation.Y - action.Command.DeltaY)
                {
                    Game.Map[action.Destenation.X, action.Destenation.Y] = Game.Map[action.Destenation.X - action.Command.DeltaX, action.Destenation.Y - action.Command.DeltaY];
                    Game.Map[action.Destenation.X - action.Command.DeltaX, action.Destenation.Y - action.Command.DeltaY] = null;
                }
            }
        }

        public void AddPriorityCommand()
        {
            for (var x = 0; x < Game.MapWidth; x++)
                for (var y = 0; y < Game.MapHeight; y++)
                {
                    if (!(Game.Map[x, y] is Player))
                        continue;

                    VIPLocation = new Point(x, y);
                    var command = Game.Map[x, y].Act(x, y);
                    var animation = new EntityAnimation
                    {
                        Command = command,
                        Entity = Game.Map[x, y],
                        Location = new Point(x * ElementSize, y * ElementSize),
                        Destenation = new Point(x + command.DeltaX, y + command.DeltaY)
                    };
                    Animations.Add(animation);
                }
            return;
        }
    }
}
