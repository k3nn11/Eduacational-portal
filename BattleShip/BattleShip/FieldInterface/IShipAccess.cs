using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Field
{
    public interface IShipAccess
    {
        IShip this[int i, int j, int k] { get; set; }

        void GetShipArray();

    }
}
