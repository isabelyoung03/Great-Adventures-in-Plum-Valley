using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Great_Adventures_in_Plum_Valley
{
    class Bear
    {
        public Texture2D texture;
        public int bearSkinID;
        public Vector2 vector;
        public List<Texture2D> bearSkins = new List<Texture2D>();

        public Bear(List<Texture2D> newBearSkins, Vector2 bearVector)
        {
            for (int i = 0; i < newBearSkins.Count; i++)
            {
                bearSkins.Add(newBearSkins[i]);
            }
            bearSkinID = 0;
            vector = bearVector;
            texture = bearSkins[bearSkinID];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, vector, Color.White);
        }
        
        public const float animationDelay = 0.2F; //delays animation by 0.2 seconds
        public float animationDelayRemaining = animationDelay;

        public void Update(Vector2 bearVector, string direction, GameTime gameTime, bool magicBootsOn, bool hurt) //objective 4.1
        {
            vector = bearVector;
            texture = bearSkins[bearSkinID];
            var timer = (float)gameTime.ElapsedGameTime.TotalSeconds;
            animationDelayRemaining -= timer;
            if (hurt)
            {
                if (direction == "right")
                {
                    bearSkinID = 8;
                }
                else if(direction == "right")
                {
                    bearSkinID = 9;
                }
                else
                {
                    bearSkinID = 8;
                }
            }
            else if (animationDelayRemaining <= 0 && direction != "none") //only animates after the delay and if the bear is moving
            {
                if (!(magicBootsOn || hurt))
                {
                    if (direction == "right")
                    {
                        if (bearSkinID == 0)
                        {
                            bearSkinID = 1;
                        }
                        else if (bearSkinID == 1)
                        {
                            bearSkinID = 0;
                        }
                        else
                        {
                            bearSkinID = 0;
                        }
                    }
                    if (direction == "left")
                    {
                        if (bearSkinID == 2)
                        {
                            bearSkinID = 3;
                        }
                        else if (bearSkinID == 3)
                        {
                            bearSkinID = 2;
                        }
                        else
                        {
                            bearSkinID = 2;
                        }
                    }
                }
                else if (magicBootsOn)
                {
                    if (direction == "right")
                    {
                        if (bearSkinID == 4)
                        {
                            bearSkinID = 5;
                        }
                        else if (bearSkinID == 5)
                        {
                            bearSkinID = 4;
                        }
                        else
                        {
                            bearSkinID = 4;
                        }
                    }
                    if (direction == "left")
                    {
                        if (bearSkinID == 6)
                        {
                            bearSkinID = 7;
                        }
                        else if (bearSkinID == 7)
                        {
                            bearSkinID = 6;
                        }
                        else
                        {
                            bearSkinID = 6;
                        }
                    }
                }
                animationDelayRemaining = animationDelay;
            }
        }
    }
}