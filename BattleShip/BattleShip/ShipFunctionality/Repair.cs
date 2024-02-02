using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Repair<T> : IRepair<T>
        where T : IShip
    {
        private readonly int _range = 2;

        bool IRepair<T>.Repair()
        {
            throw new NotImplementedException();
        }
    }
}
