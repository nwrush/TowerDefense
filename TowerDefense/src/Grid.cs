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
        List<Vector2> PointList;
        List<List<Tuple<Vector2,Vector2>>> GridList;

        public Grid(GraphicsDevice graphics) {
            this.height = 10;
            this.width = 10;

            this.rows = graphics.Viewport.Width / this.width+1;
            this.columns = graphics.Viewport.Height / this.height+1;

            this.PointList = new List<Vector2>();
            this.GridList = new List<List<Tuple<Vector2,Vector2>>>();

            this.CreatePointList();
            Console.WriteLine(PointList[3]);
        }

        private void CreatePointList() {
            float xVal = 0;
            float yVal = 0;
            for (int i = 0; i <= this.rows; i++) {
                for (int j = 0; j <= this.columns; j++) {
                    this.PointList.Add(new Vector2(xVal,yVal));
                    xVal += this.width;
                }
                yVal += this.height;
                xVal = 0;
            }
            Console.Write("");
        }

        private void CreateGridList(){

            for (int i = 0; i <= this.rows; i++) {
                for (int j = 0; j <= this.columns; j++) {
                    
                }
            }
        }
    }
}