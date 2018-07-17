using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
<<<<<<< HEAD
using System.Collections.Generic;
=======
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System;
>>>>>>> Map

namespace Project_OD
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class OD : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Map map;


        //List<Texture2D> tile = new List<Texture2D>();

        //int[,] tileMap = new int[,]
        //{
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        //    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, },
        //    { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, },
        //};

        //int tileWidth = 64;
        //int tileHeight = 64;

        gameStates gamestate = gameStates.Start;

        public OD()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1600;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 960;   // set this value to the desired height of your window
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
<<<<<<< HEAD
        
=======
            IsMouseVisible = true;
            
>>>>>>> Map
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
<<<<<<< HEAD
            
=======
            spriteBatch = new SpriteBatch(GraphicsDevice);
            map = new Map();

            Texture2D texture;

            //map.LoadTextures();

            texture = Content.Load<Texture2D>("Tiles/empty");
            map.tile.Add(texture);

            texture = Content.Load<Texture2D>("Tiles/earth");
            map.tile.Add(texture);

            texture = Content.Load<Texture2D>("Tiles/grass");
            map.tile.Add(texture);

            texture = Content.Load<Texture2D>("Tiles/mushroomRed");
            map.tile.Add(texture);

            texture = Content.Load<Texture2D>("Tiles/tree2Bottom");
            map.tile.Add(texture);

            texture = Content.Load<Texture2D>("Tiles/tree2Top");
            map.tile.Add(texture);

            texture = Content.Load<Texture2D>("Tiles/signRight");
            map.tile.Add(texture);
>>>>>>> Map

            
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
                    break;
                case gameStates.Splash:
                    break;
                case gameStates.GameMenu:
                    break;
                case gameStates.StartGame:
                    break;
                case gameStates.GameOptions:
                    break;
                case gameStates.InGame:
                    break;
                case gameStates.Exit:
                    break;
                default:
                    break;
            }

            InputManager.Update();

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

<<<<<<< HEAD
=======
            spriteBatch.Begin();

            map.DrawBackgroundLayer(spriteBatch);
            map.DrawForegroundLayer(spriteBatch);

            //int tileMapWidth = tileMap.GetLength(1);
            //int tileMapHeight = tileMap.GetLength(0);

            //for (int x = 0; x < tileMapWidth; x++)
            //{
            //    for (int y = 0; y < tileMapHeight; y++)
            //    {
            //        int textureIndex = tileMap[y, x];
            //        Texture2D texture = tile[textureIndex];

            //        spriteBatch.Draw(texture, new Rectangle(x * tileWidth, y * tileHeight, tileWidth, tileHeight), Color.White);
            //    }
            //}



            spriteBatch.End();

            // TODO: Add your drawing code here

>>>>>>> Map
            base.Draw(gameTime);

        }
    }
}
