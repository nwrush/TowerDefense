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
        Vector2 pos;
        Texture2D texture;
        public Tower(Vector2 pos){
            this.pos = pos;
        }
        public void LoadContent(ContentManager content,String asset) {
            this.texture = content.Load<Texture2D>(asset);
        }
        public void Update(GraphicsDevice graphics) {
            
        }
        public void Draw(SpriteBatch spritebatch) {
            spritebatch.Draw(this.texture, this.pos, Color.White);
        }
    }
}
