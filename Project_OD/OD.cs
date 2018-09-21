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
        SpriteBatch spriteBatch;

        Splash splash;
        GameMenu gameMenu;

        Camera camera;
        Map map;
        int mapNmbr = 1;
        private List<Rectangle> rectangles;
        private List<Enemy> enemys;
        Player player;
        Enemy enemy;

        private static gameStates gamestate = gameStates.InGame;
        public static gameStates getState() { return gamestate; }
        public static void setState(gameStates state) { gamestate = state; }

        public static int ScreenWidth = 1600;
        public static int ScreenHeight = 960;

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
            // Create a new SpriteBatch, which can be used to draw textures.

            spriteBatch = new SpriteBatch(GraphicsDevice);

            splash = new Splash();
            gameMenu = new GameMenu();
            gameMenu.LoadButtonTextures();

            camera = new Camera(1600);
            map = new Map();
            rectangles = new List<Rectangle>(){};
            for (int y = 0; y < map.tileMapHeight; y++)
            {
                for (int x = 0; x < map.tileMapWidth; x++)
                {
                    if (map.lvl1_Forelayer[y, x] == 2)
                    {
                        rectangles.Add(new Rectangle(x*64, y*64, 64, 64));
                    }
                }
            }
            enemys = new List<Enemy>() { };
            //get enemy data
            

            player = new Player();
            enemy = new Enemy();
            enemy.enemyinit(new Vector2(400, 850));
            enemy.SetEntity(new Vector2(400, 850), 50, 46, "spritesheet-test2_1.png", null, 120, 1, 100, 1, 50, 0, 7, 2, rectangles);
            player.SetEntity(new Vector2(0, 850), 50, 46, "spritesheet-test2_1.png", null, 200, 3, 100, 5, 50, 0, 7, 2, rectangles);
            Physics physics = new Physics();


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
                        gameMenu.Update();
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
            
            camera.Update(player.Position);
           

            if (gamestate == gameStates.InGame)
            {
                enemy.Update(gameTime, 20, player);
                camera.Update(player.Position);
                player.Update(gameTime, 20);
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

                gameMenu.Draw(spriteBatch);
            }

                spriteBatch.Begin(SpriteSortMode.Deferred,
                              BlendState.AlphaBlend,
                              null, null, null, null,
                              camera.ViewMatrix);

            map.DrawMap(spriteBatch, 1);
            enemy.Draw(spriteBatch);
            player.Draw(spriteBatch, player.ATK, player.skill);



            spriteBatch.End();


            // TODO: Add your drawing code here

            base.Draw(gameTime);

        }
    }
}
