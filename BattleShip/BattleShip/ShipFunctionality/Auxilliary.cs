using BattleShip.ShipEnum;

namespace BattleShip
{
    public class Auxilliary : Ship
    {
        public Auxilliary(int length)
            : base()
        {
            this.Length = length;
        }

        public Auxilliary(Speed speed, int length)
        {
            this.Speed = speed;
            this.Length = length;
        }

        public override Speed Speed { get; set; }

        public override int Length { get; set; }
    }
}
