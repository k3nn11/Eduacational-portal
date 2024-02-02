using BattleShip;
using BattleShip.ShipEnum;

namespace BattleShip
{
    public class Mixed : Ship
    {
        public Mixed(int length) 
            : base()
        {
            this.Length = length;
        }

        public Mixed(Speed speed, int length)
        {
            this.Speed = speed;
            this.Length = length;
        }

        public override Speed Speed { get; set; }

        public override int Length { get; set; }
    }
}
