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
        /*
         * Base class for all towers in the game
         * Handles LoadContent, Draw, most of the constructor, and some of the update function.
         * Each individual tower class has specifics such as damage.
         */

        Vector2 pos;//True position on the screen

        Texture2D texture;//Sprite texture
        public String asset;//Asset name of the texture to use  make protected after testing
        Rectangle rect;//Rectangle used to draw the sprite
        float layer;//Layer between 1.0(back) and 0.0(front) used to determine where the sprite is drawn

        public int cost;//Cost of the tower
        public double angle;//Angle the tower is pointings

        protected double damage;

        protected Enemy target;//Current target the tower is aiming for

        public Vector2 CenterPos;

        private int LastFireTick = -60;

        public Tower(Vector2 pos,Grid grid,float layer){
            this.pos = pos;
            this.layer = layer;
            this.target = GV.EnemyList[0];
        }
        
        public void LoadContent(ContentManager content) {
            this.texture = content.Load<Texture2D>(this.asset);
            this.SetCenter();
            this.GetRect();
        }
        protected void GetRect() {
            this.rect=new Rectangle((int)(this.CenterPos.X), (int)(this.CenterPos.Y), this.texture.Width, this.texture.Height);
        }
        protected void SetCenter() {
            //The center of the sprite is position of the sprite plus the texture dimensions/2
            //This value is used in the draw so that the sprite is drawn correctly in it's grid square
            this.CenterPos.X = (this.texture.Width / 2)+this.pos.X;
            this.CenterPos.Y = (this.texture.Height / 2)+this.pos.Y;
        }

        private Vector2 vectorToTarget;
        public virtual void Update(GraphicsDevice graphics) {
            this.vectorToTarget=this.TrackTarget();
            //Fire
            if (this.LastFireTick+60 <= GV.tick) {
                this.Fire();
                this.LastFireTick=GV.tick;
            }
            if (!GV.EnemyList.Contains(this.target)) {
                this.target = GV.EnemyList[0];
            }
        }
        protected virtual Vector2 TrackTarget() {
            float xDist = (this.pos.X - this.target.pos.X)/50;
            float yDist = (this.pos.Y - this.target.pos.Y)/50;
            return new Vector2(xDist, yDist);
        }
        public virtual void Fire() {
            new Projectile(this.CenterPos, this.target, this.damage, this.vectorToTarget);
        }

        public virtual void Draw(SpriteBatch spritebatch) {
            //Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth);
            spritebatch.Draw(this.texture, this.rect, null, Color.White, (float)this.angle/*Rotation*/, new Vector2(this.texture.Width/2,this.texture.Height/2), SpriteEffects.None, this.layer);
        }
    }
}
