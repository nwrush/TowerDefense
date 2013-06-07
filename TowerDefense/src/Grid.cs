using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using C3.XNA;

namespace TowerDefense.src {
    class Grid {
        /// <summary>
        /// Was going to be used in sprite pathing and holding towers to specific locations, eventually phased out because it would require too much time
        /// </summary>
        public int width, height, rows, columns;
        List<Vector2> PointList;
        List<List<Vector2>> RowList;//Holds to the list of the points in each row, each row gets its own list

        public Grid(GraphicsDevice graphics) {
            this.height = 40;
            this.width = 40;

            this.columns = graphics.Viewport.Width / this.width+1;
            this.rows = graphics.Viewport.Height / this.height+1;

            this.PointList = new List<Vector2>();
            this.RowList = new List<List<Vector2>>();

            this.CreatePointList();
            this.CreateGridList();
            GV.grid = this;
        }

        private void CreatePointList() {
            float xVal = 0;
            float yVal = 0;
            for (int i = 0; i < this.rows; i++) {
                for (int j = 0; j < this.columns; j++) {
                    this.PointList.Add(new Vector2(xVal,yVal));
                    xVal += this.width;
                }
                yVal += this.height;
                xVal = 0;
            }
        }

        private void CreateGridList(){
            float xVal = 0;
            float yVal = 0;
            List<Vector2> Holder;

            for (int i = 0; i < this.rows; i++) {
                Holder = new List<Vector2>();

                for (int j = 0; j < this.columns; j++) {
                    Holder.Add(new Vector2(xVal, yVal));
                    xVal += this.width;
                }

                yVal += this.height;
                xVal = 0;
                this.RowList.Add(Holder);
            }
        }

        public void DrawGrid(SpriteBatch spritebatch) {
            this.DrawVerticle(spritebatch);
            this.DrawHorizontal(spritebatch);
        }
        // Primitives2D.DrawLine(spriteBatch, new Vector2(1.0f, 1.0f), new Vector2(150.0f, 150.0f), Color.Black, 2.0f);

        private void DrawVerticle(SpriteBatch spritebatch) {
            List<Vector2> TopList,BottomList;
            TopList=this.RowList[0];
            BottomList=this.RowList[this.RowList.Count-1];
            for (int i = 0; i <= TopList.Count-1; i++) {
                Primitives2D.DrawLine(spritebatch, TopList[i], BottomList[i], Color.Black, 2.0f);
            }
        }
        private void DrawHorizontal(SpriteBatch spritebatch) {
            for (int i = 0; i <= this.RowList.Count-1; i++) {
                Primitives2D.DrawLine(spritebatch, RowList[i][0], RowList[i][RowList[i].Count - 1], Color.Black);
            }
        }

        public List<Vector2> Get_PointList() {
            return this.PointList;
        }
        public List<List<Vector2>> Get_RowList() {
            return this.RowList;
        }
    }
}
