using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Shoot<T> : IShoot<T>
        where T : IShip
    {
        private readonly int _range = 3;

        bool IShoot<T>.Shoot()
        {
            throw new NotImplementedException();
        }
    }
}
