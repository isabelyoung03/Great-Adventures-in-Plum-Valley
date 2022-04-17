using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Great_Adventures_in_Plum_Valley
{
    class Platform
    {
        public List<Vector2> platformVectors = new List<Vector2>();
        public Texture2D texture;
        public Texture2D bearSkin;
        public int totalPlatforms;

        public Platform(Texture2D newTexture, Vector2[] newVectors, Texture2D newBearSkin)
        {
            totalPlatforms = newVectors.Length;
            texture = newTexture;
            for (int i = 0; i < totalPlatforms; i++)
            {
                platformVectors.Add(newVectors[i]);
            }
            bearSkin = newBearSkin;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < totalPlatforms; i++)
            {
                spriteBatch.Draw(texture, platformVectors[i], Color.White);
            }
        }

        public string Update(string objectMovement, Vector2 bearVector, int bearSpeed, bool move) //moves the platforms based on the bears direction of movement, and checks if the bear collides with a platform
        {
            string collisionType = "none";
            for (int i = 0; i < totalPlatforms; i++)
            {
                if (move == true && objectMovement == "right")
                {
                    Vector2 currentVector = platformVectors[i];
                    currentVector.X = currentVector.X - bearSpeed;
                    platformVectors[i] = currentVector;
                }
                if (move == true && objectMovement == "left")
                {
                    Vector2 currentVector = platformVectors[i];
                    currentVector.X = platformVectors[i].X + bearSpeed;
                    platformVectors[i] = currentVector;
                }
                if (Game1.Collision(bearVector, bearSkin.Width, bearSkin.Height, platformVectors[i], texture.Width, texture.Height) != "none")
                {
                    collisionType = Game1.Collision(bearVector, bearSkin.Width, bearSkin.Height, platformVectors[i], texture.Width, texture.Height);
                }
            }
            return collisionType;
        }
    }
}
