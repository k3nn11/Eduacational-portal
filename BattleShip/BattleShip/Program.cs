using System;
using BattleShip.Field;

namespace BattleShip
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Ship militray = new Military(3);
            PlayingField playingField = new PlayingField(5, 5);
            playingField.CreateField();
            playingField.OccupyCell(2, 4, militray);
            playingField.OccupyCell(0, 3, militray);

            Cell cell = new Cell(4, 3);
            FieldPlacement fieldPlacement = new FieldPlacement(playingField);
            fieldPlacement.AddShipInField(militray, Direction.North, cell);
            string name = playingField[2, 4].Ship.Length.ToString();
            Console.WriteLine(name);

        }
    }
}
