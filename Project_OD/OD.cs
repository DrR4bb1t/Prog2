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
        SpriteBatch spriteBatch_2;

        SpriteFont font;

        Splash splash;
        GameMenu gameMenu;

        Camera camera;
        Map map;
        Collision collision;
        int mapNmbr = 1;
        //private List<Rectangle> rectangles;
        private List<Enemy> enemys;
        Player player;
        Player NPC;
        Enemy enemy;
        Enemy enemy_2;
        Enemy enemy_3;
        Boss boss;

        Texture2D playerHPDisplay;

        Texture2D hpBar;
        Texture2D playerHeart;

        Buttons button;

        bool rectangleSwitcher = false;

        private static gameStates gamestate = gameStates.GameMenu;
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
            spriteBatch_2 = new SpriteBatch(GraphicsDevice);

            splash = new Splash();
            gameMenu = new GameMenu();

            camera = new Camera(4900);
            map = new Map(2);
            collision = new Collision(2);
            //rectangles = new List<Rectangle>(){};
            //for (int y = 0; y < map.tileMapHeight; y++)
            //{
            //    for (int x = 0; x < map.tileMapWidth; x++)
            //    {
            //        if (map.lvl1_Forelayer[y, x] == 2|| map.lvl1_Forelayer[y, x] == 17)
            //        {
            //            rectangles.Add(new Rectangle(x*64, y*64, 64, 64));
            //        }
            //    }
            //}
            collision.IsCollision();
            enemys = new List<Enemy>() { };
            //get enemy data

            hpBar = OD.content.Load<Texture2D>("Project_OD_Assets/HUD/lifebar");
            playerHeart = OD.content.Load<Texture2D>("Project_OD_Assets/HUD/HP/heart0001");

            button = new Buttons(new Vector2(10, 10), "Textures/Button/start_EN");

            player = new Player();
            NPC = new Player();

            enemy = new Enemy();
            enemy.enemyinit(new Vector2(400, 720));
            enemy.SetEntity(new Vector2(400, 720), 50, 46, "spritesheet-test2_1.png", null, 120, 1, 100, 10, 50, 0, 7, 2, collision.rectangles);

            enemy_2 = new Enemy();
            enemy_2.enemyinit(new Vector2(1200, 720));
            enemy_2.SetEntity(new Vector2(1200, 720), 50, 46, "spritesheet-test2_1.png", null, 120, 1, 100, 10, 50, 0, 7, 2, collision.rectangles);
            
            enemy_3 = new Enemy();
            enemy_3.enemyinit(new Vector2(1800, 720));
            enemy_3.SetEntity(new Vector2(2300, 720), 50, 46, "spritesheet-test2_1.png", null, 120, 1, 100, 10, 50, 0, 7, 2, collision.rectangles);


            player.SetEntity(new Vector2(64, 720), 50, 46, "spritesheet-test2_1.png", null, 200, 5, 100, 5, 50, 0, 7, 2, collision.rectangles);
            NPC.SetEntity(new Vector2(2300, 720), 50, 46, "spritesheet-test2_1.png", null, 200, 5, 100, 5, 50, 0, 7, 2, collision.rectangles);

            boss = new Boss();
            boss.enemyinit(new Vector2(2200, 720));
            boss.SetEntity(new Vector2(2300, 720), 50, 46, "spritesheet-test2_1.png", null, 120, 1, 100, 10, 50, 0, 7, 2, collision.rectangles);

            font = OD.content.Load<SpriteFont>("fonts/arial");

            Physics physics = new Physics();
            enemys.Add(enemy);
            enemys.Add(enemy_2);
            enemys.Add(enemy_3);
            enemys.Add(boss);


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

            if(gamestate == gameStates.GameMenu)
            {
                gameMenu.Update();
            }
            
            camera.Update(player.Position);
           

            enemy.Update(gameTime, 20, player);
            enemy_2.Update(gameTime, 20, player);
            enemy_3.Update(gameTime, 20, player);
            boss.Update(gameTime, 20, player);

            camera.Update(player.Position);
            player.Update(gameTime, 20,enemys);



            
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

            if(gamestate == gameStates.GameMenu)
            {
                spriteBatch_2.Begin();
                gameMenu.Draw(spriteBatch_2);
                spriteBatch_2.End();

            }

            if (gamestate == gameStates.InGame)
            {

                spriteBatch.Begin(SpriteSortMode.Deferred,
                              BlendState.AlphaBlend,
                              null, null, null, null,
                              camera.ViewMatrix);

                map.DrawMap(spriteBatch);
                enemy.Draw(spriteBatch);
                enemy_2.Draw(spriteBatch);
                enemy_3.Draw(spriteBatch);
                boss.Draw(spriteBatch);

                player.Draw(spriteBatch, player.ATK, player.skill);
                NPC.Draw(spriteBatch);

                if (player.rect.Intersects(NPC.rect))
                {
                    if (InputManager.IsKeyPressed(Keys.P))
                        rectangleSwitcher = true;
                    if (rectangleSwitcher == true)
                    {
                        spriteBatch.DrawString(font, "you are doomed!", new Vector2(NPC.Position.X, NPC.Position.Y - 30), Color.Black);
                        if (!player.rect.Intersects(NPC.rect) && InputManager.IsKeyPressed(Keys.P))
                        {
                            rectangleSwitcher = false;
                        }
                    }
                    else rectangleSwitcher = false;
                }

                foreach (var enemy in enemys)
                {
                    spriteBatch.Draw(hpBar, new Rectangle((int)enemy.Position.X - 30, (int)enemy.Position.Y - 20, enemy.Hp, 10), Color.White);
                }
                if (player.Hp > 60)
                {
                    spriteBatch.Draw(playerHeart, new Rectangle((int)camera.getPosition.X + 100, (int)camera.getPosition.Y + 860, 50, 50), Color.White);
                    spriteBatch.Draw(playerHeart, new Rectangle((int)camera.getPosition.X + 170, (int)camera.getPosition.Y + 860, 50, 50), Color.White);
                    spriteBatch.Draw(playerHeart, new Rectangle((int)camera.getPosition.X + 240, (int)camera.getPosition.Y + 860, 50, 50), Color.White);
                }
                if (player.Hp > 30)
                {
                    spriteBatch.Draw(playerHeart, new Rectangle((int)camera.getPosition.X + 100, (int)camera.getPosition.Y + 860, 50, 50), Color.White);
                    spriteBatch.Draw(playerHeart, new Rectangle((int)camera.getPosition.X + 170, (int)camera.getPosition.Y + 860, 50, 50), Color.White);
                }
                if (player.Hp > 0)
                {
                    spriteBatch.Draw(playerHeart, new Rectangle((int)camera.getPosition.X + 100, (int)camera.getPosition.Y + 860, 50, 50), Color.White);
                }

                spriteBatch.End();

            }

            // TODO: Add your drawing code here

            base.Draw(gameTime);

        }
    }
}