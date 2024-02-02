using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Field
{
    public class ShipAccess : IShipAccess
    {
        public ShipAccess(IFieldPlacement fieldPlacement) 
        {
            this.FieldPlacement = fieldPlacement;
        }

        private IFieldPlacement FieldPlacement { get; set; }

        // instantiate in a loop.
        private IQuadrant Quadrant { get; set; }

        private IShip[,,] Ships { get; set; }

        public IShip this[int i, int j, int k]
        {
            get
            {
                return this.Ships[i, j, k];
            }

            set
            {
                this.Ships[i, j, k] = value;
            }
        }

        public void GetShipArray()
        {
            throw new NotImplementedException();
        }
    }
}
