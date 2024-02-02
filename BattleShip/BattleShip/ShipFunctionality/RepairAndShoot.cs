using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class RepairAndShoot<T> : IRepairAndShoot<T>
        where T : IShip
    {
        public bool Repair()
        {
            throw new NotImplementedException();
        }

        public bool Shoot()
        {
            throw new NotImplementedException();
        }
    }
}
