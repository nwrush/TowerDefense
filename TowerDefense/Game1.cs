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


/*IMAGE CREDITS
 * Bagel: https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQN6ceU89z41wvMauoIOxfgQvili2p38ySFMtS4sHbMeVSK4M1b *applause for the mighty bagel attacking the base*
 * Exploded Plane From the end: http://img144.imageshack.us/img144/5272/decommov0.jpg *applause for the merits of google key words, and how "moon" can get you this*
 */

namespace TowerDefense {
    public class Game1 : Microsoft.Xna.Framework.Game {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        Background back;
        Grid grid;

        Texture2D losing;

        StartingScreen Startscreen;
        protected override void Initialize() {
            this.IsMouseVisible = true;

            GV.content = Content;
            GV.spriteFont = Content.Load<SpriteFont>("font");

            Player.sprite = this.spriteBatch;
            //Level Initalizations
            this.grid = new Grid(GraphicsDevice);
            this.back = new Background();
            //this.ex = new Enemy(new Vector2(1, 1), grid, 0.9f);

            Startscreen=new StartingScreen(new Rectangle(0,0,GraphicsDevice.Viewport.Width,GraphicsDevice.Viewport.Height));
            base.Initialize();
            //screen size is (800,480) default
        }

        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Console.WriteLine("The chance that skynet will be born now is: " + Int64.MaxValue + "%");

            this.back.LoadContent(Content, "TowerMap");
            this.losing = GV.content.Load<Texture2D>("losing");
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
            if (Input.isKeyDown(Keys.G)) {
                Startscreen.play = true;
            }
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) { Environment.Exit(0); }

            if (GV.PLAY==1) {
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

                if (GV.tick % 100 == 0) {
                    //new Enemy(new Vector2(1, 1), grid, 0.9f);
                    new Enemy();
                }
            }
            else if (GV.PLAY==0) {
                    Startscreen.Update();
            }
            else if (GV.PLAY==2) {
                if (Input.isKeyDown(Keys.R)) {//Reset
                    Startscreen.play = true;
                    GV.Lost = false;
                    Player.Score = 0;
                    Player.Health = 100;
                    Player.Money = 500;
                    GV.EnemyList = new List<Enemy>();
                    GV.TowerList = new List<Tower>();
                    GV.ProjectileList = new List<Projectile>();
                    GV.PLAY = 1;
                }
            }
            else { Console.WriteLine("WAT"); Environment.Exit(int.MaxValue); }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            if (GV.PLAY==1) {
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
                this.back.Draw(spriteBatch);
            }
            else if (GV.PLAY==0) {
                Startscreen.Draw(spriteBatch);
            }
            else if (GV.PLAY==2) {
                spriteBatch.Draw(this.losing, new Vector2(0, 0), Color.White);
            }

            C3.XNA.Primitives2D.DrawRectangle(spriteBatch,new Rectangle(200,240,1,1),Color.Black);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
