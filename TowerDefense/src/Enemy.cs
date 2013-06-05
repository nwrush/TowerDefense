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
        Vector2 gridPos;
        Vector2 speed;//Represents the change in the sprites position every tick
        Grid grid;

        float layer;
        public Rectangle rect;
        float Scale;
        protected string asset;

        public Vector2 CenterPos;

        public double Health;

        private static Vector2 focus = new Vector2(200, 240);
        private Vector2 targetPos;

        private static int Damage = 10;

        public Enemy(Vector2 gridPos, Grid grid, float Layer) {
            this.gridPos = gridPos;
            this.grid = grid;
            this.layer = Layer;
            
            this.targetPos = focus;
            this.speed = this.TrackTarget();

            this.Scale = 0.25f;

            this.asset = "Plain-Bagel";

            this.Health = 150;

            this.LoadContent();
            GV.EnemyList.Add(this);
        }
        static List<Vector2> startList = new List<Vector2>(){
            new Vector2(),
            new Vector2(-50,240),
            new Vector2(0,400)
        };
        static List<Vector2> speedList = new List<Vector2>(){
            new Vector2(4,24/5),
            new Vector2(3,0),
            new Vector2(-4,-24/5)
        };
        static Random randgen = new Random();
        public Enemy() {
            this.layer = 0.5f;
            this.LoadContent();

            this.Health = 150;

            int rand = randgen.Next(3);

            this.pos = new Vector2();
            this.speed = new Vector2(10,12);
            GV.EnemyList.Add(this);
        }

        public void LoadContent(){
            this.texture=GV.content.Load<Texture2D>("Plain-Bagel");
            this.rect = new Rectangle((int)this.pos.X, (int)this.pos.Y, this.texture.Width, this.texture.Height);
            this.SetCenter();
        }
        protected void SetCenter() {
            this.CenterPos.X = (this.texture.Width / 2)+this.pos.X;
            this.CenterPos.Y = (this.texture.Height / 2)+this.pos.Y;
        }

        public void Update(GraphicsDevice graphics) {
            this.pos.X += this.speed.X;
            this.pos.Y += this.speed.Y;
            this.SetCenter();
            this.isDead();

            if (this.pos.Equals(focus)) {
                this.speed = new Vector2(1.0f, 0.0f);
            }

            if (this.pos.X > graphics.Viewport.Width + this.texture.Width*this.Scale+200) {
                GV.EnemyList.Remove(this);
                Player.Health -= Damage+15;
                Player.Money += 25;
            }
        }
        protected void isDead() {
            if (this.Health <= 0) {
                GV.EnemyList.Remove(this);
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
