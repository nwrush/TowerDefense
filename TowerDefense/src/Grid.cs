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
        List<List<Vector2>> RowList;//Holds to the list of the points in each row, each row gets its own list

        public Grid(GraphicsDevice graphics) {
            this.height = 160;
            this.width = 160;

            this.columns = graphics.Viewport.Width / this.width+1;
            this.rows = graphics.Viewport.Height / this.height+1;

            this.PointList = new List<Vector2>();
            this.RowList = new List<List<Vector2>>();

            this.CreatePointList();
            this.CreateGridList();
            Console.Write("");
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
            float xVal = 0;
            float yVal = 0;
            List<Vector2> Holder;

            for (int i = 0; i <= this.rows; i++) {
                Holder = new List<Vector2>();

                for (int j = 0; j <= this.columns; j++) {
                    Holder.Add(new Vector2(xVal, yVal));
                    xVal += this.width;
                }

                yVal += this.height;
                xVal = 0;
                this.RowList.Add(Holder);
            }
        }
    }
}