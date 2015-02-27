namespace The_Powerful_Game.Map
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public class Map
    {
        private int rows;
        private int columns;
        private int[][] numMap;
        private List<Tile> tiles = new List<Tile>();

        public Map(int rows, int columns, int[][] numMap)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.NumMap = numMap;

            for (int r = 0; r < numMap.Length; r++)
            {
                for (int c = 0; c < numMap[r].Length; c++)
                {
                    Random random = new Random();

                    string path = @"pack://application:,,,/Resources/MapObjects/";

                    switch (numMap[r][c])
                    {
                        case 0:
                            path += "grass.png";
                            break;
                        case 1:
                            path += "tree.png";
                            break;
                        case 2:
                            path += "water.png";
                            break;
                        case 3:
                            path += "bridge.png";
                            break;
                    }

                    this.tiles.Add(new Tile()
                    {
                        Background = new ImageBrush(new BitmapImage(new Uri(path))),
                    });
                }
            }
        }

        public int[][] NumMap
        {
            get { return this.numMap; }
            set { this.numMap = value; }
        }

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
