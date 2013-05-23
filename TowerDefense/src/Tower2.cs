using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TowerDefense.src {
    class Tower2:Tower {
        public Tower2(Vector2 gridPos, Grid grid,float layer)
            : base(gridPos, grid,layer) {
                this.asset = "Tower2";
                this.target = GV.EnemyList[0];//Tower target
        }
    }
}
