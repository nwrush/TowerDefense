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
            //graphics.PreferredBackBufferHeight=thing
            //graphics.PreferredBackBufferWidth = otherThing;
        }

        Background back;
        Grid grid;

        Enemy ex;
        StartingScreen Startscreen;
        protected override void Initialize() {
            this.IsMouseVisible = true;

            GV.content = Content;
            GV.spriteFont = Content.Load<SpriteFont>("font");

            //Level Initalizations
            this.grid = new Grid(GraphicsDevice);
            this.back = new Background();
            this.ex = new Enemy(new Vector2(1, 1), grid, 0.9f);

            Startscreen=new StartingScreen(new Rectangle(0,0,GraphicsDevice.Viewport.Width,GraphicsDevice.Viewport.Height));
            if (Input.isKeyDown(Keys.G)) {
                Startscreen.play = true;
            }
            base.Initialize();
            //screen size is (800,480) default
        }

        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Console.WriteLine("The chance that skynet will be born now is: " + Int64.MaxValue + "%");
            this.back.LoadContent(Content, "TowerMap");
            //projectile content is loaded asynchronously when the projectile is initialized
            foreach (Tower t in GV.TowerList) {//Load the textures for towers
                t.LoadContent(Content);
            }
            Player.LoadContent(Content);
        }

        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime) {
            Input.Update();//Update the keyboard state in the input class

            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) { Environment.Exit(0); }

            if (Startscreen.play) {
                GV.tick += 1;//Increment the tick ocunter by one
                Player.Update();

                for (int i = 0; i <= GV.ProjectileList.Count - 1; i++) {
                    GV.ProjectileList[i].Update();
                }
                foreach (Tower t in GV.TowerList) {
                    t.Update(GraphicsDevice);
                }
                for (int i = 0; i <= GV.EnemyList.Count - 1; i++) {
                    GV.EnemyList[i].Update(GraphicsDevice);
                }
                
                if (GV.EnemyList.Count == 0) {
                    Environment.Exit(2);
                }

                if (GV.tick % 250 == 0) {
                    new Enemy(new Vector2(), GV.grid, 0.5f);
                }
            }
            else { Startscreen.Update(); }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            if (this.Startscreen.play) {
                foreach (Projectile p in GV.ProjectileList) {//Draw the projectiles on the screen
                    p.Draw(spriteBatch);
                }
                foreach (Tower t in GV.TowerList) {//Draw the towers on the screen
                    t.Draw(spriteBatch);
                }
                foreach (Enemy e in GV.EnemyList) {//Draw the enemies on the screen
                    e.Draw(spriteBatch);
                }
                Player.Draw(spriteBatch);
                //Draw the background
                //this.back.Draw(spriteBatch);
            }
            else { Startscreen.Draw(spriteBatch); }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
