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
        //double angle;
        double damage;

        public Projectile(Vector2 pos,Enemy e,double damage,Vector2 speed) {
            this.pos = pos;
            this.speed = -1*speed;
            this.e = e;
            //this.angle = angle;
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
            foreach (Enemy e in GV.EnemyList) {
                if (this.boundingBox.Intersects(e.rect)) {
                    GV.ProjectileList.Remove(this);
                    Console.Write("");
                    e.Health -= this.damage;
                }
            }
        }
        private void UpdateRect(){
            this.boundingBox.X=(int)this.pos.X;
            this.boundingBox.Y=(int)this.pos.Y;
        }

        public void Draw(SpriteBatch spritebatch) {
            spritebatch.Draw(texture, this.boundingBox,null,Color.White,0.0f,new Vector2(0.0f),SpriteEffects.None,0.1f);
        }
    }
}
