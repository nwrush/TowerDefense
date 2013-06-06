using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

using TowerDefense.src;
namespace TowerDefense {
    static class GV {
        public static List<Enemy> EnemyList = new List<Enemy>();
        public static List<Tower> TowerList = new List<Tower>();
        public static List<Projectile> ProjectileList = new List<Projectile>();
        public static Microsoft.Xna.Framework.Graphics.SpriteFont spriteFont;

        public static ContentManager content;
        public static Grid grid;

        public static int tick = 0;

        public static double GetAngle(Tower t, Enemy e) {
            float Xdist = t.CenterPos.X - e.CenterPos.X;
            float Ydist = t.CenterPos.Y - e.CenterPos.Y;
            if (t.CenterPos.X > e.CenterPos.X) {
                return Math.Atan(Ydist / Xdist) + 180;
            }
            return Math.Atan(Ydist / Xdist);
        }

        public static bool Paused = false;
        public static bool Lost = false;
        public static int PLAY = 0;//0 for start screen, 1 for game, 2 for end screen
    }
}
