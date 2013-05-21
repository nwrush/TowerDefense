﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TowerDefense.src;
namespace TowerDefense {
    static class GV {
        public static List<Enemy> EnemyList=new List<Enemy>();
        public static List<Tower> TowerList=new List<Tower>();

        public static void AddTower(Tower tower){
            TowerList.Add(tower);
        }
        public static void AddEnemy(Enemy e) {
            EnemyList.Add(e);
        }

        public static double GetAngle(Tower t, Enemy e) {
            Console.WriteLine(t.asset);
            float Xdist = t.CenterPos.X - e.CenterPos.X;
            float Ydist = t.CenterPos.Y - e.CenterPos.Y;
            return Math.Atan(Ydist / Xdist);
        }
    }
}
