using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Great_Adventures_in_Plum_Valley
{
    class Backgrounds //objective 4.2
    {
        public Texture2D texture;
        public Rectangle rectangle;
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }

    class Still : Backgrounds
    {
        public Still(Texture2D newTexture)
        {
            texture = newTexture;
            rectangle = new Rectangle(0, 0, 800, 480);
        }
    }
    class Scrolling : Backgrounds
    {
        public Scrolling(Texture2D newTexture, Rectangle newRectangle)
        {
            texture = newTexture;
            rectangle = newRectangle;
        }

        public void Update(string direction, int backgroundID) //moves the backgrounds based on the bears direction of movement
        {
            if (direction == "right")
            {
                rectangle.X -= backgroundID;
            }

            if (direction == "left")
            {
                rectangle.X += backgroundID;
            }
        }
    }
}
