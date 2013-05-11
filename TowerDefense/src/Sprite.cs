using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense.src {
    class Sprite {
        Texture2D texture;
        Vector2 pos,speed;
        String asset;
        public Sprite(Vector2 speed, Vector2 pos,String asset) {
            this.speed=speed;
            this.pos = pos;
            this.asset = asset;
        }

        public virtual void LoadContent(ContentManager content){
            this.texture = content.Load<Texture2D>(this.asset);
        }

        public virtual void Update() {
            this.pos += this.speed;
        }
        //Flursmynerf
        public virtual void Draw(SpriteBatch spritebatch) {
            spritebatch.Draw(this.texture, this.pos, Color.Transparent);
        }
    }
}