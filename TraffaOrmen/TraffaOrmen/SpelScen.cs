using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TraffaOrmen
{
    class SpelScen : Scen
    {
        Random slump = new Random();

        List<Rectangle> ormar = new List<Rectangle>();
        Texture2D ormBild;
        int startAntalOrmar = 5;
        int updatesMellanNyaOrmar = 90;
        int updatesTillNästaOrm = 90;

        public override void Initialize(ContentManager Content)
        {
            ormBild = Content.Load<Texture2D>("snake");
            ormar.Clear();
            for (int i = 0; i < startAntalOrmar; i++)
            {
                LäggTillOrm();
            }
            updatesTillNästaOrm = updatesMellanNyaOrmar;
        }

        public override void Update()
        {
            updatesTillNästaOrm--;
            if (updatesTillNästaOrm <= 0)
            {
                LäggTillOrm();
                updatesTillNästaOrm = updatesMellanNyaOrmar;
            }

            if (Input.VänsterMusTryckt())
            {
                for (int i = ormar.Count - 1; i >= 0; i--)
                {
                    if (ormar[i].Contains(Input.mus.Position))
                    {
                        ormar.RemoveAt(i);
                        break;
                    }
                }
            }

            if (ormar.Count == 0)
            {
                Game1.BytScen(new MenyScen());
            }
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin();

            foreach (Rectangle orm in ormar)
            {
                _spriteBatch.Draw(ormBild, orm, Color.White);
            }

            _spriteBatch.End();
        }

        /// <summary>
        /// Lägger till en ny orm på en slumpad position
        /// </summary>
        void LäggTillOrm()
        {
            int nyOrmX = slump.Next(0, 800 - ormBild.Width);
            int nyOrmY = slump.Next(0, 480 - ormBild.Height);
            Rectangle nyOrmRect = new Rectangle(nyOrmX, nyOrmY, ormBild.Width, ormBild.Height);
            ormar.Add(nyOrmRect);
        }
    }
}
