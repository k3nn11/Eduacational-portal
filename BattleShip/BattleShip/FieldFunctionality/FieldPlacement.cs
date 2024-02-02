using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Field
{
    public class FieldPlacement : IFieldPlacement
    {
        public FieldPlacement(PlayingField field)
        {
            this.Field = field;
        }

        private PlayingField Field { get; }

        public void AddShipInField(Ship ship, Direction direction, Cell cell)
        {
            var shipLength = ship.Length;
            int xModule = cell.X;
            int yModule = cell.Y;
            Cell[,] occupiedCells = this.GetOccupiedCells(this.Field.GetCells());
            Cell cell1;
            bool check = false;
            if (direction == Direction.North)
            {
                for (int i = 0; i < shipLength; i++)
                {
                    cell1 = this.Field.GetCell(yModule, xModule);
                    check = this.CellCompare(cell1, occupiedCells);
                    if (check)
                    {
                        throw new Exception("Ship cells are occupied, ship cannot be Placed in Playing field");
                    }

                    this.Field.OccupyCell(yModule, xModule, ship);
                    yModule--;
                    if (yModule < 0)
                    {
                        throw new Exception("Placing ship goes past edge of Playingfield");
                    }
                }
            }
            else if (direction == Direction.South)
            {
                for (int i = 0; i < shipLength; i++)
                {
                    cell1 = this.Field.GetCell(yModule, xModule);
                    check = this.CellCompare(cell1, occupiedCells);
                    if (check)
                    {
                        throw new Exception("Ship cells are occupied, ship cannot be Placed in Playing field");
                    }

                    this.Field.OccupyCell(yModule, xModule, ship);
                    yModule++;
                    if (yModule > this.Field.Height - 1)
                    {
                        throw new Exception("Placing ship goes past edge of Playingfield");
                    }
                }
            }
            else if (direction == Direction.East)
            {
                for (int i = 0; i < shipLength; i++)
                {
                    cell1 = this.Field.GetCell(yModule, xModule);
                    check = this.CellCompare(cell1, occupiedCells);
                    if (check)
                    {
                        throw new Exception("Ship cells are occupied, ship cannot be Placed in Playing field");
                    }

                    this.Field.OccupyCell(yModule, xModule, ship);
                    xModule++;
                    if (xModule > this.Field.Width - 1)
                    {
                        throw new Exception("Placing ship goes past edge of Playingfield");
                    }
                }
            }
            else if (direction == Direction.West)
            {
                for (int i = 0; i < shipLength; i++)
                {
                    cell1 = this.Field.GetCell(yModule, xModule);
                    check = this.CellCompare(cell1, occupiedCells);
                    if (check)
                    {
                        throw new Exception("Ship cells are occupied, ship cannot be Placed in Playing field");
                    }

                    this.Field.OccupyCell(yModule, xModule, ship);
                    xModule--;
                    if (xModule < 0)
                    {
                        throw new Exception("Placing ship goes past edge of Playingfield");
                    }
                }
            }
        }

        private Cell[,] GetOccupiedCells(Cell[,] cells)
        {
            int xIndex = 0, yIndex = 0;
            Cell[,] occupiedCells = new Cell[cells.GetLength(0), cells.GetLength(1)];
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    if (cells[i, j].IsOccupied)
                    {
                        occupiedCells[xIndex, yIndex] = cells[i, j];
                        yIndex++;
                    }
                }

                xIndex++;
                yIndex = 0;
            }

            return occupiedCells;
        }

        private bool CellCompare(Cell cell, Cell[,] cells)
        {
           for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    if (cell.Equals(cells[i, j]))
                    {
                        return true;
                    }
                }
            }

           return false;
        }
    }
}
