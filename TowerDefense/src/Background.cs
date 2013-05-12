using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefense.src {
    class Background {
        Vector2 pos;
        Texture2D texture;
        public Background() {
            this.pos = new Vector2(0.0f);
        }

        public void LoadContent(ContentManager content, string asset) {
            this.texture = content.Load<Texture2D>(asset);
        }

        public void Draw(SpriteBatch spritebatch) {
            spritebatch.Draw(this.texture, this.pos, Color.White);
        }
    }
}