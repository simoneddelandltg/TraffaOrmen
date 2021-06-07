using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TraffaOrmen
{
    class Input
    {
        public static MouseState mus;
        public static MouseState gammalMus;


        public static void Update()
        {
            gammalMus = mus;
            mus = Mouse.GetState();
        }

        public static bool VänsterMusTryckt()
        {
            if (mus.LeftButton == ButtonState.Pressed && gammalMus.LeftButton == ButtonState.Released)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
