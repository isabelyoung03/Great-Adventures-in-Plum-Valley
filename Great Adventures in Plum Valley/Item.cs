using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Great_Adventures_in_Plum_Valley
{
    class Item 
    {
        public Texture2D texture;
        public Texture2D bearSkin;
        public Vector2 vector;
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, vector, Color.White);
        }
        
        public void Update(string direction, int bearSpeed)
        {
            if (direction == "right")
            {
                vector.X = vector.X - bearSpeed;
            }
            if (direction == "left")
            {
                vector.X = vector.X + bearSpeed;
            }
        }

        public bool Collision(Vector2 objectVector, Texture2D objectTexture, Vector2 bearVector)
        {
            if (Game1.Collision(bearVector, objectTexture.Width, objectTexture.Height, objectVector, bearSkin.Width, bearSkin.Height) != "none")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class singleItem : Item
    {
        public singleItem(Texture2D newTexture, Vector2 newVector)
        {
            texture = newTexture;
            vector = newVector;
        }
    }

    class MagicBoots : Item
    {
        public MagicBoots(Texture2D newTexture, Vector2 newVector, Texture2D newBearSkin)
        {
            texture = newTexture;
            vector = newVector;
            bearSkin = newBearSkin;
        }

        public bool Update(string direction, int bearSpeed, Vector2 bearVector) //moves the items based on the bears direction of movement, and checks if the bear collides with an item
        {
            if (direction == "right")
            {
                vector.X = vector.X - bearSpeed;
            }
            if (direction == "left")
            {
                vector.X = vector.X + bearSpeed;
            }
            if (Collision(vector, texture, bearVector))
            {
                vector = new Vector2(-100, -100);
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Plums : Item
    {
        public List<Vector2> plumVectors = new List<Vector2>();
        public List<Vector2> resetPlumVectors = new List<Vector2>();
        public int totalPlums;

        public Plums(Texture2D newTexture, Vector2[] newVectors, int newLevel, Texture2D newBearSkin)
        {
            totalPlums = newVectors.Length;
            texture = newTexture;
            for (int i = 0; i < totalPlums; i++)
            {
                plumVectors.Add(newVectors[i]);
            }
            resetPlumVectors = plumVectors;
            bearSkin = newBearSkin;
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < totalPlums; i++)
            {
                spriteBatch.Draw(texture, plumVectors[i], Color.White);
            }
        }

        public bool Update(string platformMovement, Vector2 bearVector, int bearSpeed) //moves the plums based on the bears direction of movement, and checks if the bear collides with a plum
        {
            bool collides = false;
            for (int i = 0; i < totalPlums; i++)
            {
                Vector2 currentVector = plumVectors[i];
                if (platformMovement == "right")
                {
                    currentVector.X = currentVector.X - bearSpeed;
                }
                if (platformMovement == "left")
                {
                    currentVector.X = currentVector.X + bearSpeed;
                }
                if (Collision(currentVector, texture, bearVector))
                {
                    currentVector = new Vector2(-100, -100);
                    collides = true;
                }
                plumVectors[i] = currentVector;
            }
            return collides;
        }
    }

    class Trees : Item
    {
        public List<Vector2> treeVectors = new List<Vector2>();
        public int totalTrees;
        
        public Trees(Texture2D newTexture, Vector2[] newVectors, int newLevel)
        {
            totalTrees = newVectors.Length;
            texture = newTexture;
            for (int i = 0; i < totalTrees; i++)
            {
                treeVectors.Add(newVectors[i]);
            }
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < totalTrees; i++)
            {
                spriteBatch.Draw(texture, treeVectors[i], Color.White);
            }
        }

        public void Update(string platformMovement, Vector2 bearVector, int bearSpeed) //moves the trees based on the bears direction of movement
        {
            for (int i = 0; i < totalTrees; i++)
            {
                Vector2 currentVector = treeVectors[i];
                if (platformMovement == "right")
                {
                    currentVector.X = currentVector.X - bearSpeed;
                }
                if (platformMovement == "left")
                {
                    currentVector.X = currentVector.X + bearSpeed;
                }
                treeVectors[i] = currentVector;
            }
        }
    }
}
