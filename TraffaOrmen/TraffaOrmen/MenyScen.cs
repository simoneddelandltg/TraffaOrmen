using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TraffaOrmen
{
    class MenyScen
    {
        SpriteFont arial;
        Texture2D knappBild;
        Rectangle knappRect;
        string välkomstText = "Träffa ormen!";
        Vector2 välkomstPosition;

        public void Initialize(ContentManager Content)
        {
            arial = Content.Load<SpriteFont>("arial");         
            knappBild = Content.Load<Texture2D>("button");
            knappRect = new Rectangle(400 - knappBild.Width / 2, 360, knappBild.Width, knappBild.Height);
            välkomstPosition = new Vector2(400 - arial.MeasureString(välkomstText).X / 2, 100);
        }

        public void Update()
        {
            if (Input.VänsterMusTryckt() && knappRect.Contains(Input.mus.Position))
            {
                Game1.BytScen(1);
            }
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            

            _spriteBatch.Begin();
            _spriteBatch.DrawString(arial, välkomstText, välkomstPosition, Color.White);
            _spriteBatch.Draw(knappBild, knappRect, Color.White);
            _spriteBatch.End();
        }




    }
}
