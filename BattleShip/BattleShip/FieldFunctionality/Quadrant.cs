using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Field
{
    public class Quadrant : IQuadrant
    {
        private PlayingField Field { get; set; }

        public Quadrant(PlayingField field)
        {
            this.Field = field;
        }

        public Cell[,] GetQuadrant(Cell[,] cells)
        {
            throw new NotImplementedException();
        }
    }
}
