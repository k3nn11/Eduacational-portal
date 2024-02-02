using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Field
{
    public interface IQuadrant
    {
        Cell[,] GetQuadrant(Cell[,] cells);
    }
}
