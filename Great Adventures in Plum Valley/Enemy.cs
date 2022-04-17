using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace Great_Adventures_in_Plum_Valley
{
    class Enemy
    {
        public Texture2D texture;
        public List<Vector2> enemyVectors = new List<Vector2>();
        public int totalEnemies;
        public Texture2D bearSkin;
        public string blobDirection = "left";
        public string spiderDirection = "left";
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < totalEnemies; i++)
            {
                spriteBatch.Draw(texture, enemyVectors[i], Color.White);
            }
        }

    }

    class Spiders : Enemy
    {
        public int spiderSpeed;
        public int spiderDistanceFromStart;
        public Spiders(Texture2D newTexture, Vector2[] newVectors, int newLevel, Texture2D newBearSkin)
        {
            spiderSpeed = 2;
            totalEnemies = newVectors.Length;
            texture = newTexture;
            for (int i = 0; i < totalEnemies; i++)
            {
                enemyVectors.Add(newVectors[i]);
            }
            bearSkin = newBearSkin;
            spiderDistanceFromStart = 0;
        }
        public string Update(string objectMovement, Vector2 bearVector, int bearSpeed, bool move) //objective 9
        {
            string collisionType = "none";
            for (int i = 0; i < totalEnemies; i++)
            {
                Vector2 currentVector = enemyVectors[i];
                if (move == true && objectMovement == "right")
                {
                    currentVector.X = currentVector.X - bearSpeed;
                }
                if (move == true && objectMovement == "left")
                {
                    currentVector.X = currentVector.X + bearSpeed;
                }
                if (spiderDirection == "right")
                {
                    currentVector.X = currentVector.X + spiderSpeed;
                    spiderDistanceFromStart = spiderDistanceFromStart + spiderSpeed;
                    if (spiderDistanceFromStart >= 125)
                    {
                        spiderDirection = "left";
                        spiderDistanceFromStart = 0;
                        spiderSpeed++;
                    }
                }
                else if (spiderDirection == "left")
                {
                    currentVector.X = currentVector.X - spiderSpeed;
                    spiderDistanceFromStart = spiderDistanceFromStart - spiderSpeed;
                    if (spiderDistanceFromStart <= -125)
                    {
                        spiderDirection = "right";
                        spiderDistanceFromStart = 0;
                        spiderSpeed--;
                    }
                }
                collisionType = Game1.Collision(bearVector, bearSkin.Height, bearSkin.Width, currentVector, texture.Width, texture.Height);
                if (collisionType == "bearOnTop")
                {
                    currentVector = new Vector2(-500, -500);
                }
                enemyVectors[i] = currentVector;
            }
            return collisionType;
        }

    }
    class Blobs : Enemy
    {
        public int blobSpeed;
        public int blobDistanceFromStart;
        public Blobs(Texture2D newTexture, Vector2[] newVectors, int newLevel, Texture2D newBearSkin)
        {
            blobSpeed = 1;
            blobDirection = "right";
            totalEnemies = newVectors.Length;
            texture = newTexture;
            for (int i = 0; i < totalEnemies; i++)
            {
                enemyVectors.Add(newVectors[i]);
            }
            bearSkin = newBearSkin;
            blobDistanceFromStart = 0;
        }

        public string Update(string objectMovement, Vector2 bearVector, int bearSpeed, bool move) //objective 9
        {
            string collisionType = "none";
            for (int i = 0; i < totalEnemies; i++)
            {
                Vector2 currentVector = enemyVectors[i];
                if (move == true && objectMovement == "right")
                {
                    currentVector.X = currentVector.X - bearSpeed;
                }
                if (move == true && objectMovement == "left")
                {
                    currentVector.X = currentVector.X + bearSpeed;
                }
                collisionType = Game1.Collision(bearVector, bearSkin.Height, bearSkin.Width, currentVector, texture.Width, texture.Height);

                if (blobDirection == "right")
                {
                    currentVector.X = currentVector.X + blobSpeed;
                    blobDistanceFromStart = blobDistanceFromStart + blobSpeed;
                    if (blobDistanceFromStart >= 100)
                    {
                        blobDirection = "left";
                        blobDistanceFromStart = 0;
                    }
                }
                else if (blobDirection == "left")
                {
                    currentVector.X = currentVector.X - blobSpeed;
                    blobDistanceFromStart = blobDistanceFromStart - blobSpeed;
                    if (blobDistanceFromStart <= -100)
                    {
                        blobDirection = "right";
                        blobDistanceFromStart = 0;
                    }
                }
                if (collisionType == "bearOnTop")
                {
                    currentVector = new Vector2(-500, -500);
                }
                enemyVectors[i] = currentVector;
            }
            return collisionType;
        }
    }
    class Wasp : Enemy
    {
        public Vector2 destination = new Vector2(400,150);
        bool destinationReached = false;
        public string waspDirection = "left";
        public List<Texture2D> waspSkins = new List<Texture2D>();
        public Vector2 waspVector;
        public int waspSpeed;
        public int waspSkinID;

        public Wasp(List<Texture2D> newWaspSkins, Texture2D newBearSkin)
        {
            for (int i = 0; i < newWaspSkins.Count; i++)
            {
                waspSkins.Add(newWaspSkins[i]);
            }
            waspSkinID = 1; // 0 is right, 1 is left
            waspVector = new Vector2(500, 100);
            texture = waspSkins[waspSkinID];
            waspSpeed = 3;
            waspDirection = "right";
            bearSkin = newBearSkin;
        }
        public new void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(waspSkins[waspSkinID], waspVector, Color.White);
        }
        public string Update(Vector2 bearVector, bool hurt, int health, bool move) //objectives 9 and 11.3
        {
            if (health <= 3)
            {
                waspSpeed = 5;
            }
            else
            {
                waspSpeed = 3;
            }
            if (move)
            {
                if (destinationReached)
                {
                    Random random = new Random();
                    destination = new Vector2(random.Next(50, 750), random.Next(50, 320));
                }
                else
                {
                    if (!(waspVector.X >= destination.X - 5 && waspVector.X <= destination.X + 5))
                    {
                        if (waspVector.X < destination.X)
                        {
                            waspVector.X = waspVector.X + waspSpeed;
                        }
                        else if (waspVector.X > destination.X)
                        {
                            waspVector.X = waspVector.X - waspSpeed;
                        }
                    }
                    if (!(waspVector.Y >= destination.Y - 5 && waspVector.Y <= destination.Y + 5))
                    {
                        if (waspVector.Y < destination.Y)
                        {
                            waspVector.Y = waspVector.Y + waspSpeed;
                        }
                        else if (waspVector.Y > destination.Y)
                        {
                            waspVector.Y = waspVector.Y - waspSpeed;
                        }
                    }
                }
                if (waspVector.X >= destination.X - 5 && waspVector.X <= destination.X + 5 && waspVector.Y >= destination.Y - 5 && waspVector.Y <= destination.Y + 5)
                {
                    destinationReached = true;
                }
                else
                {
                    destinationReached = false;
                }
            }
            string collisionType = "none";
            collisionType = Game1.Collision(bearVector, bearSkin.Height, bearSkin.Width, waspVector, texture.Width, texture.Height);
            if (bearVector.X > waspVector.X)
            {
                if (hurt)
                {
                    waspSkinID = 2;
                }
                else
                {
                    waspSkinID = 0;
                }
            }
            else
            {
                if (hurt)
                {
                    waspSkinID = 3;
                }
                else
                {
                    waspSkinID = 1;
                }
            }
            return collisionType;
        }
    }
}
