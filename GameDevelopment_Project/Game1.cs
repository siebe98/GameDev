using GameDevelopment_Project.Klassen;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevelopment_Project
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player = new Player();
        KeyboardState CurrentStateKeyboard;
        //misschien niet nodig
        KeyboardState PreviousStateKeyboard;
        // random  waarde misschien nog aanpassen
        float MoveSpeedPlayer = 5;
        //enum GameState
        //{
        //    Menu,
        //    Level1,
        //    Level2,
        //    TheEnd
        //}
        ////start met menu
        //GameState StateOfGame = GameState.Menu;

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
            IsMouseVisible = true;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Vector2 PlayerPosition = new Vector2(GraphicsDevice.Viewport.TitleSafeArea.X, GraphicsDevice.Viewport.TitleSafeArea.Y + GraphicsDevice.Viewport.TitleSafeArea.Height / 2);
            player.Initialize(Content.Load<Texture2D>("idle"), PlayerPosition);

            // TODO: use this.Content to load your game content here
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

            // TODO: Add your update logic here
            PreviousStateKeyboard = CurrentStateKeyboard;
            CurrentStateKeyboard = Keyboard.GetState();

            UpdatePlayerPosition(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            spriteBatch.Begin();
            player.Draw(spriteBatch);
            spriteBatch.End();
        }

        private void UpdatePlayerPosition(GameTime gameTime)
        {
            if (CurrentStateKeyboard.IsKeyDown(Keys.Left))
            {
                player.Position.X -= MoveSpeedPlayer;
            }
            if (CurrentStateKeyboard.IsKeyDown(Keys.Right))
            {
                player.Position.X += MoveSpeedPlayer;
            }
            if (CurrentStateKeyboard.IsKeyDown(Keys.Space))
            {
                player.Position.Y -= MoveSpeedPlayer;
            }
            if (CurrentStateKeyboard.IsKeyDown(Keys.Down))
            {
                player.Position.Y += MoveSpeedPlayer;
            }
            //speler buiten veld detectie
            player.Position.X = MathHelper.Clamp(player.Position.X, 0, GraphicsDevice.Viewport.Width - player.Width);
            player.Position.Y = MathHelper.Clamp(player.Position.Y, 0, GraphicsDevice.Viewport.Height - player.Height);

        }
    }
}
