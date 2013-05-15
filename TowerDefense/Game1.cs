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
        protected override void Initialize() {
            // TODO: Add your initialization logic here
            this.ex = new Sprite(new Vector2(5.0f, 5.0f), new Vector2(5.0f, 5.0f));
            this.back = new Background();
            base.Initialize();
            //Console.WriteLine(this.GraphicsDevice.Viewport.Width+" "+this.GraphicsDevice.Viewport.Height);//screen size is (800,480) default
            this.grid = new Grid(GraphicsDevice);
        }

        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            this.ex.LoadContent(Content,"Plain-Bagel");
            this.back.LoadContent(Content, "TowerMap");
            // TODO: use this.Content to load your game content here
            //this.Content
        }

        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

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

            this.ex.Draw(spriteBatch);
            this.grid.DrawGrid(spriteBatch);
            //this.back.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}