using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int[,] Dots { get; set; }
        public Color ShapeColor { get; set; }

        private int[,] backupDots;

        public Shape(int[,] dots, Color color)
        {
            Dots = dots;
            Height = dots.GetLength(0);
            Width = dots.GetLength(1);
            ShapeColor = color;
        }
        public void turn()
        {
            // back the dots values into backup dots
            // so that it can be simply used for rolling back
            backupDots = Dots;

            Dots = new int[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Dots[i, j] = backupDots[Height - 1 - j, i];
                }
            }

            var temp = Width;
            Width = Height;
            Height = temp;
        }

        // the rolling back occures when player rotating the shape
        // but it will touch other shapes and needs to be rolled back
        public void rollback()
        {
            Dots = backupDots;

            var temp = Width;
            Width = Height;
            Height = temp;
        }
    }
}