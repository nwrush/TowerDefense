using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TowerDefense.src;
namespace TowerDefense {
    static class GV {
        public static List<Enemy> EnemyList = new List<Enemy>();
        public static List<Tower> TowerList = new List<Tower>();

        public static void AddTower(Tower tower) {
            TowerList.Add(tower);
        }
        public static void AddEnemy(Enemy e) {
            EnemyList.Add(e);
        }

        public static double GetAngle(Tower t, Enemy e) {
            Console.Write("");
            float Xdist = t.CenterPos.X - e.CenterPos.X;
            float Ydist = t.CenterPos.Y - e.CenterPos.Y;
            if (t.CenterPos.X < e.CenterPos.X) {
                return Math.Atan(Ydist / Xdist) + 180;
            }
            return Math.Atan(Ydist / Xdist);   
        }
    }
}
