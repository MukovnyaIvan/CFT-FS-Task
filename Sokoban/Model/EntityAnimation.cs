using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sokoban.Model
{
    public class EntityAnimation
    {
        public ICommand Command;
        public IGameEntity Entity;
        public Point Location;
        public Point Destenation;
    }
}
