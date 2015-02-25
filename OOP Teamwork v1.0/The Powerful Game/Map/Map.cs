using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace The_Powerful_Game.Map
{
    class Map
    {
        //Fields
        private int rows;
        private int columns;
        private List<Tile> tiles = new List<Tile>(); 
        //Constructors
        public Map(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            Random random = new Random();
            for (int r = 0; r < columns; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    var tile = new Tile();
                    tile.Data = string.Format("Row {0}, Column {1}", r, c);
                    tile.Bacground =
                        new SolidColorBrush(Color.FromArgb(255, (byte) random.Next(256), (byte) random.Next(256),
                            (byte) random.Next(256)));
                    tiles.Add(tile);

                }
            }
        }
        //Properties

        public int Rows
        {
            get { return this.rows; }
            set { this.rows = value; }
        }
        public int Columns
        {
            get { return this.columns; }
            set { this.columns = value; }
        }

        public List<Tile> Tiles
        {
            get { return this.tiles; }
            set { this.tiles = value; }
        }
    }
}
