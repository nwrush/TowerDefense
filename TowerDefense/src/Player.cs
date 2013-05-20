using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefense.src {
    static class Player {
        static int Money = 0;
        public static int Score = 0;

        public static void BuyTower(Tower t) {
            if (t.cost > Money) {
                return;
            } else {
                Money -= t.cost;
            }
        }
    }
}
