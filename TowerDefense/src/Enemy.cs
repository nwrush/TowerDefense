using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense.src {
    class Enemy {
        Texture2D texture;

        Vector2 pos;
        Vector2 gridPos;
        Vector2 speed;//Represents the change in the sprites position every tick
        int Xmultiplier, Ymultiplier;
        Grid grid;

        float layer;
        public Rectangle rect;
        float Scale;
        protected string asset;

        public Vector2 CenterPos;

        public double Health;
        bool dead=false;

        public Enemy(Vector2 gridPos, Grid grid, float Layer, Vector2 speed) {
            this.gridPos = gridPos;
            this.grid = grid;
            this.LockToGrid();
            this.layer = Layer;
            this.speed = speed;

            this.Xmultiplier = -1;
            this.Ymultiplier = -1;
            this.Scale = 0.5f;

            this.asset = "Plain-Bagel";

            this.Health = 150;

            GV.AddEnemy(this);
        }

        protected void LockToGrid() {
            /*The sprite is positioned with the top left corner of the sprite
             * touching the grid point that they are placed at */
            this.pos.X = this.gridPos.X * this.grid.width; ;
            this.pos.Y = this.gridPos.Y * this.grid.height;
        }

        public void LoadContent(ContentManager content){
            this.texture=content.Load<Texture2D>(this.asset);
            this.rect = new Rectangle((int)this.pos.X, (int)this.pos.Y, this.texture.Width, this.texture.Height);
            this.SetCenter();
        }

        protected void SetCenter() {
            this.CenterPos.X = (this.texture.Width / 2)+this.pos.X;
            this.CenterPos.Y = (this.texture.Height / 2)+this.pos.Y;
        }

        public void Update(GraphicsDevice graphics) {
            this.pos.X += this.speed.X * this.Xmultiplier;
            this.pos.Y += this.speed.Y * this.Ymultiplier;
            this.Bounding(graphics);
            this.SetCenter();
            this.isDead();
        }
        protected void Bounding(GraphicsDevice graphics) {
            if ((this.pos.X <= 0) || (this.pos.X >= graphics.Viewport.Width - this.texture.Width*this.Scale)) {
                this.Xmultiplier *= -1;
            }
            if ((this.pos.Y <= 0) || (this.pos.Y >= graphics.Viewport.Height - this.texture.Height*this.Scale)) {
                this.Ymultiplier *= -1;
            }
        }
        protected void isDead() {
            if (this.Health <= 0) {
                this.dead = true;
            }
        }

        public virtual void Draw(SpriteBatch spritebatch) {
            if (!this.dead) {
                //public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);
                spritebatch.Draw(this.texture, this.pos, null, Color.White, 0.0f, new Vector2(), this.Scale, SpriteEffects.None, 0.5f);
            }
        }
    }
}
