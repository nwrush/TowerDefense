using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace TowerDefense.src {
    class Tower4 : Tower {
        public Tower4(Vector2 gridPos, Grid grid,float layer)
            : base(gridPos, grid,layer) {
                this.asset = "Tower4";
        }
    }
}
