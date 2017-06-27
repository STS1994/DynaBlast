using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynaBlast
{
    abstract class GameObject
    {
        protected enum GameObjectState { Left, Right, Top, Bottom };
        protected GameObjectState gameObjectState;
        protected Vector2 blockPosition;
        public Vector2 BlockPosition { get { return blockPosition; } }
        protected Vector2 goalPosition;
        public GameObject()
        {
            System.Timers.Timer walkTimer = new System.Timers.Timer(1000 / 60);
            walkTimer.Elapsed += walkTimer_Elapsed;
            walkTimer.Start();
        }

        public void UpdateWalk()
        {
            blockPosition.X = position.X / 32;
            blockPosition.Y = position.Y / 32;
            if (!walkDone)
            {
                if (gameObjectState == GameObjectState.Left)
                {
                    if (!blockPosition.Equals(goalPosition))
                        position.X -= 2;
                    else if(position.X % 32 == 0)
                        walkDone = true;
                    else
                        position.X -= 2;
                }
                else if (gameObjectState == GameObjectState.Right)
                {
                    if (!blockPosition.Equals(goalPosition))
                        position.X += 2;
                    else if (position.X % 32 == 0)
                        walkDone = true;
                    else
                        position.X += 2;
                }
                else if (gameObjectState == GameObjectState.Bottom)
                {
                    if (!blockPosition.Equals(goalPosition))
                        position.Y += 2;
                    else if (position.Y % 32 == 0)
                        walkDone = true;
                    else
                        position.Y += 2;
                }
                else if (gameObjectState == GameObjectState.Top)
                {
                    if (!blockPosition.Equals(goalPosition))
                        position.Y -= 2;
                    else if (position.Y % 32 == 0)
                        walkDone = true;
                    else
                        position.Y -= 2;
                }
                move = true;
            }
          
        }

        void walkTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
           
        }
        protected byte speed = 1;
        public byte Speed { get { return speed; } }
        protected Rectangle position;
        public Rectangle Position { get { return position; } }
        protected Rectangle drawRectangle;
        protected bool move;
        public bool Move { get { return move; } }
        protected byte Frame;
        protected bool walkDone = true;

        protected void MoveNow()
        {
            if (goalPosition.X >= 0 && goalPosition.Y >= 0 && goalPosition.X < Main.gameMap.Width && goalPosition.Y < Main.gameMap.Height)
                if (Main.gameMap.Blocks[(int)goalPosition.X, (int)goalPosition.Y].Type != 1 && Main.gameMap.Blocks[(int)goalPosition.X, (int)goalPosition.Y].Type != 2)
                {
                    walkDone = false;
                    return;
                }
            walkDone = true;
            move = false;
            Frame = 0;
        }
        public abstract void Update();
        public abstract void Draw();
       
    }
}
