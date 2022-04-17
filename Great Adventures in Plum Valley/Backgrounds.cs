using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Great_Adventures_in_Plum_Valley
{
    class Backgrounds
    {
        public Texture2D texture;
        public Rectangle rectangle;
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }

    class Scrolling : Backgrounds
    {
        public Scrolling(Texture2D newTexture, Rectangle newRectangle)
        {
            texture = newTexture;
            rectangle = newRectangle;
        }

        public void Update(string direction, int backgroundID)
        {
            // 1 = clouds
            // 2 = hills
            // 3 = ground
            
            if (backgroundID == 1)
            {
                if (direction == "right")
                {
                    rectangle.X -= 1; //move clouds left if player moving right
                }

                if (direction == "left")
                {
                    rectangle.X += 1;
                }
            }

            if (backgroundID == 2)
            {
                if (direction == "right")
                {
                    rectangle.X -= 2; 
                }

                if (direction == "left")
                {
                    rectangle.X += 2;
                }
            }

            if (backgroundID == 3)
            {
                if (direction == "right")
                {
                    rectangle.X -= 3;
                }

                if (direction == "left")
                {
                    rectangle.X += 3;
                }
            }

        }
    }
}
