using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynaBlast
{
    class Player : GameObject
    {
        List<Bomb> bombList = new List<Bomb>();
        int indexPlayer;
        int iter;
        public Player(Rectangle Position, int indexPlayer)
        {
            base.position = Position;
            this.indexPlayer = indexPlayer;
            System.Timers.Timer frameTimer = new System.Timers.Timer(1000 / 13); //скорость смены анимации
            frameTimer.Elapsed += frameTimer_Elapsed;
            frameTimer.Start();
            gameObjectState = GameObjectState.Right;
            drawRectangle = new Rectangle(0 + 32 * Frame, 0 + 32 * indexPlayer, 32, 32);
        }

        void frameTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (move)
                Frame++;
            
            if (Frame == 4)
                Frame = 0;
            if (gameObjectState == GameObjectState.Right)
                drawRectangle = new Rectangle(0 + 32 * Frame, 0 + 32 * indexPlayer, 32, 32);
            else if (gameObjectState == GameObjectState.Top)
                drawRectangle = new Rectangle(160 + 32 * Frame, 0 + 32 * indexPlayer, 32, 32);
            else if (gameObjectState == GameObjectState.Left)
                drawRectangle = new Rectangle(320 + 32 * Frame, 0 + 32 * indexPlayer, 32, 32);
            else if (gameObjectState == GameObjectState.Bottom)
                drawRectangle = new Rectangle(480 + 32 * Frame, 0 + 32 * indexPlayer, 32, 32);
        }
        Keys[] pressedKeys;

        public override void Update()
        {
            pressedKeys = KeyboardInfo.GetPressedKeys();

            if (pressedKeys.Length > 0)
            {
                if (pressedKeys[pressedKeys.Length - 1] == Keys.Up && walkDone)
                {
                    goalPosition.X = blockPosition.X;
                    goalPosition.Y = blockPosition.Y - 1;
                    gameObjectState = GameObjectState.Top;
                    base.MoveNow();
                }
                if (pressedKeys[pressedKeys.Length - 1] == Keys.Down && walkDone)
                {
                    goalPosition.X = blockPosition.X;
                    goalPosition.Y = blockPosition.Y + 1;
                    gameObjectState = GameObjectState.Bottom;
                    base.MoveNow();
                }
                if (pressedKeys[pressedKeys.Length - 1] == Keys.Left && walkDone)
                {
                    goalPosition.Y = blockPosition.Y;
                    goalPosition.X = blockPosition.X - 1;
                    gameObjectState = GameObjectState.Left;
                    base.MoveNow();
                }
                if (pressedKeys[pressedKeys.Length - 1] == Keys.Right && walkDone)
                {
                    goalPosition.Y = blockPosition.Y;
                    goalPosition.X = blockPosition.X + 1;
                    gameObjectState = GameObjectState.Right;
                    base.MoveNow();
                }
            }
            else if (walkDone)
            {
                Frame = 0;
                move = false;
            }


           
            if (Main.keyboradState.IsKeyDown(Keys.Space) && position.X % 32 == 0 && position.Y % 32 == 0 && !bombList.Exists(bomb => bomb.bombPosition.Equals(position)))
            {
                bombList.Add(new Bomb(position, 5));
            }

            for (iter = 0; iter < bombList.Count; iter++)
            {
                if (bombList[iter].destroyed)
                {
                    bombList.RemoveAt(iter);
                    iter--;
                }
            }

            if (Main.gameMap.Blocks[(int)blockPosition.X, (int)blockPosition.Y].Type >= 10 && Main.gameMap.Blocks[(int)blockPosition.X, (int)blockPosition.Y].Type <= 23)
            {
                Main.gameMap.Blocks[(int)blockPosition.X, (int)blockPosition.Y].Type = 0;
                Main.mainBonus.BonusMap[(int)blockPosition.X, (int)blockPosition.Y] = 0;
                GameContent.bonusEffect.Play();
            }
        }
        
       // bool spacePressed;
        public override void Draw()
        {
            foreach (Bomb bomb in bombList)
                bomb.Draw();
            Main.spriteBatch.Draw(GameContent.Player, base.position, drawRectangle, Color.White);
            
        }
    }
}
