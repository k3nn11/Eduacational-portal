using BattleShip.ShipEnum;

namespace BattleShip
{
    public interface IShip
    {
        Speed Speed { get; set; }

        int Length { get; set; }
    }
}
