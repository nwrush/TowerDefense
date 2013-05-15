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

        public virtual void Update(GraphicsDevice graphics) {
            
        }

        private virtual void LockToGrid(Grid grid) {
            foreach (Vector2 point in grid.Get_PointList()) {

            }
        }
        private float Distance(Vector2 p1, Vector2 p2) {
            
            return new float();
        }

        public virtual void Draw(SpriteBatch spritebatch) {
            spritebatch.Draw(this.texture, this.pos, Color.White);
        }
    }
}
