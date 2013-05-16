using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefense.src {
    class Tower{
        Vector2 pos;//True position on the screen
        Tuple<int,int> gridPos;//Position on the game grid
        Texture2D texture;
        public Tower(Tuple<int,int> pos,Grid grid){
            this.gridPos = pos;
            this.pos = new Vector2();
            LockToGrid(grid);
        }

        private void LockToGrid(Grid grid) {
            /*The sprite is positioned with the top left corner of the sprite
             * touching the grid point that they are placed at */
            this.pos.X = this.gridPos.Item1 * grid.Get_Width();
            this.pos.Y = this.gridPos.Item2 * grid.Get_Height();
        }

        public void LoadContent(ContentManager content,String asset) {
            this.texture = content.Load<Texture2D>(asset);
        }

        public virtual void Update(GraphicsDevice graphics) {

        }

        public virtual void Draw(SpriteBatch spritebatch) {
            spritebatch.Draw(this.texture, this.pos, Color.White);
        }
    }
}
