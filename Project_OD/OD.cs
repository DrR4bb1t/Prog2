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
        InputManager input;
        Map map;
        Player player;
        Texture2D avatar;

        SpriteAnimation sprite;
        KeyboardState kbstate;


        gameStates gamestate = gameStates.Start;

        public OD()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1600;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 960;   // set this value to the desired height of your window
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
            map = new Map();
            //avatar = Content.Load<Texture2D>("spritesheet-test");
            //player = new Player(avatar, 2, 7);
            //player = new Player()
            //{
            //    Texture = avatar,
            //    Position = new Vector2(0, 850),
            //    Speed = 100,
            //    SWidth = 1
            //};
            //player.LoadTexture();
            //player = new Player(content.Load<Texture2D>("spritesheet-demo"), 1, 53, 48);
            //player.Position = new Vector2(0, 850);

            sprite = new SpriteAnimation(content.Load<Texture2D>("spritesheet-test2_1.png"), 7, 2);
            sprite.AddAnimation("R", 1);
            sprite.AddAnimation("L", 2);
            sprite.animation = "R";
            sprite.position = new Vector2(0, 850);
            sprite.isLooping = true;
            sprite.FPS = 20;
            map.LoadTextures();



            
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

            kbstate = Keyboard.GetState();

            if (kbstate.IsKeyDown(Keys.Right))
            {
                sprite.animation = "R";
                sprite.position.X += (float)(gameTime.ElapsedGameTime.TotalSeconds * 200);
                sprite.Update(gameTime);
            }
            else if (kbstate.IsKeyDown(Keys.Left))
            {
                sprite.animation = "L";
                sprite.position.X -= (float)(gameTime.ElapsedGameTime.TotalSeconds * 200);
                sprite.Update(gameTime);
            }

            //sprite.Update(gameTime);

            //InputManager.Update();
            //player.Update(gameTime);
            //player.Update(gameTime);

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


            spriteBatch.Begin();

            //player.Draw(spriteBatch);
            //spriteBatch.Draw(player.Texture, player.Position, player.SrcRect, Color.White, 0f, player.Origin, 1.0f, SpriteEffects.None, 0);
            map.DrawMap(spriteBatch, 1);

            sprite.Draw(spriteBatch);

            //map.DrawBackgroundLayer(spriteBatch);
            //map.DrawForegroundLayer(spriteBatch);

            spriteBatch.End();
            //player.Draw(spriteBatch, new Vector2(0, 850));

            // TODO: Add your drawing code here

            base.Draw(gameTime);

        }
    }
}
