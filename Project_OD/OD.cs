using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System;


namespace Project_OD
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class OD : Game
    {
        public static ContentManager content;
        GraphicsDeviceManager graphics;
        SpriteBatch menuBatch;
        SpriteBatch igBatch;
        Buttons button;

        Splash splash;
        GameMenu gameMenu;

        Map map;
        Collision collision;
        Player hero;
        Enemy antagonist;
        private List<Enemy> antagonists;
        Camera gameCamera;
        Physics gamePhysics;
        //gamestates
        private static gameStates gamestate = gameStates.InGame;
        public static gameStates getState() { return gamestate; }
        public static void setState(gameStates state) { gamestate = state; }

        public static int ScreenWidth = 1600;
        public static int ScreenHeight = 960;

        //init Level
        public static int lvlID = 0;

        public OD()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = ScreenWidth;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = ScreenHeight;   // set this value to the desired height of your window
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            content = Content;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            menuBatch = new SpriteBatch(GraphicsDevice);
            igBatch = new SpriteBatch(GraphicsDevice);
            //menu stuff
            splash = new Splash();
            gameMenu = new GameMenu();
            //ig stuff
            map = new Map(lvlID);
            collision = new Collision(lvlID);
            collision.IsCollision();
            hero = new Player();
            hero.SetEntity(new Vector2(0, 720), 50, 46, "spritesheet-test2_1.png", null, 200, 5, 100, 5, 50, 0, 7, 2, collision.rectangles);
            antagonist = new Enemy();
            antagonists = new List<Enemy>() { };
            antagonist.setEnemies(antagonists, collision);
            antagonists.Add(antagonist);
            gameCamera = new Camera(1600);
            gamePhysics = new Physics();
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            switch (gamestate)
            {
                case gameStates.Start:
                    {
                        setState(gameStates.Splash);
                    }
                    break;
                case gameStates.Splash:
                    {
                        setState(gameStates.Splash);
                        splash.Update();
                    }
                    break;
                case gameStates.GameMenu:
                    {
                        setState(gameStates.GameMenu);
                        //gameMenu.Update();
                    }
                    break;
                case gameStates.StartGame:
                    break;
                case gameStates.GameOptions:
                    break;
                case gameStates.InGame:
                    OD.setState(gameStates.InGame);
                    {

                    }
                    break;
                case gameStates.Exit:
                    Exit();
                    break;
                default:
                    break;
            }

            InputManager.Update();
            //menu stuff
            if (gamestate == gameStates.GameMenu)
            {
                gameMenu.Update();
            }
            //ig stuff
            if (gamestate == gameStates.InGame)
            {
                hero.Update(gameTime, 20, antagonists, lvlID);
                gameCamera.Update(hero.Position);
                foreach (var antagonist in antagonists)
                {
                    antagonist.Update(gameTime, 20, hero, lvlID);
                }
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (gamestate == gameStates.GameMenu)
            {
                menuBatch.Begin();
                gameMenu.Draw(menuBatch);
                menuBatch.End();
            }

            if (gamestate == gameStates.InGame)
            {

                igBatch.Begin(SpriteSortMode.Deferred,
                              BlendState.AlphaBlend,
                              null, null, null, null,
                              gameCamera.ViewMatrix);

                map.DrawMap(igBatch);
                hero.Draw(igBatch, hero.ATK, hero.skill);

                foreach (var antagonist in antagonists)
                {
                    antagonist.Draw(igBatch);
                }

                igBatch.End();
            }
            base.Draw(gameTime);
        }
    }
}