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
        Rectangle rect;
        public Background() {
            this.pos = new Vector2(0.0f);
        }

        public void LoadContent(ContentManager content, string asset) {
            this.texture = content.Load<Texture2D>(asset);
            GetRect();
        }
        protected void GetRect() {
            this.rect = new Rectangle(0, 0, this.texture.Width, this.texture.Height);
        }

        public void Draw(SpriteBatch spritebatch) {
            spritebatch.Draw(this.texture, this.rect, null, Color.White, 0.0f, new Vector2(), SpriteEffects.None, 0.0f);
        }
    }
}
