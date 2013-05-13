using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using C3.XNA;

namespace TowerDefense.src {
    class Grid {
        int width, height, rows, columns;
        List<Tuple<int,int>> PointList;

        public  Grid(GraphicsDevice graphics) {
            this.height = 10;
            this.width = 10;

            this.rows=graphics.Viewport.Width / this.width;
            this.columns = graphics.Viewport.Height / this.height;
            this.PointList=new List<Tuple<int,int>>();
            this.CreatePointList();
            Console.WriteLine(PointList);
        }

        private  void CreatePointList() {
            int xVal=0;
            int yVal=0;
            for (int i = 0; i<=rows; i++) {
                for (int j = 0; j <= columns; j++) {
                    this.PointList.Add(Tuple.Create(xVal, yVal));
                    xVal += this.width;
                }
                yVal += this.height;
                xVal = 0;
            }
            Console.Write("");
        }

        public void DrawGrid(SpriteBatch spritebatch) {

        }
    }
}