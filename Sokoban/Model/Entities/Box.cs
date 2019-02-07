using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    public class Box : IGameEntity
    {
        public string ImageFileName => "box.bmp";
        public int DrawingPriority => 1;
        public bool isSolid { get; set; }
        public ICommand Act(int x, int y)
        {
            return new Idle();
        }
    }
}
