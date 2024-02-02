using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public interface IRepairAndShoot<T> : IShoot<T>, IRepair<T> 
        where T : IShip
    {
    }
}
