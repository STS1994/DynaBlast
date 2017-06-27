using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynaBlast
{
    class Block
    {
        byte type;
        public byte Type { get { return type; } set { type = value; } }
        Rectangle blockPosition;
        public Rectangle BlockPosition { get { return blockPosition; } set { blockPosition = value; } }
        Rectangle drawRectangle;
        public Rectangle DrawRectangle { get { return drawRectangle; } set { drawRectangle = value; } }
        Rectangle bonusRectangle;
        public bool isBonusDefeat;
        int BlockFrame;
        int indexFrame;
        public void Draw()
        {
            indexFrame++;
            Main.spriteBatch.Draw(GameContent.Map, blockPosition, drawRectangle, Color.White);
            if (type > 4)
                switch (type)
                {
                    case 10:
                        {
                            if (indexFrame > 40)
                            {
                                BlockFrame++;
                                indexFrame = 0;
                            }
                            bonusRectangle.Height = 32;
                            bonusRectangle.Width = 32;
                            bonusRectangle.X = 0 + 32 * BlockFrame;
                            bonusRectangle.Y = 0 + 32 * 0;
                            Main.spriteBatch.Draw(GameContent.Bonus, blockPosition, bonusRectangle, Color.White);
                            if (BlockFrame > 1)
                                BlockFrame = 0;
                            break;
                        }
                    case 11:
                        {
                            if (indexFrame > 40)
                            {
                                BlockFrame++;
                                indexFrame = 0;
                            }
                            bonusRectangle.Height = 32;
                            bonusRectangle.Width = 32;
                            bonusRectangle.X = 0 + 32 * BlockFrame;
                            bonusRectangle.Y = 0 + 32 * 1;
                            Main.spriteBatch.Draw(GameContent.Bonus, blockPosition, bonusRectangle, Color.White);
                            if (BlockFrame > 1)
                                BlockFrame = 0;
                            break;
                        }
                    case 12:
                        {
                            if (indexFrame > 40)
                            {
                                BlockFrame++;
                                indexFrame = 0;
                            }
                            bonusRectangle.Height = 32;
                            bonusRectangle.Width = 32;
                            bonusRectangle.X = 0 + 32 * BlockFrame;
                            bonusRectangle.Y = 0 + 32 * 2;
                            Main.spriteBatch.Draw(GameContent.Bonus, blockPosition, bonusRectangle, Color.White);
                            if (BlockFrame > 1)
                                BlockFrame = 0;
                            break;
                        }
                    case 13:
                        {
                            if (indexFrame > 40)
                            {
                                BlockFrame++;
                                indexFrame = 0;
                            }
                            bonusRectangle.Height = 32;
                            bonusRectangle.Width = 32;
                            bonusRectangle.X = 0 + 32 * BlockFrame;
                            bonusRectangle.Y = 0 + 32 * 3;
                            Main.spriteBatch.Draw(GameContent.Bonus, blockPosition, bonusRectangle, Color.White);
                            if (BlockFrame > 1)
                                BlockFrame = 0;
                            break;
                        }
                    case 14:
                        {
                            if (indexFrame > 40)
                            {
                                BlockFrame++;
                                indexFrame = 0;
                            }
                            bonusRectangle.Height = 32;
                            bonusRectangle.Width = 32;
                            bonusRectangle.X = 0 + 32 * BlockFrame;
                            bonusRectangle.Y = 0 + 32 * 4;
                            Main.spriteBatch.Draw(GameContent.Bonus, blockPosition, bonusRectangle, Color.White);
                            if (BlockFrame > 1)
                                BlockFrame = 0;
                            break;
                        }
                    case 15:
                        {
                            if (indexFrame > 40)
                            {
                                BlockFrame++;
                                indexFrame = 0;
                            }
                            bonusRectangle.Height = 32;
                            bonusRectangle.Width = 32;
                            bonusRectangle.X = 0 + 32 * BlockFrame;
                            bonusRectangle.Y = 0 + 32 * 5;
                            Main.spriteBatch.Draw(GameContent.Bonus, blockPosition, bonusRectangle, Color.White);
                            if (BlockFrame > 1)
                                BlockFrame = 0;
                            break;
                        }
                    /* case 16:
                         {
                             if (indexFrame > 2)
                             {
                                 BlockFrame++;
                                 indexFrame = 0;
                             }
                             bonusRectangle.Height = 32;
                             bonusRectangle.Width = 32;
                             bonusRectangle.X = 0 + 32 * BlockFrame;
                             bonusRectangle.Y = 0 + 32 * 6;
                             Main.spriteBatch.Draw(GameContent.Bonus, blockPosition, bonusRectangle, Color.White);
                             if (BlockFrame > 19)
                                 BlockFrame = 0;
                             break;
                         }
                     case 17:
                         {
                             if (indexFrame > 5)
                             {
                                 BlockFrame++;
                                 indexFrame = 0;
                             }
                             bonusRectangle.Height = 32;
                             bonusRectangle.Width = 32;
                             bonusRectangle.X = 0 + 32 * BlockFrame;
                             bonusRectangle.Y = 0 + 32 * 7;
                             Main.spriteBatch.Draw(GameContent.Bonus, blockPosition, bonusRectangle, Color.White);
                             if (BlockFrame > 3)
                                 BlockFrame = 0;
                             break;
                         }
                     case 18:
                         {
                             if (indexFrame > 40)
                             {
                                 BlockFrame++;
                                 indexFrame = 0;
                             }
                             bonusRectangle.Height = 32;
                             bonusRectangle.Width = 32;
                             bonusRectangle.X = 0 + 32 * BlockFrame;
                             bonusRectangle.Y = 0 + 32 * 8;
                             Main.spriteBatch.Draw(GameContent.Bonus, blockPosition, bonusRectangle, Color.White);
                             if (BlockFrame > 1)
                                 BlockFrame = 0;
                             break;
                         }
                     case 19:
                         {
                             if (indexFrame > 40)
                             {
                                 BlockFrame++;
                                 indexFrame = 0;
                             }
                             bonusRectangle.Height = 32;
                             bonusRectangle.Width = 32;
                             bonusRectangle.X = 0 + 32 * BlockFrame;
                             bonusRectangle.Y = 0 + 32 * 9;
                             Main.spriteBatch.Draw(GameContent.Bonus, blockPosition, bonusRectangle, Color.White);
                             if (BlockFrame > 1)
                                 BlockFrame = 0;
                             break;
                         }
                     case 20:
                         {
                             if (indexFrame > 40)
                             {
                                 BlockFrame++;
                                 indexFrame = 0;
                             }
                             bonusRectangle.Height = 32;
                             bonusRectangle.Width = 32;
                             bonusRectangle.X = 0 + 32 * BlockFrame;
                             bonusRectangle.Y = 0 + 32 * 10;
                             Main.spriteBatch.Draw(GameContent.Bonus, blockPosition, bonusRectangle, Color.White);
                             if (BlockFrame > 1)
                                 BlockFrame = 0;
                             break;
                         }
                     case 21:
                         {
                             if (indexFrame > 5)
                             {
                                 BlockFrame++;
                                 indexFrame = 0;
                             }
                             bonusRectangle.Height = 32;
                             bonusRectangle.Width = 32;
                             bonusRectangle.X = 0 + 32 * BlockFrame;
                             bonusRectangle.Y = 0 + 32 * 11;
                             Main.spriteBatch.Draw(GameContent.Bonus, blockPosition, bonusRectangle, Color.White);
                             if (BlockFrame > 3)
                                 BlockFrame = 0;
                             break;
                         }
                     case 22:
                         {
                             if (indexFrame > 2)
                             {
                                 BlockFrame++;
                                 indexFrame = 0;
                             }
                             bonusRectangle.Height = 32;
                             bonusRectangle.Width = 32;
                             bonusRectangle.X = 0 + 32 * BlockFrame;
                             bonusRectangle.Y = 0 + 32 * 12;
                             Main.spriteBatch.Draw(GameContent.Bonus, blockPosition, bonusRectangle, Color.White);
                             if (BlockFrame > 23)
                                 BlockFrame = 0;
                             break;
                         }
                 }

             if(isBonusDefeat)
                 Main.spriteBatch.Draw(GameContent.Explose, blockPosition, drawRectangle, Color.White);*/

                }

        }
    }
}
