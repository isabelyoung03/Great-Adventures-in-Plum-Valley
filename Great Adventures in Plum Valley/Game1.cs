using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.IO;

namespace Great_Adventures_in_Plum_Valley
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public int currentLevel = 0;
        
        private Texture2D titleScreenBackground;
        private Texture2D startButton;
        private Texture2D startButtonHover;
        private Texture2D fileSelectionBackground;
        private Texture2D fileSelectA;
        private Texture2D fileSelectB;
        private Texture2D fileSelectC;
        private Texture2D levelSummary;
        private Texture2D levelSummaryHover;
        private Texture2D gameOverScreen;
        private Texture2D scene1;
        private Texture2D scene2;
        private Texture2D scene3;
        private Texture2D scene4;
        private Texture2D castleBackground;
        private Texture2D happyEndingScene;
        private Texture2D thankYouScene;
        private Texture2D clouds;
        private Texture2D hills;
        private Texture2D ground;
        private Texture2D darkForest;
        private Texture2D darkTrees;
        private Texture2D darkGround;
        private Texture2D bearRight1;
        private Texture2D bearRight2;
        private Texture2D bearLeft1;
        private Texture2D bearLeft2;
        private Texture2D bearRight1MB;
        private Texture2D bearRight2MB;
        private Texture2D bearLeft1MB;
        private Texture2D bearLeft2MB;
        private Texture2D bearRightHurt;
        private Texture2D bearLeftHurt;
        private Texture2D blob;
        private Texture2D spider;
        private Texture2D plum;
        private Texture2D flag;
        private Texture2D castle;
        private Texture2D bagOfPlums;
        private Texture2D waspRight;
        private Texture2D waspLeft;
        private Texture2D waspRightHurt;
        private Texture2D waspLeftHurt;
        private Texture2D tree;
        private Texture2D magicBoots;
        private Texture2D platform;
        public Song introMusic;
        public Song monkeyIslandBand;
        public Song evilCastleMusic;
        public SoundEffect victoryFanfare;
        public SoundEffect plumSound;
        public SoundEffect magicBootsSound;
        public SoundEffect hurtSound;
        public SoundEffect gameOverSound;
        public Song oldSong;

        //creating the list of skins for the bear and wasp, used to animate
        public List<Texture2D> bearSkins = new List<Texture2D>();
        public List<Texture2D> waspSkins = new List<Texture2D>();

        bool jumping = false;
        int jumpSpeed = 0;
        int newJumpSpeed = -15;

        public int groundY = 335;
        public Vector2 resetBearVector = new Vector2(100, 335);
        public Vector2 bearVector = new Vector2(100, 335);
        public int resetbearX = 100;
        public int bearX = 100;
        public int backgroundX = 0;
        public const int bearSpeed = 4;
        
        public bool displayTitleScreen = true;
        public bool fileSelection = false;
        public bool story = false;
        public bool levelComplete = false;
        public bool gameOver = false;
        public bool theEnd = false;
        public int timeTaken = 0;
        public int victoryFanfarePlayed;
        public bool gameOverSoundPlayed;

        int fileNumber = 0;
        const string fileName = "SaveFileData.txt";
        public List<string> fileData = new List<string>();
        public bool magicBootsStatus = false;
        public bool hurt = false;
        public bool waspHurt = false;
        string movement = "";
        string objectMovement = "";
        public KeyboardState newKeyState;
        public MouseState oldMouseState;
        public float timer;
        public int songTimeLeft;
        public int countdown = 300;

        public int sceneNumber = 1;
        public int maxHealth = 5;
        public int health = 5;
        public int healthWait = 0;
        public int healthCooldown = 2;
        public int hurtWait = 0;
        public int hurtDuration = 1;
        public const int maxWaspHealth = 8;
        public int waspHealth = 8;
        public int enemyHealthWait = 0;
        public int enemyHealthCooldown = 2;
        public int waspHurtWait = 0;
        public int waspHurtDuration = 1;
        public int magicBootsWait = 0;
        public int magicBootsDuration = 15;
        public int gameOverWait = 0;
        public int gameOverDuration = 6;
        public int plumsCollected = 0;
        public int totalLevelPlums = 0;
        public int enemiesDefeated = 0;
        private SpriteFont font;
        
        Bear bear;
        
        Item flag1;
        Item flag2;
        Item castle1;
        Item bagOfPlums1;

        MagicBoots currentMagicBoots;
        MagicBoots magicBoots1;
        MagicBoots magicBoots2;

        Blobs currentBlobs;
        Blobs blobsLevel1;
        Blobs blobsLevel2;

        Spiders currentSpiders;
        Spiders spidersLevel1;
        Spiders spidersLevel2;

        Wasp wasp;

        Trees currentTrees;
        Trees treesLevel1;
        Trees treesLevel2;

        Plums currentPlums;
        Plums plumsLevel1;
        Plums plumsLevel2;

        Scrolling scrollingClouds1;
        Scrolling scrollingClouds2;

        Scrolling scrollingHills1;
        Scrolling scrollingHills2;

        Scrolling scrollingGround1;
        Scrolling scrollingGround2;

        Scrolling scrollingDarkForest1;
        Scrolling scrollingDarkForest2;

        Scrolling scrollingDarkTrees1;
        Scrolling scrollingDarkTrees2;

        Scrolling scrollingDarkGround1;
        Scrolling scrollingDarkGround2;

        Scrolling scrollingBackground1;
        Scrolling scrollingBackground2;

        Scrolling scrollingMiddleGround1;
        Scrolling scrollingMiddleGround2;

        Scrolling scrollingForeground1;
        Scrolling scrollingForeground2;
        
        Platform currentLevelPlatforms;
        Platform platformsLevel1;
        Platform platformsLevel2;
        Platform finalBossPlatforms;

        public void DisplayTitleScreen() //objective 1
        {
            PlayMusic(introMusic);
            IsMouseVisible = true;
            MouseState mouseState = Mouse.GetState();
            spriteBatch.Draw(titleScreenBackground, new Rectangle(0, 0, 800, 480), Color.White);

            if (buttonSelected == true && mouseState.X < 470 && mouseState.X > 310 && mouseState.Y < 295 && mouseState.Y > 215) //detects if mouse is hovering over start button AND presses the button
            {
                displayTitleScreen = false;
                fileSelection = true;
            }
            else if (mouseState.X < 470 && mouseState.X > 310 && mouseState.Y < 295 && mouseState.Y > 215) //detects if mouse is hovering over start button
            {
                spriteBatch.Draw(startButtonHover, new Vector2(310, 220), Color.White);
            }
            else
            {
                spriteBatch.Draw(startButton, new Vector2(310, 220), Color.White);
            }
        }
        private void LoadSaveFileData() //objective 2 - loads the data from the text file into a list
        {
            using (StreamWriter streamWriter1 = File.AppendText("SaveFileData.txt"))
            {
                streamWriter1.Close();
                try //tries to access the file
                {
                    StreamReader streamReader = new StreamReader("SaveFileData.txt");
                    string line = streamReader.ReadLine();
                    while (line != null)
                    {
                        if (Convert.ToInt32(line) <= 4)
                        {
                            fileData.Add(line);
                        }
                        else
                        {
                            fileData.Add("1");
                        }
                        line = streamReader.ReadLine();
                    }
                    streamReader.Close();
                    if (fileData.Count < 3) //if there is an issue with the file and there are less than 3 values, it fills the list with 1's
                    {
                        fileData = new List<string> { "1", "1", "1" };
                    }
                }
                catch (Exception e) //if the file doesn't exist, create the file and write 3 1's into it, and fill the list with 1's
                {
                    StreamWriter streamWriter2 = new StreamWriter("SaveFileData.txt");
                    streamWriter2.WriteLine("1");
                    streamWriter2.WriteLine("1");
                    streamWriter2.WriteLine("1");
                    fileData = new List<string> { "1", "1", "1" };
                    streamWriter2.Close();
                }
            }
        }

        private void SaveProgress() //objective 2
        {
            File.WriteAllText("SaveFileData.txt", string.Empty); //deletes all lines from the file
            if (currentLevel == 4)
            {
                currentLevel = 3;
            }
            fileData[fileNumber] = currentLevel.ToString();
            TextWriter textWriter = new StreamWriter("SaveFileData.txt");
            for (int j = 0; j < 3; j++)
            {
                textWriter.WriteLine(fileData[j]); //writes the lines from the list into the file
            }
            textWriter.Close();
        }

        public void FileSelect() //objective 1 - allows the user to choose a file using mouse input
        {
            IsMouseVisible = true;
            MouseState mouseState = Mouse.GetState();
            spriteBatch.Draw(fileSelectionBackground, new Rectangle(0, 0, 800, 480), Color.White);
            if (buttonSelected == true && mouseState.X < 532 && mouseState.X > 266 && mouseState.Y < 145 && mouseState.Y > 110)
            {
                fileSelection = false;
                fileNumber = 0;
                currentLevel = Convert.ToInt32(fileData[fileNumber]);
                if (currentLevel == 1)
                {
                    story = true;
                }
                MediaPlayer.Stop();
            }
            else if (mouseState.X < 532 && mouseState.X > 266 && mouseState.Y < 145 && mouseState.Y > 110)
            {
                spriteBatch.Draw(fileSelectA, new Rectangle(0, 0, 800, 480), Color.White);
            }
            else if (buttonSelected == true && mouseState.X < 532 && mouseState.X > 266 && mouseState.Y < 220 && mouseState.Y > 190)
            {
                fileSelection = false;
                fileNumber = 1;
                currentLevel = Convert.ToInt32(fileData[fileNumber]);
                if (currentLevel == 1)
                {
                    story = true;
                }
                MediaPlayer.Stop();
            }
            else if (mouseState.X < 532 && mouseState.X > 266 && mouseState.Y < 220 && mouseState.Y > 190)
            {
                spriteBatch.Draw(fileSelectB, new Rectangle(0, 0, 800, 480), Color.White);
            }
            else if (buttonSelected == true && mouseState.X < 532 && mouseState.X > 266 && mouseState.Y < 303 && mouseState.Y > 270)
            {
                fileSelection = false;
                fileNumber = 2;
                currentLevel = Convert.ToInt32(fileData[fileNumber]);
                if (currentLevel == 1)
                {
                    story = true;
                }
                MediaPlayer.Stop();
            }
            else if (mouseState.X < 532 && mouseState.X > 266 && mouseState.Y < 303 && mouseState.Y > 270)
            {
                spriteBatch.Draw(fileSelectC, new Rectangle(0, 0, 800, 480), Color.White);
            }
            else
            {
                spriteBatch.Draw(fileSelectionBackground, new Rectangle(0, 0, 800, 480), Color.White);
            }
        }

        public void PlayMusic(Song song) //plays the music
        {
            if (song != oldSong) //if the song has changed, stop playing the current song
            {
                MediaPlayer.Stop();
                songTimeLeft = 0;
            }
            if (songTimeLeft <= 0) //if the song has finished playing, play again
            {
                MediaPlayer.Play(song);
                songTimeLeft = (int)song.Duration.TotalSeconds;
            }
            oldSong = song;
        }
        public bool Jump(KeyboardState newKeyState) //objectives 3 and 4.1 - controls the bear moving up up it not on the bottom, or not already jumping
        {
            bool allowGravity = true;
            if (jumping)
            {
                bearVector.Y += jumpSpeed;
                jumpSpeed += 1;
                if (currentLevel != 3)
                {
                    if (currentLevelPlatforms.Update(movement, bearVector, bearSpeed, false) == "bearOnTop")
                    {
                        jumpSpeed = 0;
                        jumping = false;
                    }
                    else if (currentLevelPlatforms.Update(movement, bearVector, bearSpeed, false) == "bearOnBottom")
                    {
                        jumpSpeed = 10;
                    }
                }
            }
            else
            {
                if (newKeyState.IsKeyDown(Keys.Up) && currentLevelPlatforms.Update(movement, bearVector, bearSpeed, false) != "bearOnBottom")
                {
                    jumpSpeed = newJumpSpeed;
                    jumping = true;
                }
            }
            if (jumpSpeed < 0)
            {
                allowGravity = false;
            }
            return allowGravity;
        }
        
        public void Gravity() //always trying to move the bear down, unless it is touching the ground or a platform
        {
            if (bearVector.Y >= groundY)
            {
                bearVector.Y = groundY;
                jumping = false;
            }
            else if (currentLevelPlatforms.Update(movement, bearVector, bearSpeed, false) == "none")
            {
                bearVector.Y += 8;
                jumping = true;
            }
        }

        public void CheckMagicBoots() //objective 7.3 - checks if the magic boots are on and displays a timer if there are
        {
            if (magicBootsStatus)
            {
                if (magicBootsWait <= 3)
                {
                    spriteBatch.DrawString(font, "Jump boost: " + magicBootsWait.ToString(), new Vector2(590, 60), Color.Red);
                }
                else
                {
                    spriteBatch.DrawString(font, "Jump boost: " + magicBootsWait.ToString(), new Vector2(590, 60), Color.Black);
                }
            }
        }

        public void DisplayGameStats() //objective 7.1
        {
            if (hurt)
            {
                spriteBatch.DrawString(font, "Health: " + health.ToString(), new Vector2(25, 25), Color.Red); //makes the colour of the health bar red to show damage
            }
            else
            {
                spriteBatch.DrawString(font, "Health: " + health.ToString(), new Vector2(25, 25), Color.Black); //health is black if not hurt
            }
            if (currentLevel < 3)
            {
                spriteBatch.DrawString(font, countdown.ToString(), new Vector2(720, 15), Color.Black); //if it is the first 2 levels, show the timer
            }
            if (currentLevel == 4)
            {
                if (waspHurt)
                {
                    spriteBatch.DrawString(font, "Boss Health: " + waspHealth.ToString(), new Vector2(600, 25), Color.Red); //if wasp is hurt, make boss health red
                }
                else
                {
                    spriteBatch.DrawString(font, "Boss Health: " + waspHealth.ToString(), new Vector2(600, 25), Color.Black); //boss health is black is not hurt
                }
            }
        }
        public void ScrollBackground() //objective 4.2
        {
            if (scrollingBackground1.rectangle.X + scrollingBackground1.texture.Width <= 0)
            {
                scrollingBackground1.rectangle.X = scrollingBackground2.rectangle.X + scrollingBackground2.texture.Width;
            }
            if (scrollingBackground2.rectangle.X + scrollingBackground2.texture.Width <= 0)
            {
                scrollingBackground2.rectangle.X = scrollingBackground1.rectangle.X + scrollingBackground1.texture.Width;
            }

            if (scrollingMiddleGround1.rectangle.X + scrollingMiddleGround1.texture.Width <= 0)
            {
                scrollingMiddleGround1.rectangle.X = scrollingMiddleGround2.rectangle.X + scrollingMiddleGround2.texture.Width;
            }
            if (scrollingMiddleGround2.rectangle.X + scrollingMiddleGround2.texture.Width <= 0)
            {
                scrollingMiddleGround2.rectangle.X = scrollingMiddleGround1.rectangle.X + scrollingMiddleGround1.texture.Width;
            }

            if (scrollingForeground1.rectangle.X + scrollingForeground1.texture.Width <= 0)
            {
                scrollingForeground1.rectangle.X = scrollingForeground2.rectangle.X + scrollingForeground2.texture.Width;
            }
            if (scrollingForeground2.rectangle.X + scrollingForeground2.texture.Width <= 0)
            {
                scrollingForeground2.rectangle.X = scrollingForeground1.rectangle.X + scrollingForeground1.texture.Width;
            }
            

            if (scrollingBackground1.rectangle.X - scrollingBackground1.texture.Width >= 0)
            {
                scrollingBackground1.rectangle.X = scrollingBackground2.rectangle.X - scrollingBackground2.texture.Width;
            }
            if (scrollingBackground2.rectangle.X - scrollingBackground2.texture.Width >= 0)
            {
                scrollingBackground2.rectangle.X = scrollingBackground1.rectangle.X - scrollingBackground1.texture.Width;
            }

            if (scrollingMiddleGround1.rectangle.X - scrollingMiddleGround1.texture.Width >= 0)
            {
                scrollingMiddleGround1.rectangle.X = scrollingMiddleGround2.rectangle.X - scrollingMiddleGround2.texture.Width;
            }
            if (scrollingMiddleGround2.rectangle.X - scrollingMiddleGround2.texture.Width >= 0)
            {
                scrollingMiddleGround2.rectangle.X = scrollingMiddleGround1.rectangle.X - scrollingMiddleGround1.texture.Width;
            }

            if (scrollingForeground1.rectangle.X - scrollingForeground1.texture.Width >= 0)
            {
                scrollingForeground1.rectangle.X = scrollingForeground2.rectangle.X - scrollingForeground2.texture.Width;
            }
            if (scrollingForeground2.rectangle.X - scrollingForeground2.texture.Width >= 0)
            {
                scrollingForeground2.rectangle.X = scrollingForeground1.rectangle.X - scrollingForeground1.texture.Width;
            }
        }
        public void Move(GameTime gameTime) //updates all movement of the bear, and checks for collisions of the bear with items and enemies
        {
            KeyboardState newKeyState = Keyboard.GetState();

            if (newKeyState.IsKeyDown(Keys.Right) && !newKeyState.IsKeyDown(Keys.Left))
            {
                movement = "right";
                if (!(currentLevelPlatforms.Update(movement, bearVector, bearSpeed, false) == "bearOnLeft"))
                {
                    bearX = bearX + bearSpeed;
                    if (bearVector.X < 310 || ((currentLevel == 4) && bearVector.X < 800-bearRight1.Width))
                    {
                        bearVector.X = bearVector.X + bearSpeed;
                    }
                    else if (backgroundX < 2400 && currentLevel < 4)
                    {
                        backgroundX = backgroundX + bearSpeed;
                        scrollingBackground1.Update(movement, 1);
                        scrollingBackground2.Update(movement, 1);

                        scrollingMiddleGround1.Update(movement, 2);
                        scrollingMiddleGround2.Update(movement, 2);

                        scrollingForeground1.Update(movement, bearSpeed);
                        scrollingForeground2.Update(movement, bearSpeed);
                        objectMovement = "left";
                    }
                }
            }

            else if (newKeyState.IsKeyDown(Keys.Left) && !newKeyState.IsKeyDown(Keys.Right))
            {
                movement = "left";
                if (!(currentLevelPlatforms.Update(movement, bearVector, bearSpeed, false) == "bearOnRight") && bearX >= 0)
                {
                    bearX = bearX - bearSpeed;
                    if ((backgroundX == 0 && bearVector.X > 0) || ((currentLevel == 4) && bearVector.X > 0))
                    {
                        bearVector.X = bearVector.X - bearSpeed;
                    }
                    else
                    {
                        if (backgroundX > 0)
                        {
                            backgroundX = backgroundX - bearSpeed;
                            scrollingBackground1.Update(movement, 1);
                            scrollingBackground2.Update(movement, 1);

                            scrollingMiddleGround1.Update(movement, 2);
                            scrollingMiddleGround2.Update(movement, 2);

                            scrollingForeground1.Update(movement, bearSpeed);
                            scrollingForeground2.Update(movement, bearSpeed);
                            objectMovement = "right";
                        }
                    }
                }
            }
            else
            {
                movement = "none";
            }

            if (currentLevel < 3)
            {
                if (currentLevelPlatforms.Update(movement, bearVector, bearSpeed, false) == "none" && bearVector.Y > groundY)
                {
                    jumpSpeed = 10;
                    bearVector.Y += jumpSpeed;
                    jumpSpeed += 1;
                }
                if (objectMovement == "right" || objectMovement == "left")
                {
                    currentLevelPlatforms.Update(movement, bearVector, bearSpeed, true);
                    currentTrees.Update(movement, bearVector, bearSpeed);
                    flag1.Update(movement, bearSpeed);
                    if (currentMagicBoots.Update(movement, bearSpeed, bearVector))
                    {
                        magicBootsSound.Play();
                        magicBootsStatus = true;
                        newJumpSpeed = -18;
                        magicBootsWait = magicBootsDuration;
                    }
                    if (enemyHealthWait <= 0 && (currentBlobs.Update(movement, bearVector, bearSpeed, true) != "bearOnTop" || currentSpiders.Update(movement, bearVector, bearSpeed, true) != "bearOnTop"))
                    {
                        enemiesDefeated++;
                        enemyHealthWait = enemyHealthCooldown;
                    }
                    else if (healthWait <= 0)
                    {
                        if (currentBlobs.Update(movement, bearVector, bearSpeed, true) != "none" || currentSpiders.Update(movement, bearVector, bearSpeed, true) != "none")
                        {
                            hurtSound.Play();
                            health--;
                            healthWait = healthCooldown;
                            hurt = true;
                            hurtWait = hurtDuration;
                        }
                    }
                    else
                    {
                        currentBlobs.Update(movement, bearVector, bearSpeed, true);
                        currentSpiders.Update(movement, bearVector, bearSpeed, true);
                    }
                    if (currentPlums.Update(movement, bearVector, bearSpeed))
                    {
                        plumsCollected++;
                        plumSound.Play();
                        if (health < 5)
                        {
                            health++;
                        }
                    }
                }
                else
                {
                    if (healthWait <= 0)
                    {
                        if (currentBlobs.Update(movement, bearVector, bearSpeed, false) != "none" || currentSpiders.Update(movement, bearVector, bearSpeed, false) != "none")
                        {
                            hurtSound.Play();
                            health--;
                            healthWait = healthCooldown;
                            hurt = true;
                            hurtWait = hurtDuration;
                        }
                    }
                    else
                    {
                        currentBlobs.Update(movement, bearVector, bearSpeed, true);
                        currentSpiders.Update(movement, bearVector, bearSpeed, true);
                    }
                }
                if (magicBootsWait <= 0)
                {
                    magicBootsStatus = false;
                    newJumpSpeed = -15;
                }
                if (hurtWait <= 0)
                {
                    hurt = false;
                }
            }
            else
            {
                magicBootsStatus = false;
            }
            if (Jump(newKeyState))
            {
                Gravity();
            }
            bear.Update(bearVector, movement, gameTime, magicBootsStatus, hurt);
        }

        public static string Collision(Vector2 bearVector, int bearHeight, int bearWidth, Vector2 objectVector, int objectHeight, int objectWidth) //detects collisions between two objects and the type of collision
        {
            if (bearVector.X >= objectVector.X && bearVector.X <= objectVector.X + objectWidth && bearVector.Y + bearHeight >= objectVector.Y && bearVector.Y + bearHeight <= objectVector.Y + objectHeight)
            {
                return "bearOnTop";
            }
            else if (bearVector.X + bearWidth >= objectVector.X && bearVector.X + bearWidth <= objectVector.X + objectWidth && bearVector.Y + bearHeight >= objectVector.Y && bearVector.Y + bearHeight <= objectVector.Y + objectHeight)
            {
                return "bearOnTop";
            }
            else if (bearVector.X <= objectVector.X && bearVector.X + bearWidth >= objectVector.X + objectWidth && bearVector.Y + bearHeight >= objectVector.Y && bearVector.Y + bearHeight <= objectVector.Y + objectHeight)
            {
                return "bearOnTop";
            }
            else if (bearVector.X >= objectVector.X && bearVector.X <= objectVector.X + objectWidth && bearVector.Y >= objectVector.Y && bearVector.Y <= objectVector.Y + objectHeight)
            {
                return "bearOnRight";
            }
            else if (bearVector.X + bearWidth >= objectVector.X && bearVector.X + bearWidth <= objectVector.X + objectWidth && bearVector.Y >= objectVector.Y && bearVector.Y <= objectVector.Y + objectHeight)
            {
                return "bearOnRight";
            }
            else if (bearVector.X <= objectVector.X + objectWidth && bearVector.X + bearWidth >= objectVector.X + objectWidth && bearVector.Y <= objectVector.Y && bearVector.Y + bearHeight >= objectVector.Y + objectHeight)
            {
                return "bearOnRight";
            }
            else if (bearVector.X >= objectVector.X && bearVector.X <= objectVector.X + objectWidth && bearVector.Y <= objectVector.Y && bearVector.Y + bearHeight >= objectVector.Y + objectHeight)
            {
                return "bearOnRight";
            }
            else if (objectVector.X >= bearVector.X && objectVector.X <= bearVector.X + bearWidth && objectVector.Y >= bearVector.Y && objectVector.Y <= bearVector.Y + bearHeight)
            {
                return "bearOnLeft";
            }
            else if (objectVector.X + objectWidth >= bearVector.X && objectVector.X + objectWidth <= bearVector.X + bearWidth && objectVector.Y >= bearVector.Y && objectVector.Y <= bearVector.Y + bearHeight)
            {
                return "bearOnLeft";
            }
            else if (objectVector.X >= bearVector.X && objectVector.X <= bearVector.X + bearWidth && objectVector.Y <= bearVector.Y && objectVector.Y + objectHeight >= bearVector.Y + bearHeight)
            {
                return "bearOnLeft";
            }
            else if (objectVector.X <= bearVector.X + bearWidth && objectVector.X + objectWidth >= bearVector.X + bearWidth && objectVector.Y <= bearVector.Y && objectVector.Y + objectHeight >= bearVector.Y + bearHeight)
            {
                return "bearOnLeft";
            }
            else if (objectVector.X >= bearVector.X && objectVector.X <= bearVector.X + bearWidth && objectVector.Y + objectHeight >= bearVector.Y && objectVector.Y + objectHeight <= bearVector.Y + bearHeight)
            {
                return "bearUnderneath";
            }
            else if (objectVector.X + objectWidth >= bearVector.X && objectVector.X + objectWidth <= bearVector.X + bearWidth && objectVector.Y + objectHeight >= bearVector.Y && objectVector.Y + objectHeight <= bearVector.Y + bearHeight)
            {
                return "bearUnderneath";
            }
            else if (bearVector.X <= objectVector.X && bearVector.X + bearWidth >= objectVector.X + objectWidth && objectVector.Y + objectHeight >= bearVector.Y && objectVector.Y + objectHeight <= bearVector.Y + bearHeight)
            {
                return "bearUnderneath";
            }
            else
            {
                return "none";
            }
        }

        public void Story() //displays a story scene
        {
            IsMouseVisible = true;
            MouseState mouseState = Mouse.GetState();
            if (sceneNumber <= 4)
            {
                if (buttonSelected)
                {
                    sceneNumber++;
                }
                switch (sceneNumber)
                {
                    case 1:
                        spriteBatch.Draw(scene1, new Rectangle(0, 0, 800, 480), Color.White);
                        break;
                    case 2:
                        spriteBatch.Draw(scene2, new Rectangle(0, 0, 800, 480), Color.White);
                        break;
                    case 3:
                        spriteBatch.Draw(scene3, new Rectangle(0, 0, 800, 480), Color.White);
                        break;
                    case 4:
                        spriteBatch.Draw(scene4, new Rectangle(0, 0, 800, 480), Color.White);
                        break;
                }
            }
            else
            {
                story = false;
                countdown = 300;
            }
        }
        public void PlayLevel1 (GameTime gameTime) //controls playing level 1
        {
            PlayMusic(monkeyIslandBand);
            totalLevelPlums = 6;
            objectMovement = "";
            IsMouseVisible = false;
            currentLevelPlatforms = platformsLevel1;
            currentMagicBoots = magicBoots1;
            currentBlobs = blobsLevel1;
            currentSpiders = spidersLevel1;
            currentTrees = treesLevel1;
            currentPlums = plumsLevel1;
            scrollingBackground1 = scrollingClouds1;
            scrollingBackground2 = scrollingClouds2;
            scrollingMiddleGround1 = scrollingHills1;
            scrollingMiddleGround2 = scrollingHills2;
            scrollingForeground1 = scrollingGround1;
            scrollingForeground2 = scrollingGround2;

            Move(gameTime);

            ScrollBackground();
            scrollingClouds1.Draw(spriteBatch);
            scrollingClouds2.Draw(spriteBatch);
            scrollingHills1.Draw(spriteBatch);
            scrollingHills2.Draw(spriteBatch);
            scrollingGround1.Draw(spriteBatch);
            scrollingGround2.Draw(spriteBatch);

            platformsLevel1.Draw(spriteBatch);
            treesLevel1.Draw(spriteBatch);
            blobsLevel1.Draw(spriteBatch);
            spidersLevel1.Draw(spriteBatch);
            plumsLevel1.Draw(spriteBatch);
            flag1.Draw(spriteBatch);
            magicBoots1.Draw(spriteBatch);
            bear.Draw(spriteBatch);

            DisplayGameStats();

            CheckMagicBoots(); 

            if (bearX >= 2700)
            {
                levelComplete = true;
                timeTaken = 300 - countdown;
            }
            else if (health <= 0 || countdown <= 0)
            {
                gameOver = true;
                GameOver();
            }
        }

        public void PlayLevel2(GameTime gameTime) //controls playing level 2
        {
            PlayMusic(monkeyIslandBand);
            totalLevelPlums = 2;
            objectMovement = "";
            IsMouseVisible = false;
            currentLevelPlatforms = platformsLevel2;
            currentMagicBoots = magicBoots2;
            currentBlobs = blobsLevel2;
            currentSpiders = spidersLevel2;
            currentTrees = treesLevel2;
            currentPlums = plumsLevel2;

            scrollingBackground1 = scrollingClouds1;
            scrollingBackground2 = scrollingClouds2;
            scrollingMiddleGround1 = scrollingHills1;
            scrollingMiddleGround2 = scrollingHills2;
            scrollingForeground1 = scrollingGround1;
            scrollingForeground2 = scrollingGround2;

            Move(gameTime);

            ScrollBackground();
            scrollingClouds1.Draw(spriteBatch);
            scrollingClouds2.Draw(spriteBatch);
            scrollingHills1.Draw(spriteBatch);
            scrollingHills2.Draw(spriteBatch);
            scrollingGround1.Draw(spriteBatch);
            scrollingGround2.Draw(spriteBatch);

            platformsLevel2.Draw(spriteBatch);
            treesLevel2.Draw(spriteBatch);
            blobsLevel2.Draw(spriteBatch);
            spidersLevel2.Draw(spriteBatch);
            plumsLevel2.Draw(spriteBatch);
            flag1.Draw(spriteBatch);
            magicBoots2.Draw(spriteBatch);
            bear.Draw(spriteBatch);

            CheckMagicBoots();

            DisplayGameStats();

            if (bearX >= 2700)
            {
                levelComplete = true;
                timeTaken = 300 - countdown;
            }
            else if (health <= 0 || countdown <= 0)
            {
                gameOver = true;
                GameOver();
            }
        }

        public void DarkForest(GameTime gameTime) //objective 11.1 - displays the dark forest scene
        {
            PlayMusic(evilCastleMusic);
            IsMouseVisible = false;
            magicBootsStatus = false;
            scrollingBackground1 = scrollingDarkForest1;
            scrollingBackground2 = scrollingDarkForest2;
            scrollingMiddleGround1 = scrollingDarkTrees1;
            scrollingMiddleGround2 = scrollingDarkTrees2;
            scrollingForeground1 = scrollingDarkGround1;
            scrollingForeground2 = scrollingDarkGround2;

            Move(gameTime);
            ScrollBackground();
            castle1.Update(movement, bearSpeed);

            scrollingDarkForest1.Draw(spriteBatch);
            scrollingDarkForest2.Draw(spriteBatch);
            scrollingDarkTrees1.Draw(spriteBatch);
            scrollingDarkTrees2.Draw(spriteBatch);
            scrollingDarkGround1.Draw(spriteBatch);
            scrollingDarkGround2.Draw(spriteBatch);
            castle1.Draw(spriteBatch);
            bear.Draw(spriteBatch);

            if (bearX >= 2700)
            {
                currentLevel = 4;
                groundY = 357;
                bearVector = new Vector2(100, groundY);
            }
        }

        public void PlayFinalBossLevel(GameTime gameTime) //objective 11.2 - displays the final boss level
        {
            PlayMusic(evilCastleMusic); 
            Move(gameTime);
            spriteBatch.Draw(castleBackground, new Rectangle(0, 0, 800, 480), Color.White);
            currentLevelPlatforms = finalBossPlatforms;
            finalBossPlatforms.Draw(spriteBatch);
            bear.Draw(spriteBatch);
            wasp.Draw(spriteBatch);
            DisplayGameStats();
            if (enemyHealthWait <= 0 && wasp.Update(bearVector, waspHurt, waspHealth, false) == "bearOnTop")
            {
                plumSound.Play();
                waspHealth--;
                enemyHealthWait = enemyHealthCooldown;
                healthWait = healthCooldown;
                waspHurt = true;
                waspHurtWait = waspHurtDuration;
            }
            else if (healthWait <= 0 && wasp.Update(bearVector, waspHurt, waspHealth, false) != "none")
            {
                hurtSound.Play();
                health--;
                healthWait = healthCooldown;
                hurt = true;
                hurtWait = hurtDuration;
            }
            if (waspHurtWait <= 0)
            {
                waspHurt = false;
            }
            if (hurtWait <= 0)
            {
                hurt = false;
            }
            wasp.Update(bearVector, waspHurt, waspHealth, true);
            if (waspHealth <= 0)
            {
                SaveProgress();
                theEnd = true;
                sceneNumber = 5;
            }
            else if (health <= 0)
            {
                gameOver = true;
                GameOver();
            }
        }
        public void LevelComplete(int currentLevel, int timeTaken) //objective 8 - displays a level summary with values
        {
            if (victoryFanfarePlayed <= currentLevel)
            {
                victoryFanfare.Play();
                victoryFanfarePlayed++;
            }
            IsMouseVisible = true;
            MouseState mouseState = Mouse.GetState();
            MediaPlayer.Stop();
            if (buttonSelected == true && mouseState.X < 610 && mouseState.X > 185 && mouseState.Y < 340 && mouseState.Y > 300)
            {
                ResetStats();
                SaveProgress();
            }
            else if (mouseState.X < 610 && mouseState.X > 185 && mouseState.Y < 340 && mouseState.Y > 300)
            {
                spriteBatch.Draw(levelSummaryHover, new Rectangle(0, 0, 800, 480), Color.White);
            }
            else
            {
                spriteBatch.Draw(levelSummary, new Rectangle(0, 0, 800, 480), Color.White);
            }
            spriteBatch.DrawString(font, plumsCollected + " / " + totalLevelPlums.ToString(), new Vector2(500, 130), Color.Black);
            spriteBatch.DrawString(font, enemiesDefeated.ToString(), new Vector2(500, 190), Color.Black);
            spriteBatch.DrawString(font, timeTaken.ToString(), new Vector2(500, 250), Color.Black);
        }
        public void TheEnd(GameTime gameTime) //objective 11.5 - shows a victory scene, then restarts the game
        {
            IsMouseVisible = true;
            MouseState mouseState = Mouse.GetState();
            PlayMusic(introMusic);
            if (victoryFanfarePlayed <= currentLevel)
            {
                victoryFanfare.Play();
                victoryFanfarePlayed++;
            }
            if (sceneNumber <= 7)
            {
                if (buttonSelected)
                {
                    sceneNumber++;
                }
                switch (sceneNumber)
                {
                    case 5:
                        spriteBatch.Draw(castleBackground, new Rectangle(0, 0, 800, 480), Color.White);
                        spriteBatch.DrawString(font, "You win! Hurray!", new Vector2(100, 100), Color.Black);
                        bagOfPlums1.Draw(spriteBatch);
                        finalBossPlatforms.Draw(spriteBatch);
                        spriteBatch.Draw(bearLeft1, new Vector2(360, 357), Color.White);
                        break;
                    case 6:
                        spriteBatch.Draw(happyEndingScene, new Rectangle(0, 0, 800, 480), Color.White);
                        break;
                    case 7:
                        spriteBatch.Draw(thankYouScene, new Rectangle(0, 0, 800, 480), Color.White);
                        break;
                }
            }
            else
            {
                theEnd = false;
                RestartGame();
                displayTitleScreen = true;
            }
        }
        public void GameOver() //objective 7.2 - plays the fail sound and displays the game over screen
        {
            MediaPlayer.Stop();
            if (!gameOverSoundPlayed)
            {
                gameOverSound.Play();
                gameOverSoundPlayed = true;
                gameOverWait = gameOverDuration;
            }
            spriteBatch.Draw(gameOverScreen, new Rectangle(0, 0, 800, 480), Color.White);
        }

        public void RestartGame() //restarts the game, resetting all values and positions by calling the MyItialise function again
        {
            ResetStats();
            MyInitialise();
            currentLevel = 0;
            gameOverSoundPlayed = false;
            victoryFanfarePlayed = 0;
            sceneNumber = 1;
            groundY = 335;
        }

        public void ResetStats() //resets all values 
        {
            health = maxHealth;
            countdown = 300;
            bearVector = resetBearVector;
            bearX = resetbearX;
            backgroundX = 0;
            enemiesDefeated = 0;
            plumsCollected = 0;
            currentLevel++;
            levelComplete = false;
            magicBootsWait = 0;
            hurtWait = 0;
            hurt = false;
            health = maxHealth;
            waspHealth = maxWaspHealth;
        }
        public void MyInitialise() //initialises all objects and lists
        {
            bearSkins.Add(bearRight1);
            bearSkins.Add(bearRight2);
            bearSkins.Add(bearLeft1);
            bearSkins.Add(bearLeft2);
            bearSkins.Add(bearRight1MB);
            bearSkins.Add(bearRight2MB);
            bearSkins.Add(bearLeft1MB);
            bearSkins.Add(bearLeft2MB);
            bearSkins.Add(bearRightHurt);
            bearSkins.Add(bearLeftHurt);

            bear = new Bear(bearSkins, bearVector);

            waspSkins.Add(waspRight);
            waspSkins.Add(waspLeft);
            waspSkins.Add(waspRightHurt);
            waspSkins.Add(waspLeftHurt);

            wasp = new Wasp(waspSkins, bearRight1);

            flag1 = new singleItem(flag, new Vector2(2750, 205));
            castle1 = new singleItem(castle, new Vector2(2770, 7));
            bagOfPlums1 = new singleItem(bagOfPlums, new Vector2(325, 0));

            scrollingClouds1 = new Scrolling(clouds, new Rectangle(0, 0, 800, 500));
            scrollingClouds2 = new Scrolling(clouds, new Rectangle(800, 0, 800, 500));

            scrollingHills1 = new Scrolling(hills, new Rectangle(0, 0, 800, 500));
            scrollingHills2 = new Scrolling(hills, new Rectangle(800, 0, 800, 500));

            scrollingGround1 = new Scrolling(ground, new Rectangle(0, 0, 800, 500));
            scrollingGround2 = new Scrolling(ground, new Rectangle(800, 0, 800, 500));

            scrollingDarkForest1 = new Scrolling(darkForest, new Rectangle(0, 0, 800, 500));
            scrollingDarkForest2 = new Scrolling(darkForest, new Rectangle(800, 0, 800, 500));

            scrollingDarkTrees1 = new Scrolling(darkTrees, new Rectangle(0, 0, 800, 500));
            scrollingDarkTrees2 = new Scrolling(darkTrees, new Rectangle(800, 0, 800, 500));

            scrollingDarkGround1 = new Scrolling(darkGround, new Rectangle(0, 0, 800, 500));
            scrollingDarkGround2 = new Scrolling(darkGround, new Rectangle(800, 0, 800, 500));

            Vector2[] platformList1 = { new Vector2(140, 250), new Vector2(200, 250), new Vector2(260, 250), new Vector2(400, 350), new Vector2(1250, 150), new Vector2(1400, 250), new Vector2(1460, 250), new Vector2(1520, 250), new Vector2(2600, 200), new Vector2(2540, 200) };
            platformsLevel1 = new Platform(platform, platformList1, bearRight1);
            Vector2[] platformList2 = { new Vector2(250, 200), new Vector2(400, 200) };
            platformsLevel2 = new Platform(platform, platformList2, bearRight1);
            Vector2[] platformListFinalBoss = { new Vector2(140, 275), new Vector2(370, 275), new Vector2(600, 275) };
            finalBossPlatforms = new Platform(platform, platformListFinalBoss, bearRight1);
            currentLevelPlatforms = platformsLevel1;

            Vector2[] blobList1 = { new Vector2(200, 357), new Vector2(1700, 357), new Vector2(2300, 357) };
            blobsLevel1 = new Blobs(blob, blobList1, 0, bearRight1);
            Vector2[] blobList2 = { new Vector2(300, 357), new Vector2(1200, 357) };
            blobsLevel2 = new Blobs(blob, blobList2, 1, bearRight1);

            Vector2[] spiderList1 = { new Vector2(1200, 326), new Vector2(700, 326), new Vector2(1460, 170) };
            spidersLevel1 = new Spiders(spider, spiderList1, 0, bearRight1);
            Vector2[] spiderList2 = { new Vector2(1500, 325), new Vector2(700, 325) };
            spidersLevel2 = new Spiders(spider, spiderList2, 1, bearRight1);

            Vector2[] treeList1 = { new Vector2(600, 208), new Vector2(900, 208), new Vector2(1700, 208), new Vector2(2000, 208) };
            treesLevel1 = new Trees(tree, treeList1, 0);
            Vector2[] treeList2 = { new Vector2(2000, 208), new Vector2(1500, 208) };
            treesLevel2 = new Trees(tree, treeList2, 1);

            magicBoots1 = new MagicBoots(magicBoots, new Vector2(1600, 365), bearRight1);
            magicBoots2 = new MagicBoots(magicBoots, new Vector2(500, 365), bearRight1);

            Vector2[] plumList1 = { new Vector2(500, 200), new Vector2(400, 250), new Vector2(700, 250), new Vector2(600, 200), new Vector2(1150, 75), new Vector2(2000, 125) };
            plumsLevel1 = new Plums(plum, plumList1, 0, bearRight1);
            Vector2[] plumList2 = { new Vector2(700, 100), new Vector2(400, 50), new Vector2(900, 300) };
            plumsLevel2 = new Plums(plum, plumList2, 0, bearRight1);
        }
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        protected override void Initialize()
        {
            LoadSaveFileData();
            base.Initialize();
        }

        protected override void LoadContent() //loads in all the textures
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            titleScreenBackground = Content.Load<Texture2D>("Title Screen");
            fileSelectionBackground = Content.Load<Texture2D>("Save File Screen");
            fileSelectA = Content.Load<Texture2D>("Save File Screen A");
            fileSelectB = Content.Load<Texture2D>("Save File Screen B");
            fileSelectC = Content.Load<Texture2D>("Save File Screen C");
            gameOverScreen = Content.Load<Texture2D>("Game Over Screen");
            levelSummary = Content.Load<Texture2D>("Level Summary");
            levelSummaryHover = Content.Load<Texture2D>("Level Summary Hover");
            scene1 = Content.Load<Texture2D>("Scene1");
            scene2 = Content.Load<Texture2D>("Scene2");
            scene3 = Content.Load<Texture2D>("Scene3");
            scene4 = Content.Load<Texture2D>("Scene4");
            castleBackground = Content.Load<Texture2D>("CastleBackground");
            happyEndingScene = Content.Load<Texture2D>("HappyEndingScene");
            thankYouScene = Content.Load<Texture2D>("TheEnd");
            clouds = Content.Load<Texture2D>("Clouds1");
            hills = Content.Load<Texture2D>("Hills1");
            ground = Content.Load<Texture2D>("Ground1");
            darkForest = Content.Load<Texture2D>("DarkForest1");
            darkTrees = Content.Load<Texture2D>("DarkTrees1");
            darkGround = Content.Load<Texture2D>("DarkGround1");
            startButton = Content.Load<Texture2D>("Start button");
            startButtonHover = Content.Load<Texture2D>("Start button hover");
            bearRight1 = Content.Load<Texture2D>("CharacterRight1");
            bearRight2 = Content.Load<Texture2D>("CharacterRight2");
            bearLeft1 = Content.Load<Texture2D>("CharacterLeft1");
            bearLeft2 = Content.Load<Texture2D>("CharacterLeft2");
            bearRight1MB = Content.Load<Texture2D>("CharacterRight1MB");
            bearRight2MB = Content.Load<Texture2D>("CharacterRight2MB");
            bearLeft1MB = Content.Load<Texture2D>("CharacterLeft1MB");
            bearLeft2MB = Content.Load<Texture2D>("CharacterLeft2MB");
            bearRightHurt = Content.Load<Texture2D>("CharacterRight1Hurt");
            bearLeftHurt = Content.Load<Texture2D>("CharacterLeft1Hurt");
            platform = Content.Load<Texture2D>("Blank button pressed");
            blob = Content.Load<Texture2D>("Blob enemy");
            spider = Content.Load<Texture2D>("Spider enemy");
            waspRight = Content.Load<Texture2D>("WaspRight");
            waspLeft = Content.Load<Texture2D>("WaspLeft");
            waspRightHurt = Content.Load<Texture2D>("waspRightHurt");
            waspLeftHurt = Content.Load<Texture2D>("waspLeftHurt");
            plum = Content.Load<Texture2D>("Plum");
            tree = Content.Load<Texture2D>("Tree");
            flag = Content.Load<Texture2D>("Flag");
            castle = Content.Load<Texture2D>("SpookyCastle");
            bagOfPlums = Content.Load<Texture2D>("BagOfPlums");
            magicBoots = Content.Load<Texture2D>("MagicBoots");
            introMusic = Content.Load<Song>("Lively Meadow");
            monkeyIslandBand = Content.Load<Song>("Monkey-Island-Band");
            evilCastleMusic = Content.Load<Song>("Castle music");
            victoryFanfare = Content.Load<SoundEffect>("Lively Meadow Victory Fanfare");
            plumSound = Content.Load<SoundEffect>("Plum Sound");
            magicBootsSound = Content.Load<SoundEffect>("Magic Boots Sound");
            hurtSound = Content.Load<SoundEffect>("Hurt Sound");
            gameOverSound = Content.Load<SoundEffect>("Game Over Sound");
            font = Content.Load<SpriteFont>("Countdown");

            MyInitialise(); 
        }
        
        private bool buttonSelected;

        protected override void Update(GameTime gameTime) //main update function, controls timers and button states
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            countdown -= (int)timer;
            healthWait -= (int)timer;
            enemyHealthWait -= (int)timer;
            hurtWait -= (int)timer;
            waspHurtWait -= (int)timer;
            magicBootsWait -= (int)timer;
            songTimeLeft -= (int)timer;
            gameOverWait -= (int)timer;
            if (timer >= 1.0F)
            {
                timer = 0F;
            }
            MouseState newMouseState = Mouse.GetState();
            if (newMouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released)
            {
                buttonSelected = true;
            }
            else
            {
                buttonSelected = false;
            }
            oldMouseState = newMouseState;
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.RosyBrown);
           
            base.Draw(gameTime);
            
            spriteBatch.Begin();

            if (displayTitleScreen)
            {
                DisplayTitleScreen();
            }
            else if (fileSelection)
            {
                FileSelect();
            }
            else if (story)
            {
                Story();
            }
            else if (levelComplete)
            {
                LevelComplete(currentLevel, timeTaken);
            }
            else if (theEnd)
            {
                TheEnd(gameTime);
            }
            else if (gameOver)
            {
                if (gameOverWait > 0)
                {
                    GameOver();
                }
                else
                {
                    gameOver = false;
                    RestartGame();
                    displayTitleScreen = true;
                }
            }
            else
            {
                switch (currentLevel)
                {
                    case 1:
                        PlayLevel1(gameTime);
                        break;
                    case 2:
                        PlayLevel2(gameTime);
                        break;
                    case 3:
                        DarkForest(gameTime);
                        break;
                    case 4:
                        PlayFinalBossLevel(gameTime);
                        break;
                }
            }
            spriteBatch.End();
        }
    }
}