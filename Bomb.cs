using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynaBlast
{
    class Bomb
    {
        internal Rectangle bombPosition;
        Rectangle drawRectangle;
        bool Frame;
        bool FrameBomb;
        int kapowFrame;
        bool KAPOW;
        System.Timers.Timer timer = new System.Timers.Timer(1000 / 5); //взрыв бомбы через
        int Power;

        public Bomb(Rectangle bombPosition, int Power)
        {
            this.bombPosition = bombPosition;
            this.Power = Power;
            drawRectangle = new Rectangle(0, 0, 32, 32);
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        int index = 0;
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Frame = !Frame;
            if (Frame)
            {
                if (FrameBomb)
                    drawRectangle.X = 0;
                else
                    drawRectangle.X = 32;
            }
            else
            {
                FrameBomb = !FrameBomb;
                if (FrameBomb)
                    drawRectangle.X = 64;
                else
                    drawRectangle.X = 96;
            }
            index++;
            if (index > 10)
            {
                System.Timers.Timer kapowTimer = new System.Timers.Timer(1000 / 15);
                kapowTimer.Elapsed += kapowTimer_Elapsed;
                kapowTimer.Start();
                timer.Stop();
                KAPOW = true;
                for (iterationPower = 1; iterationPower <= Power; iterationPower++)
                    if (bombPosition.Y / 32 + (iterationPower - 1) < Main.gameMap.Height - 1 && Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y + 32 * iterationPower) / 32].Type == 2)
                    {
                        destoryedBlocks.Add(new Vector2((int)(bombPosition.X / 32), (int)((bombPosition.Y + 32 * iterationPower) / 32)));
                        Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y + 32 * iterationPower) / 32].Type = 4;
                        Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y + 32 * iterationPower) / 32].DrawRectangle = new Rectangle(320, 0 + 32 * Main.gameMap.map, 32, 32);
                        break;
                    }
                    else if (bombPosition.Y / 32 + (iterationPower - 1) < Main.gameMap.Height - 1 && Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y + 32 * iterationPower) / 32].Type == 1)
                        break;
                    //else if (bombPosition.Y / 32 + (iterationPower - 1) < Main.gameMap.Height - 1 && Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y + 32 * iterationPower) / 32].Type >= 10 && Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y + 32 * iterationPower) / 32].Type <= 23)
                    //{
                    //    destoryedBlocks.Add(new Vector2((int)(bombPosition.X / 32), (int)((bombPosition.Y + 32 * iterationPower) / 32)));
                    //    Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y + 32 * iterationPower) / 32].isBonusDefeat = true;
                    //    Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y + 32 * iterationPower) / 32].Type = 0;
                    //    Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y + 32 * iterationPower) / 32].DrawRectangle = new Rectangle(320, 0 + 32 * Main.gameMap.map, 32, 32);
                    //    break;
                    //}

                for (iterationPower = 1; iterationPower <= Power; iterationPower++)
                    if (bombPosition.Y / 32 - (iterationPower - 1) > 0 && Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y - 32 * iterationPower) / 32].Type == 2)
                    {
                        destoryedBlocks.Add(new Vector2((int)(bombPosition.X / 32), (int)((bombPosition.Y - 32 * iterationPower) / 32)));
                        Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y - 32 * iterationPower) / 32].Type = 4;
                        Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y - 32 * iterationPower) / 32].DrawRectangle = new Rectangle(320, 0 + 32 * Main.gameMap.map, 32, 32);
                        break;
                    }
                    else if (bombPosition.Y / 32 - (iterationPower - 1) > 0 && Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y - 32 * iterationPower) / 32].Type == 1)
                        break;

                for (iterationPower = 1; iterationPower <= Power; iterationPower++)
                    if (bombPosition.X / 32 + (iterationPower - 1) < Main.gameMap.Width - 1 && Main.gameMap.Blocks[(bombPosition.X + 32 * iterationPower) / 32, bombPosition.Y / 32].Type == 2)
                    {
                        destoryedBlocks.Add(new Vector2((int)((bombPosition.X + 32 * iterationPower) / 32), (int)(bombPosition.Y / 32)));
                        Main.gameMap.Blocks[(bombPosition.X + 32 * iterationPower) / 32, bombPosition.Y / 32].Type = 4;
                        Main.gameMap.Blocks[(bombPosition.X + 32 * iterationPower) / 32, bombPosition.Y / 32].DrawRectangle = new Rectangle(320, 0 + 32 * Main.gameMap.map, 32, 32);
                        break;
                    }
                    else if (bombPosition.X / 32 + (iterationPower - 1) < Main.gameMap.Width - 1 && Main.gameMap.Blocks[(bombPosition.X + 32 * iterationPower) / 32, bombPosition.Y / 32].Type == 1)
                        break;

                for (iterationPower = 1; iterationPower <= Power; iterationPower++)
                    if (bombPosition.X / 32 - (iterationPower - 1) > 0 && Main.gameMap.Blocks[(bombPosition.X - 32 * iterationPower) / 32, bombPosition.Y / 32].Type == 2)
                    {
                        destoryedBlocks.Add(new Vector2((int)((bombPosition.X - 32 * iterationPower) / 32), (int)(bombPosition.Y / 32)));
                        Main.gameMap.Blocks[(bombPosition.X - 32 * iterationPower) / 32, bombPosition.Y / 32].Type = 4;
                        Main.gameMap.Blocks[(bombPosition.X - 32 * iterationPower) / 32, bombPosition.Y / 32].DrawRectangle = new Rectangle(320, 0 + 32 * Main.gameMap.map, 32, 32);
                        break;
                    }
                    else if (bombPosition.X / 32 - (iterationPower - 1) > 0 && Main.gameMap.Blocks[(bombPosition.X - 32 * iterationPower) / 32, bombPosition.Y / 32].Type == 1)
                        break;
            }
        }
        int iterationPower;
        internal bool destroyed;
        List<Vector2> destoryedBlocks = new List<Vector2>();
        int blockFrame;
        int bonusDefeatFrame;
        void kapowTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (bonusDefeatFrame < 11)
                bonusDefeatFrame++;
            if (blockFrame < 8)
                blockFrame++;
            if (kapowFrame < 4)
            {
                if (!played)
                    GameContent.exBomb.Play();
                played = true;
                kapowFrame++;
            }
            if (kapowFrame >= 4 && blockFrame >= 8 && bonusDefeatFrame >= 11)
            {

                for (int i = 0; i < destoryedBlocks.Count; i++)
                {
                    if (Main.mainBonus.BonusMap[(int)destoryedBlocks[i].X, (int)destoryedBlocks[i].Y] < 10)
                    {
                        Main.gameMap.Blocks[(int)destoryedBlocks[i].X, (int)destoryedBlocks[i].Y].Type = 0;
                        Main.gameMap.Blocks[(int)destoryedBlocks[i].X, (int)destoryedBlocks[i].Y].isBonusDefeat = false;
                    }
                    else
                        Main.gameMap.Blocks[(int)destoryedBlocks[i].X, (int)destoryedBlocks[i].Y].Type = (byte)Main.mainBonus.BonusMap[(int)destoryedBlocks[i].X, (int)destoryedBlocks[i].Y];
                }
                destroyed = true;
            }
        }
        bool played;

        int iterationDraw;
        public void Draw()
        {
            if (!KAPOW)
                Main.spriteBatch.Draw(GameContent.Bomb, bombPosition, drawRectangle, Color.White);
            else if (kapowFrame < 4)
            {
                Main.spriteBatch.Draw(GameContent.Fire, bombPosition, new Rectangle(0 + 32 * kapowFrame, 0, 32, 32), Color.White);

                for (iterationDraw = 1; iterationDraw < Power; iterationDraw++)
                    if (bombPosition.Y / 32 + iterationDraw - 1 < Main.gameMap.Height - 1 && Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y + 32 * iterationDraw) / 32].Type != 1 && Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y + 32 * iterationDraw) / 32].Type != 2 && Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y + 32 * iterationDraw) / 32].Type != 3 && Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y + 32 * iterationDraw) / 32].Type != 4)
                        Main.spriteBatch.Draw(GameContent.Fire, new Rectangle(bombPosition.X, bombPosition.Y + 32 * iterationDraw, 32, 32), new Rectangle(0 + 32 * kapowFrame, 32 * 5, 32, 32), Color.White);
                    else break;
                if (iterationDraw == Power && bombPosition.Y / 32 + (iterationDraw - 1) < Main.gameMap.Height - 1 && Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y + 32 * iterationDraw) / 32].Type != 1 && Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y + 32 * iterationDraw) / 32].Type != 2 && Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y + 32 * iterationDraw) / 32].Type != 3 && Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y + 32 * iterationDraw) / 32].Type != 4)
                    Main.spriteBatch.Draw(GameContent.Fire, new Rectangle(bombPosition.X, bombPosition.Y + 32 * Power, 32, 32), new Rectangle(0 + 32 * kapowFrame, 32 * 6, 32, 32), Color.White);

                for (iterationDraw = 1; iterationDraw < Power; iterationDraw++)
                    if (bombPosition.Y / 32 - (iterationDraw - 1) > 0 && Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y - 32 * iterationDraw) / 32].Type != 1 && Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y - 32 * iterationDraw) / 32].Type != 2 && Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y - 32 * iterationDraw) / 32].Type != 3 && Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y - 32 * iterationDraw) / 32].Type != 4)
                        Main.spriteBatch.Draw(GameContent.Fire, new Rectangle(bombPosition.X, bombPosition.Y - 32 * iterationDraw, 32, 32), new Rectangle(0 + 32 * kapowFrame, 32 * 5, 32, 32), Color.White);
                    else break;
                if (iterationDraw == Power && bombPosition.Y / 32 - (iterationDraw - 1) > 0 && Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y - 32 * iterationDraw) / 32].Type != 1 && Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y - 32 * iterationDraw) / 32].Type != 2 && Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y - 32 * iterationDraw) / 32].Type != 3 && Main.gameMap.Blocks[bombPosition.X / 32, (bombPosition.Y - 32 * iterationDraw) / 32].Type != 4)
                    Main.spriteBatch.Draw(GameContent.Fire, new Rectangle(bombPosition.X, bombPosition.Y - 32 * iterationDraw, 32, 32), new Rectangle(0 + 32 * kapowFrame, 32 * 4, 32, 32), Color.White);

                for (iterationDraw = 1; iterationDraw < Power; iterationDraw++)
                    if (bombPosition.X / 32 + (iterationDraw - 1) < Main.gameMap.Width - 1 && Main.gameMap.Blocks[(bombPosition.X + 32 * iterationDraw) / 32, bombPosition.Y / 32].Type != 1 && Main.gameMap.Blocks[(bombPosition.X + 32 * iterationDraw) / 32, bombPosition.Y / 32].Type != 2 && Main.gameMap.Blocks[(bombPosition.X + 32 * iterationDraw) / 32, bombPosition.Y / 32].Type != 3 && Main.gameMap.Blocks[(bombPosition.X + 32 * iterationDraw) / 32, bombPosition.Y / 32].Type != 4)
                        Main.spriteBatch.Draw(GameContent.Fire, new Rectangle(bombPosition.X + 32 * iterationDraw, bombPosition.Y, 32, 32), new Rectangle(0 + 32 * kapowFrame, 32 * 2, 32, 32), Color.White);
                    else break;
                if (iterationDraw == Power && bombPosition.X / 32 + (iterationDraw - 1) < Main.gameMap.Width - 1 && Main.gameMap.Blocks[(bombPosition.X + 32 * iterationDraw) / 32, bombPosition.Y / 32].Type != 1 && Main.gameMap.Blocks[(bombPosition.X + 32 * iterationDraw) / 32, bombPosition.Y / 32].Type != 2 && Main.gameMap.Blocks[(bombPosition.X + 32 * iterationDraw) / 32, bombPosition.Y / 32].Type != 3 && Main.gameMap.Blocks[(bombPosition.X + 32 * iterationDraw) / 32, bombPosition.Y / 32].Type != 4)
                    Main.spriteBatch.Draw(GameContent.Fire, new Rectangle(bombPosition.X + 32 * iterationDraw, bombPosition.Y, 32, 32), new Rectangle(0 + 32 * kapowFrame, 32 * 3, 32, 32), Color.White);

                for (iterationDraw = 1; iterationDraw < Power; iterationDraw++)
                    if (bombPosition.X / 32 - (iterationDraw - 1) > 0 && Main.gameMap.Blocks[(bombPosition.X - 32 * iterationDraw) / 32, bombPosition.Y / 32].Type != 1 && Main.gameMap.Blocks[(bombPosition.X - 32 * iterationDraw) / 32, bombPosition.Y / 32].Type != 2 && Main.gameMap.Blocks[(bombPosition.X - 32 * iterationDraw) / 32, bombPosition.Y / 32].Type != 3 && Main.gameMap.Blocks[(bombPosition.X - 32 * iterationDraw) / 32, bombPosition.Y / 32].Type != 4)
                        Main.spriteBatch.Draw(GameContent.Fire, new Rectangle(bombPosition.X - 32 * iterationDraw, bombPosition.Y, 32, 32), new Rectangle(0 + 32 * kapowFrame, 32 * 2, 32, 32), Color.White);
                    else break;

                if (iterationDraw == Power && bombPosition.X / 32 - (iterationDraw - 1) > 0 && Main.gameMap.Blocks[(bombPosition.X - 32 * iterationDraw) / 32, bombPosition.Y / 32].Type != 1 && Main.gameMap.Blocks[(bombPosition.X - 32 * iterationDraw) / 32, bombPosition.Y / 32].Type != 2 && Main.gameMap.Blocks[(bombPosition.X - 32 * iterationDraw) / 32, bombPosition.Y / 32].Type != 3 && Main.gameMap.Blocks[(bombPosition.X - 32 * iterationDraw) / 32, bombPosition.Y / 32].Type != 4)
                    Main.spriteBatch.Draw(GameContent.Fire, new Rectangle(bombPosition.X - 32 * iterationDraw, bombPosition.Y, 32, 32), new Rectangle(0 + 32 * kapowFrame, 32 * 1, 32, 32), Color.White);
            }

            if (KAPOW)
                for (int i = 0; i < destoryedBlocks.Count; i++)
                    if (!Main.gameMap.Blocks[(int)destoryedBlocks[i].X, (int)destoryedBlocks[i].Y].isBonusDefeat)
                        Main.gameMap.Blocks[(int)destoryedBlocks[i].X, (int)destoryedBlocks[i].Y].DrawRectangle = new Rectangle(96 + 32 * blockFrame, Main.gameMap.Blocks[(int)destoryedBlocks[i].X, (int)destoryedBlocks[i].Y].DrawRectangle.Y, 32, 32);
                    //else
                    //    Main.gameMap.Blocks[(int)destoryedBlocks[i].X, (int)destoryedBlocks[i].Y].DrawRectangle = new Rectangle(0 + 32 * bonusDefeatFrame, 0, 32, 32);
            
        }
    }
}
