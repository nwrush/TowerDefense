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
        Rectangle rect;
        float layer;

        public Tower(Tuple<int,int> pos,Grid grid,float layer){
            this.gridPos = pos;
            this.pos = new Vector2();
            LockToGrid(grid);
            Console.WriteLine(this.pos);
            this.layer = layer;
        }
        protected void LockToGrid(Grid grid) {
            /*The sprite is positioned with the top left corner of the sprite
             * touching the grid point that they are placed at */
            this.pos.X = this.gridPos.Item1 * grid.width; ;
            this.pos.Y = this.gridPos.Item2 * grid.height;
        }


        public void LoadContent(ContentManager content,String asset) {
            this.texture = content.Load<Texture2D>(asset);
            this.GetRect();
        }
        protected void GetRect() {
            this.rect=new Rectangle((int)this.pos.X, (int)this.pos.Y, this.texture.Width, this.texture.Height);
        }

        public virtual void Update(GraphicsDevice graphics) {
        }

        public virtual void Draw(SpriteBatch spritebatch) {
            //spritebatch.Draw(this.texture, this.pos, Color.White);
            Rectangle rect = new Rectangle((int)this.pos.X, (int)this.pos.Y, this.texture.Width, this.texture.Height);
            spritebatch.Draw(this.texture,rect, null, Color.White, 0.0f, new Vector2(0.0f), SpriteEffects.None, 0.10f);
        }
    }
}
