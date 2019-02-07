using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    public class Wall : IGameEntity
    {
        public string ImageFileName => "wall.bmp";
        public int DrawingPriority => 2;
        public ICommand Act(int x, int y)
        {
            return new Idle();
        }
    }
}
