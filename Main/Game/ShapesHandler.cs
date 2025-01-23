using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    static class ShapesHandler
    {
        private static Shape[] shapes;
        static ShapesHandler()
        {
            shapes = new Shape[]
            {
        new Shape(
            new int[,]
            {
                { 1, 1 },
                { 1, 1 }
            },
            Color.Yellow // Square shape color
        ),
        new Shape(
            new int[,]
            {
                { 1 },
                { 1 },
                { 1 },
                { 1 }
            },
            Color.Cyan // Line shape color
        ),
        new Shape(
            new int[,]
            {
                { 0, 1, 0 },
                { 1, 1, 1 }
            },
            Color.Purple // T shape color
        ),
        new Shape(
            new int[,]
            {
                { 0, 0, 1 },
                { 1, 1, 1 }
            },
            Color.Orange // L shape color
        ),
        new Shape(
            new int[,]
            {
                { 1, 0, 0 },
                { 1, 1, 1 }
            },
            Color.Blue // Reverse L shape color
        ),
        new Shape(
            new int[,]
            {
                { 1, 1, 0 },
                { 0, 1, 1 }
            },
            Color.Red // Z shape color
        ),
        new Shape(
            new int[,]
            {
                { 0, 1, 1 },
                { 1, 1, 0 }
            },
            Color.Green // Reverse Z shape color
        )
            };
        }
        public static Shape GetRandomShape()
        {
            var shape = shapes[new Random().Next(shapes.Length)];
            
            return shape;
        }
    }
}