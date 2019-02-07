using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban.Model
{
    public class Player : IGameEntity
    {
        public string ImageFileName => "player.bmp";
        public int DrawingPriority => 0;

        public ICommand Act(int x, int y)
        {
            var command = GetPlayerMovement(Game.KeyPressed);

            if (IsMovementCorrect(x, y, command))
            {
                if (Game.Map[x + command.DeltaX, y + command.DeltaY] is Box)
                {
                    if (Game.MoveBox(x + command.DeltaX, y + command.DeltaY, command))
                    {
                        Game.MovesCount++;
                        return command;
                    }
                    return new Idle();
                } 
                if (command.DeltaX !=0 || command.DeltaY !=0)
                Game.MovesCount++;
                return command;
            }

            return new Idle();
        }


        private ICommand GetPlayerMovement(Keys keyPressed)
        {
            switch (keyPressed)
            {
                case Keys.Up:
                    {
                        return new Move(0, -1);
                    }
                case Keys.Down:
                    {
                        return new Move(0, 1);
                    }
                case Keys.Left:
                    {
                        return new Move(-1, 0);
                    }
                case Keys.Right:
                    {
                        return new Move(1, 0);
                    }
            }
            return new Idle();
        }

        private bool IsMovementCorrect(int xPos, int yPos, ICommand command)
        {
            var newX = xPos + command.DeltaX;
            var newY = yPos + command.DeltaY;

            var isBox = Game.Map[newX, newY] is Box;

            if (Game.IsPointInBorders(newX, newY) && !Game.WillColideWithWall(xPos, yPos, command) && !(Game.Map[newX, newY] is DestenationPoint)) {
                if (!isBox)
                    return true;
                if (Game.Map[newX + command.DeltaX, newY + command.DeltaY] is null 
                    || Game.Map[newX + command.DeltaX, newY + command.DeltaY] is DestenationPoint)
                    return true;
            }
            return false;
        }
    }
}
