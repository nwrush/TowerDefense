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
            this.target = GV.EnemyList[0];
            this.damage = 10;
            this.cost = 50;
            this.angle = 0;
            this.LoadContent(GV.content);
        }
        public override void Update(Microsoft.Xna.Framework.Graphics.GraphicsDevice graphics) {
            base.Update(graphics);
            //this.TrackTarget();
            this.angle = GV.GetAngle(this, this.target);
        }
    }
}
