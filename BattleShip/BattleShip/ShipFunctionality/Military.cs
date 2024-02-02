using BattleShip.ShipEnum;

namespace BattleShip
{
    public class Military : Ship
    {
        public Military(int length)
            : base()
        {
            this.Length = length;
        }

        public Military(Speed speed, int length)
        {
            this.Speed = speed;
            this.Length = length;
        }

        public override Speed Speed { get; set; }

        public override int Length { get; set; }

    }
}
