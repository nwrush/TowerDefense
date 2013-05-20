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
        Vector2 gridPos;//Position on the game grid
        Texture2D texture;//Sprite texture
        Rectangle rect;//Rectangle used to draw the sprite
        float layer;//Layer between 1.0(back) and 0.0(front) used to determine where the sprite is drawn
        public int cost;//Cost of the tower
        int angle;//Angle the tower is pointing

        protected String asset;//Name of the tower to use

        public Tower(Vector2 pos,Grid grid,float layer){
            this.gridPos = pos;
            this.pos = new Vector2();
            LockToGrid(grid);
            this.layer = layer;
            this.angle = 0;
            this.asset = "Tower1";

            GV.AddTower(this);
        }
        protected void LockToGrid(Grid grid) {
            /*The sprite is positioned with the top left corner of the sprite
             * touching the grid point that they are placed at */
            this.pos.X = this.gridPos.X * grid.width; ;
            this.pos.Y = this.gridPos.Y * grid.height;
        }


        public void LoadContent(ContentManager content) {
            this.texture = content.Load<Texture2D>(this.asset);
            this.GetRect();
        }
        protected void GetRect() {
            this.rect=new Rectangle((int)this.pos.X, (int)this.pos.Y, this.texture.Width, this.texture.Height);
        }

        public virtual void Update(GraphicsDevice graphics) {
        }
        protected virtual void TrackTarget() {

        }

        public virtual void Draw(SpriteBatch spritebatch) {
            //spritebatch.Draw(this.texture, this.pos, Color.White);
            spritebatch.Draw(this.texture,this.rect, null, Color.White, 0.0f, new Vector2(0.0f), SpriteEffects.None, this.layer);
        }
    }
}
