using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

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
            font = content.Load<SpriteFont>("SpriteFont1");
        }
        public static void Draw(SpriteBatch spritebatch) {
            spritebatch.DrawString(font, "This is not a string", new Vector2(0f, 0f), Color.White);
            spritebatch.DrawString(font, Health.ToString(), new Vector2(400, 400), Color.White);
            spritebatch.DrawString(font, Money.ToString(), new Vector2(600, 400), Color.White);
        }
    }
}
