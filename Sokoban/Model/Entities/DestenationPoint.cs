using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    public class DestenationPoint : IGameEntity
    {
        public string ImageFileName => "destenation.bmp";
        public int DrawingPriority => 3; public ICommand Act(int x, int y)
        {
            return new Idle();
        }
    }
}
