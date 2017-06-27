using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynaBlast
{
    public class Bonus
    {
        internal int[,] BonusMap = new int[Main.gameMap.Width, Main.gameMap.Height];
        public Bonus()
        {

        }

        public void CreateBonusMap()
        {
            for (int i = 0; i < Main.gameMap.Width; i++)
                for (int j = 0; j < Main.gameMap.Height; j++)
                {
                    if (Main.gameMap.Blocks[i, j].Type == 2)
                        BonusMap[i, j] = Main.mainRandom.Next(-50, 24); 
                }
        }
    }
}
