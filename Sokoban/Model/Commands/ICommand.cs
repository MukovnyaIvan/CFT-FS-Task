using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Model
{
    public interface ICommand
    {
        int DeltaX { get; }
        int DeltaY { get; }
    }
}
