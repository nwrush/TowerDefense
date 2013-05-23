using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense.src {
    class Projectile {
        Texture2D texture;
        Vector2 speed;
        Vector2 pos;
        Enemy e;
        Rectangle boundingBox;
        double damage;
        bool draw = true;

        public Projectile(Vector2 pos,Enemy e,double damage) {
            this.pos = pos;
            this.speed = new Vector2(5.0f);
            this.e = e;
            this.damage = damage;
        }

        public void LoadContent(ContentManager content, string asset) {
            this.texture = content.Load<Texture2D>(asset);
            //Get the bounding box for the sprite texture
            this.boundingBox = new Rectangle((int)this.pos.X, (int)this.pos.Y, this.texture.Width, this.texture.Height);
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
            if (this.draw) {//If the sprite is "dead" then don't draw it
                spritebatch.Draw(this.texture, this.boundingBox, Color.White);
            }
        }
    }
}
