using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using TowerDefense.src;
using C3.XNA;

namespace TowerDefense {
    public class Game1 : Microsoft.Xna.Framework.Game {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }

        Sprite ex;
        Background back;
        Grid grid;
        Tower tower;
        Tower2 tower2;
        Tower3 tower3;
        Tower4 tower4;
        protected override void Initialize() {
            // TODO: Add your initialization logic here
            //Level Initalizations
            this.grid = new Grid(GraphicsDevice);
            this.back = new Background();

            //Sprite  Initialization
            this.ex = new Sprite(new Vector2(5.0f, 5.0f), new Vector2(5.0f, 5.0f));
            this.tower = new Tower(new Tuple<int,int>(5,5),grid,0.9f);
            this.tower2 = new Tower2(new Tuple<int, int>(10, 10), grid, 0.9f);
            this.tower3 = new Tower3(new Tuple<int, int>(4,6), grid,0.9f);
            this.tower4 = new Tower4(new Tuple<int, int>(9, 7), grid,0.9f);
            base.Initialize();
            //Console.WriteLine(this.GraphicsDevice.Viewport.Width+" "+this.GraphicsDevice.Viewport.Height);//screen size is (800,480) default
            
        }

        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this.ex.LoadContent(Content,"Plain-Bagel");
            this.back.LoadContent(Content, "TowerMap");
            this.tower.LoadContent(Content, "TowerSprite");
            this.tower2.LoadContent(Content, "Tower2");
            this.tower3.LoadContent(Content, "Tower3");
            this.tower4.LoadContent(Content, "Tower4");
            // TODO: use this.Content to load your game content here
            //this.Content
        }

        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            // Allows the game to exit

            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) {
                Environment.Exit(0);
            }

            this.ex.Update(GraphicsDevice);
            base.Update(gameTime);
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.White);
            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            //this.ex.Draw(spriteBatch);
            this.grid.DrawGrid(spriteBatch);
            this.tower.Draw(spriteBatch);
            this.tower2.Draw(spriteBatch);
            this.tower3.Draw(spriteBatch);
            this.tower4.Draw(spriteBatch);
            this.back.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
