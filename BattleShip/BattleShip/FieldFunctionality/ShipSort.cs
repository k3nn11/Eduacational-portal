using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Field
{
    public class ShipSort : IShipSort
    {
        private List<IShip> ships = new List<IShip>();

        public ShipSort(IFieldPlacement fieldPlacement) 
        {
            this.FieldPlacement = fieldPlacement;
        }

        private IFieldPlacement FieldPlacement { get; set; }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        public string DisplayShip()
        {
            throw new NotImplementedException();
        }
    }
}
