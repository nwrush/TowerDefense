using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerDefense.src {
    class Tower2:Tower {
        public Tower2(Tuple<int, int> gridPos, Grid grid,float layer)
            : base(gridPos, grid,layer) {
        }
    }
}
