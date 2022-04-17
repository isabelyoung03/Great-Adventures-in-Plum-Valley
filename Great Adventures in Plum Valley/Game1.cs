using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Threading;

namespace Great_Adventures_in_Plum_Valley
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D titleScreenBackground;
        private Texture2D startMessage;
        private Texture2D fileSelectionBackground;
        public bool displayTitleScreen = true;
        public bool fileSelection = false;
        int fileNumber;
        public bool gameplay = false;
        string movement;

        Scrolling scrollingClouds1;
        Scrolling scrollingClouds2;

        Scrolling scrollingHills1;
        Scrolling scrollingHills2;

        Scrolling scrollingGround1;
        Scrolling scrollingGround2;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

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
            titleScreenBackground = Content.Load<Texture2D>("Title Screen");
            fileSelectionBackground = Content.Load<Texture2D>("Save File Screen");
            startMessage = Content.Load<Texture2D>("Start message");
            Song introMusic = Content.Load<Song>("Lively Meadow");
            MediaPlayer.Play(introMusic);

            scrollingClouds1 = new Scrolling(Content.Load<Texture2D>("Clouds1"), new Rectangle(0, 0, 800, 500));
            scrollingClouds2 = new Scrolling(Content.Load<Texture2D>("Clouds2"), new Rectangle(800, 0, 800, 500));

            scrollingHills1 = new Scrolling(Content.Load<Texture2D>("Hills1"), new Rectangle(0, 0, 800, 500));
            scrollingHills2 = new Scrolling(Content.Load<Texture2D>("Hills2"), new Rectangle(800, 0, 800, 500));

            scrollingGround1 = new Scrolling(Content.Load<Texture2D>("Ground1"), new Rectangle(0, 0, 800, 500));
            scrollingGround2 = new Scrolling(Content.Load<Texture2D>("Ground2"), new Rectangle(800, 0, 800, 500));
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //scrolling background

            
            KeyboardState state = Keyboard.GetState();

            if (displayTitleScreen == true)
            {
                if (state.IsKeyDown(Keys.Space))
                {
                    displayTitleScreen = false;
                    fileSelection = true;
                }
            }

            if (fileSelection == true)
            {
                if (state.IsKeyDown(Keys.A))
                {
                    fileSelection = false;
                    gameplay = true;
                    fileNumber = 1;

                }

                if (state.IsKeyDown(Keys.B))
                {
                    fileSelection = false;
                    gameplay = true;
                    fileNumber = 2;
                }

                if (state.IsKeyDown(Keys.C))
                {
                    fileSelection = false;
                    gameplay = true;
                    fileNumber = 3;
                }
            }

            if (gameplay == true)
            {

                if (scrollingClouds1.rectangle.X + scrollingClouds1.texture.Width <= 0)
                {
                    scrollingClouds1.rectangle.X = scrollingClouds2.rectangle.X + scrollingClouds2.texture.Width;
                }

                if (scrollingClouds2.rectangle.X + scrollingClouds2.texture.Width <= 0)
                {
                    scrollingClouds2.rectangle.X = scrollingClouds1.rectangle.X + scrollingClouds1.texture.Width;
                }
                ///// 
                if (scrollingHills1.rectangle.X + scrollingHills1.texture.Width <= 0)
                {
                    scrollingHills1.rectangle.X = scrollingHills2.rectangle.X + scrollingHills2.texture.Width;
                }

                if (scrollingHills2.rectangle.X + scrollingHills2.texture.Width <= 0)
                {
                    scrollingHills2.rectangle.X = scrollingHills1.rectangle.X + scrollingHills1.texture.Width;
                }
                /////
                if (scrollingGround1.rectangle.X + scrollingGround1.texture.Width <= 0)
                {
                    scrollingGround1.rectangle.X = scrollingGround2.rectangle.X + scrollingGround2.texture.Width;
                }

                if (scrollingGround2.rectangle.X + scrollingGround2.texture.Width <= 0)
                {
                    scrollingGround2.rectangle.X = scrollingGround1.rectangle.X + scrollingGround1.texture.Width;
                }
                

                if (state.IsKeyDown(Keys.Right))
                {
                    movement = "right";
                    scrollingClouds1.Update(movement, 1);
                    scrollingClouds2.Update(movement, 1);

                    scrollingHills1.Update(movement, 2);
                    scrollingHills2.Update(movement, 2);

                    scrollingGround1.Update(movement, 3);
                    scrollingGround2.Update(movement, 3);

                }

                if (state.IsKeyDown(Keys.Left))
                {
                    movement = "left";
                    scrollingClouds1.Update(movement, 1);
                    scrollingClouds2.Update(movement, 1);

                    scrollingHills1.Update(movement, 2);
                    scrollingHills2.Update(movement, 2);

                    scrollingGround1.Update(movement, 3);
                    scrollingGround2.Update(movement, 3);
                }

                if (state.IsKeyDown(Keys.Up))
                {
                    movement = "jump";
                }
                
            }

            base.Update(gameTime);
            
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SkyBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
            
            spriteBatch.Begin();

            if (displayTitleScreen == true)
            {
                spriteBatch.Draw(titleScreenBackground, new Rectangle(0, 0, 800, 480), Color.White);
                spriteBatch.Draw(startMessage, new Vector2(230, 210), Color.White);
            }

            if (fileSelection == true)
            {
                spriteBatch.Draw(fileSelectionBackground, new Rectangle(0, 0, 800, 480), Color.White);
            }

            if (gameplay == true)
            {
                scrollingClouds1.Draw(spriteBatch);
                scrollingClouds2.Draw(spriteBatch);

                scrollingHills1.Draw(spriteBatch);
                scrollingHills2.Draw(spriteBatch);

                scrollingGround1.Draw(spriteBatch);
                scrollingGround2.Draw(spriteBatch);
            }

            spriteBatch.End();
        }
        
    }
}