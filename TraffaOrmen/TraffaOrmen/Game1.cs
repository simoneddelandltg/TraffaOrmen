using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TraffaOrmen
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // 0 för meny, 1 för spelet
        static int scen = 0;
        static MenyScen meny = new MenyScen();
        static SpelScen spel = new SpelScen();
        static ContentManager contentManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            contentManager = Content;
            IsMouseVisible = true;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            BytScen(0);
        }

        protected override void Update(GameTime gameTime)
        {

            Input.Update();
            
            switch (scen)
            {
                case 0:
                    meny.Update();
                    break;
                case 1:
                    spel.Update();
                    break;
            }    

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            switch (scen)
            {
                case 0:
                    meny.Draw(_spriteBatch);
                    break;
                case 1:
                    spel.Draw(_spriteBatch);
                    break;
            }

            base.Draw(gameTime);
        }

        public static void BytScen(int nyScen)
        {
            scen = nyScen;

            switch (scen)
            {
                case 0:
                    meny.Initialize(contentManager);
                    break;
                case 1:
                    spel.Initialize(contentManager);
                    break;
            }
        }
    }
}
