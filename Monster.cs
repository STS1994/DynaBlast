using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynaBlast
{
    class Monster : GameObject
    {
        int indexMonster;
        public Monster(Rectangle Position, int indexMonster)
        {
            base.position = Position;
            this.indexMonster = indexMonster;
            System.Timers.Timer frameTimer = new System.Timers.Timer(1000 / 13); //скорость смены анимации
            frameTimer.Elapsed += frameTimer_Elapsed;
            frameTimer.Start();
            gameObjectState = GameObjectState.Right;
            drawRectangle = new Rectangle(0 + 32 * Frame, 0 + 32 * indexMonster, 32, 32);
        }

        void frameTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            /*if (move)
                Frame++;

            if (Frame == 4)
                Frame = 0;
            if (gameObjectState == GameObjectState.Right)
                drawRectangle = new Rectangle(0 + 32 * Frame, 0 + 32 * indexMonster, 32, 32);
            else if (gameObjectState == GameObjectState.Top)
                drawRectangle = new Rectangle(160 + 32 * Frame, 0 + 32 * indexMonster, 32, 32);
            else if (gameObjectState == GameObjectState.Left)
                drawRectangle = new Rectangle(320 + 32 * Frame, 0 + 32 * indexMonster, 32, 32);
            else if (gameObjectState == GameObjectState.Bottom)
                drawRectangle = new Rectangle(480 + 32 * Frame, 0 + 32 * indexMonster, 32, 32);*/
        }

        public override void Update()
        {
            int direct = Main.mainRandom.Next(1, 4);

            switch (direct)
            {
                case 1:
                    
                        goalPosition.X = blockPosition.X;
                        goalPosition.Y = blockPosition.Y - 1;
                        gameObjectState = GameObjectState.Top;
                        base.MoveNow();
                        break;
                    
                case 2:
                    
                        goalPosition.X = blockPosition.X;
                        goalPosition.Y = blockPosition.Y - 1;
                        gameObjectState = GameObjectState.Top;
                        base.MoveNow();
                        break;
                    
                case 3:
                    
                        goalPosition.X = blockPosition.X;
                        goalPosition.Y = blockPosition.Y - 1;
                        gameObjectState = GameObjectState.Top;
                        base.MoveNow();
                        break;
                    
                case 4:
                    
                        goalPosition.X = blockPosition.X;
                        goalPosition.Y = blockPosition.Y - 1;
                        gameObjectState = GameObjectState.Top;
                        base.MoveNow();
                        break;
                    
            }
            
               
           /* if (walkDone)
            {
                Frame = 0;
                move = false;
            }*/
        }

        public override void Draw()
        {
            Main.spriteBatch.Draw(GameContent.Monster, base.position, drawRectangle, Color.White);
        }
    }
}
