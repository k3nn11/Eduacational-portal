using System;
using BattleShip.ShipEnum;
using BattleShip.ShipFunctionality;

namespace BattleShip
{
    public abstract class Ship : BaseEntity, IShip, IEquatable<Ship>
    {
        public Ship()
        {
            this.Speed = Speed._S2;
        }

        public abstract Speed Speed { get; set; }

        public abstract int Length { get; set; }

        public static bool operator ==(Ship left, Ship right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }
            if (ReferenceEquals(right, null) || ReferenceEquals(null, left))
            {
                return false;
            }
            return left.Equals(right);
        }

        public static bool operator !=(Ship left, Ship right)
        {
            return !(left == right);
        }

        public bool Equals(Ship other)
        {
            return other != null && this.Speed == other.Speed && this.Length == other.Length;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
