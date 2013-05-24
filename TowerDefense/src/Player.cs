using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefense.src {
    static class Player {
        static int Money = 0;
        public static int Score = 0;
        public static int Health = 100;
        private static SpriteFont font;

        public static void BuyTower(Tower t) {
            if (t.cost > Money) {
                return;
            } else {
                Money -= t.cost;
            }
        }
        public static void LoadContent(ContentManager content){
            font = content.Load<SpriteFont>("font");
        }
        public static void Update() {
            KeyboardState keyboardState = Keyboard.GetState();

        }
        public static void Draw(SpriteBatch spritebatch) {
            spritebatch.DrawString(font, "Score: "+Score.ToString(), new Vector2(150, 450), Color.Black,0.0f,new Vector2(),1.0f,SpriteEffects.None,0.1f);
            spritebatch.DrawString(font, "Health: "+Health.ToString(), new Vector2(350, 450), Color.Black,0.0f,new Vector2(),1.0f,SpriteEffects.None,0.1f);
            spritebatch.DrawString(font, "Money: "+Money.ToString(), new Vector2(550, 450), Color.Black,0.0f,new Vector2(),1.0f,SpriteEffects.None,0.1f);
        }
    }
}
