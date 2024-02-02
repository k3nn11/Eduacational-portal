namespace BattleShip
{
    public interface IRepair<T>
        where T : IShip
    {
        bool Repair();
    }
}
