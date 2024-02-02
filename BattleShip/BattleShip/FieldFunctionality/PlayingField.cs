using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Field
{
    public class PlayingField
    {
        private readonly int _max = 100;

        private readonly int _min = 5;

        private Cell[,] cells;

        public PlayingField(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }


        public int Height { get; }

        public int Width { get; }

        public Cell[,] CreateField()
        {
            this.cells = new Cell[this.Height, this.Width];

            if (this.Height * this.Width < this._min)
            {
                throw new Exception($"The number of cells created is less than the allowed limit: {this._min}");
            }
            else if (this.Height * this.Width > this._max)
            {
                throw new Exception($"The number of cells created is more than the allowed limit: {this._max}");
            }

            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    this.cells[j,i] = new Cell(j, i);
                }
            }

            return this.cells;
        }

        public void OccupyCell(int y, int x, Ship ship)
        {
            Cell cell = this.GetCell(x, y);
            if (cell != null)
            {
                cell.Ship = ship;
                cell.IsOccupied = true;
            }
        }

        public void DisplayField()
        {
            foreach (var cell in this.cells)
            {
                Console.WriteLine(cell.ToString());
            }
        }

        public Cell[,] GetCells() => this.cells;

        public Cell GetCell(int y, int x)
        {
            if (x >= 0 && x < this.Width && y >= 0 && y < this.Height)
            {
                return this.cells[x,y];
            }

            return null;
        }

        public Cell this[int y, int x]
        {
            get => this.cells[y, x];
            set => this.cells [y, x] = value;
        }
    }
}
