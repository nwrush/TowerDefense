using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense.src {
    class Projectile {
        static Texture2D texture;
        Vector2 speed;
        Vector2 pos;

        Enemy e;

        Rectangle boundingBox;
        double angle;
        double damage;

        bool draw = true;

        public Projectile(Vector2 pos,Enemy e,double damage,double angle) {
            this.pos = pos;
            this.speed = new Vector2(1.0f);
            this.e = e;
            this.angle = angle;
            this.damage = damage;

            this.LoadContent(GV.content);

            GV.ProjectileList.Add(this);
        }

        public void LoadContent(ContentManager content) {
            texture = content.Load<Texture2D>("Projectile");
            //Get the bounding box for the sprite texture
            this.boundingBox = new Rectangle((int)this.pos.X, (int)this.pos.Y, texture.Width, texture.Height);
        }
        public void Update() {
            this.pos += this.speed;
            this.checkCollide();
            this.UpdateRect();
        }
        private void checkCollide() {
            if(this.boundingBox.Intersects(e.rect)){
                this.draw = false;
                e.Health -= this.damage;
            }
        }
        private void UpdateRect(){
            this.boundingBox.X=(int)this.pos.X;
            this.boundingBox.Y=(int)this.pos.Y;
        }

        public void Draw(SpriteBatch spritebatch) {
            if (this.draw) {//If the sprite is "dead" then don't draw it//                   //Draw the sprite with the origin at the center, for the rotate
                spritebatch.Draw(texture, this.boundingBox, null,Color.White,(float)this.angle,new Vector2(texture.Width/2f,texture.Height/2f),SpriteEffects.None,0.1f);
            }
        }
    }
}
