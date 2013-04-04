
#region Using Statements
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace Clunge_X
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        #region Fields

        GraphicsDeviceManager _graphics;
        ScreenManager screenManager;

        // By preloading any assets used by UI rendering, we avoid framerate glitches
        // when they suddenly need to be loaded in the middle of a menu transition.
        static readonly string[] preloadAssets =
        {
            "gradient",
        };


        #endregion

        #region Initialization

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Create the screen manager component.
            screenManager = new ScreenManager(this);

            Components.Add(screenManager);

            // Activate the first screens.
            screenManager.AddScreen(new BackgroundScreen(), null);
            screenManager.AddScreen(new MainMenuScreen(), null);
            
            Accelerometer.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            foreach (string asset in preloadAssets)
            {
                Content.Load<object>(asset);
            }
        }

        #endregion

        #region Draw

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            _graphics.GraphicsDevice.Clear(Color.Black);

            // The real drawing happens inside the screen manager component.
            base.Draw(gameTime);
        }

        #endregion
    }
}
