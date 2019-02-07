using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    public interface IGameEntity
    {
        string ImageFileName { get; }
        int DrawingPriority { get; }
        ICommand Act(int x, int y);
    }
}
