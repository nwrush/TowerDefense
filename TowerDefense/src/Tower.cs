﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefense.src {
    class Tower{
        /*
         * Base class for all towers in the game
         * Handles LoadContent, Draw, most of the constructor, and some of the update function
         */

        Vector2 pos;//True position on the screen
        Vector2 gridPos;//Position on the game grid

        Texture2D texture;//Sprite texture
        protected String asset;//Asset name of the texture to use
        Rectangle rect;//Rectangle used to draw the sprite
        float layer;//Layer between 1.0(back) and 0.0(front) used to determine where the sprite is drawn

        public int cost;//Cost of the tower
        double angle;//Angle the tower is pointings

        Enemy target;//Current target the tower is aiming for

        public Vector2 CenterPos;

        public Tower(Vector2 pos,Grid grid,float layer){
            this.gridPos = pos;
            this.pos = new Vector2();
            LockToGrid(grid);
            this.layer = layer;
            this.angle = 0;

            GV.AddTower(this);
        }
        protected void LockToGrid(Grid grid) {
            /*The sprite is positioned with the top left corner of the sprite
             * touching the grid point that they are placed at */
            this.pos.X = this.gridPos.X * grid.width; ;
            this.pos.Y = this.gridPos.Y * grid.height;
        }
        
        public void LoadContent(ContentManager content) {
            this.texture = content.Load<Texture2D>(this.asset);
            this.SetCenter();
            this.GetRect();
        }
        protected void GetRect() {
            this.rect=new Rectangle((int)(this.CenterPos.X), (int)(this.CenterPos.Y), this.texture.Width, this.texture.Height);
        }
        protected void SetCenter() {
            //The center of the sprite is position of the sprite plus the texture dimensions/2
            //This value is used in the draw so that the sprite is drawn correctly in it's grid square
            this.CenterPos.X = (this.texture.Width / 2)+this.pos.X;
            this.CenterPos.Y = (this.texture.Height / 2)+this.pos.Y;
        }

        public virtual void Update(GraphicsDevice graphics) {
            //Exit the game if the tower is outside of the screen
            if ((this.pos.X < 0) || (this.pos.X > graphics.Viewport.Width)) {
                Environment.Exit(-1);
            }
            if ((this.pos.Y < 0) || (this.pos.Y > graphics.Viewport.Height)) {
                Environment.Exit(-1);
            }
        }
        protected virtual void TrackTarget() {
            //Gets the angle the tower needs to point at to be facing the target
            this.angle = GV.GetAngle(this, this.target);
        }

        public virtual void Draw(SpriteBatch spritebatch) {
            //Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth);
            spritebatch.Draw(this.texture, this.rect, null, Color.White, (float)this.angle/*Rotation*/, new Vector2(this.texture.Width/2,this.texture.Height/2), SpriteEffects.None, this.layer);
        }

        //public string asset {
        //    get { return this.asset; }
        //}
           
    }
}
