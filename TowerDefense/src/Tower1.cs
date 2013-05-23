using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefense.src {
    class Tower1:Tower{
        public Tower1(Vector2 pos, Grid grid, float layer)
            :base(pos,grid,layer) {
            this.asset = "Tower1";

            //DEBUG STATEMENTS
            this.target = GV.EnemyList[0];//Because we know the bagel is the first and only sprite in the Enemy list right now, we can do this
        }

        public override void Update(GraphicsDevice graphics) {
            base.Update(graphics);
            this.TrackTarget();
        }
    }
}
