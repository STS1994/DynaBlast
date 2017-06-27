using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynaBlast
{
    class KeyboardInfo
    {
        static List<Keys> pressedKeys = new List<Keys>();
        static int iteration;
        public static Keys[] GetPressedKeys()
        {
            for (iteration = 0; iteration < pressedKeys.Count; )
                if (Main.keyboradState.IsKeyUp(pressedKeys[iteration]))
                    pressedKeys.RemoveAt(iteration);
                else
                    iteration++;
            if (!pressedKeys.Exists(key => key == Keys.Up) && Main.keyboradState.IsKeyDown(Keys.Up))
                pressedKeys.Add(Keys.Up);
            if (!pressedKeys.Exists(key => key == Keys.Down) && Main.keyboradState.IsKeyDown(Keys.Down))
                pressedKeys.Add(Keys.Down);
            if (!pressedKeys.Exists(key => key == Keys.Left) && Main.keyboradState.IsKeyDown(Keys.Left))
                pressedKeys.Add(Keys.Left);
            if (!pressedKeys.Exists(key => key == Keys.Right) && Main.keyboradState.IsKeyDown(Keys.Right))
                pressedKeys.Add(Keys.Right);
            return pressedKeys.ToArray();
        }
    }
}
