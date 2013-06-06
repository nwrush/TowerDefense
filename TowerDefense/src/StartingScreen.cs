using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using C3.XNA;

namespace TowerDefense.src {
    class StartingScreen {

        public bool play = false;
        Rectangle rect;
        Texture2D active, instuct;

        public StartingScreen(Rectangle r) {
            this.rect = r;
            this.active = GV.content.Load<Texture2D>("TitleScreen");
            this.active.Name = "Title";
            this.instuct = GV.content.Load<Texture2D>("Instructions");
            this.instuct.Name = "Instruct";
        }

        public void Update() {
            if (Input.isKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter) && this.active.Name.Equals("Title")) {
                this.active = this.instuct;
            }
            else {
                if (Input.isKeyDown(Microsoft.Xna.Framework.Input.Keys.Space)&&this.active.Equals(this.instuct)){
                    GV.PLAY = 1;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(this.active, new Vector2(), Color.White);
        }
    }
}
