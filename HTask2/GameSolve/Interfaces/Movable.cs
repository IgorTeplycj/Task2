using HTask2.GameSolve.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTask2.GameSolve.Interfaces
{
    public interface Movable
    {
        Vector CurrentVector { get; set; }
        void Set(Vector newV);
    }
}
