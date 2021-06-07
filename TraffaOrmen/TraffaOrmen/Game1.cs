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

        static Scen nuvarandeScen;
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

            BytScen(new MenyScen());
        }

        protected override void Update(GameTime gameTime)
        {

            Input.Update();

            nuvarandeScen.Update();
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            nuvarandeScen.Draw(_spriteBatch);

            base.Draw(gameTime);
        }

        public static void BytScen(Scen nyScen)
        {
            nuvarandeScen = nyScen;
            nuvarandeScen.Initialize(contentManager);
        }
    }
}
