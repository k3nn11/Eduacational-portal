using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Field
{
    public interface IFieldPlacement
    {
        void AddShipInField(Ship ship, Direction direction, Cell cell);
    }
}
