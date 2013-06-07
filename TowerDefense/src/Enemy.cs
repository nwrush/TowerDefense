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

        public Vector2 pos;
        Vector2 speed;//Represents the change in the sprites position every tick

        public Rectangle rect;//Rectangle for collisions
        float Scale;//Scale the draw the sprite and scale all other items

        public Vector2 CenterPos;

        public double Health;

        private static Vector2 focus = new Vector2(200, 240);//Position that all enemies go to and then swich speeds
        private Vector2 targetPos;//bad practice

        private static int Damage = 10;

        static List<Vector2> posList = new List<Vector2>(){//List of possible starting locations
            new Vector2(),
            new Vector2(-50,240),
            new Vector2(0,400)
        };
        static List<Vector2> speedList = new List<Vector2>(){//list of speeds, corresponds to starting locations
            new Vector2(5,6),
            new Vector2(1,0),
            new Vector2(4,-3.2f)
        };
        static Random randgen = new Random();
        public Enemy() {
            this.LoadContent();

            this.Health = 30;

            this.Scale=0.25f;
            this.targetPos = focus;
            int rand = randgen.Next(3);
            this.pos = posList[rand];
            this.speed = speedList[rand];

            GV.EnemyList.Add(this);
        }

        public void LoadContent(){
            this.texture=GV.content.Load<Texture2D>("Plain-Bagel");
            this.rect = new Rectangle((int)this.pos.X, (int)this.pos.Y,(int)Math.Floor(this.texture.Width*this.Scale), (int)Math.Floor(this.texture.Height*this.Scale));
            this.SetCenter();
        }
        protected void SetCenter() {
            this.CenterPos.X = (this.texture.Width / 2)+this.pos.X;
            this.CenterPos.Y = (this.texture.Height / 2)+this.pos.Y;
        }

        public void Update(GraphicsDevice graphics) {
            this.pos.X += this.speed.X;
            this.pos.Y += this.speed.Y;
            this.rect.X = (int)this.pos.X;
            this.rect.Y = (int)this.pos.Y;
            this.SetCenter();
            this.isDead();

            if (this.speed.Equals(speedList[2])&&this.pos.X==200f) {
                this.pos.Y = 240f;
            }
            if (this.pos.Equals(focus)) {
                this.speed = new Vector2(1.0f, 0.0f);
            }

            if (this.pos.X > graphics.Viewport.Width + this.texture.Width*this.Scale+200) {
                GV.EnemyList.Remove(this);
                Player.Health -= Damage;
            }
        }
        protected void isDead() {
            if (this.Health <= 0) {
                GV.EnemyList.Remove(this);
                Player.Money += 50;
                Player.Score++;
                new Enemy();
            }
        }
        protected virtual Vector2 TrackTarget() {
            float xDist = (this.pos.X - this.targetPos.X) / -20;
            float yDist = (this.pos.Y - this.targetPos.Y) / -20;
            return new Vector2(xDist, yDist);
        }

        public virtual void Draw(SpriteBatch spritebatch) {
            //public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);
            spritebatch.Draw(this.texture, this.pos, null, Color.White, 0.0f, new Vector2(), this.Scale, SpriteEffects.None,0.1f);
        }
    }
}
