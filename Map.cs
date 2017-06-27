using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynaBlast
{
    class Map
    {
        internal int Height;
        internal int Width;
        public Block[,] Blocks;
        public Map(int height, int width)
        {
            Width = width;
            Height = height;
            Blocks = new Block[width, height];
        }

       /* int RandomMap()
        {
            int newmap = Main.mainRandom.Next(0, 1);
            if (newmap == map)
                newmap = RandomMap();
            return newmap;
        }*/
        internal int map;
        public void GenerateMap()
        {
            map = Main.mainRandom.Next(0, 2);
            for (i = 0; i < Width; i++)
                for (j = 0; j < Height; j++)
                {
                    if ((i *j) % 2 != 0) //условие для серых блоков type= 0 - пусто, 1 - блок, 2 - кирпич
                        Blocks[i, j] = new Block() { BlockPosition = new Rectangle(i * 32, j * 32, 32, 32), DrawRectangle = new Rectangle(0, 0 + 32 * map, 32, 32), Type = 1 };
                    else if (Main.mainRandom.Next(0,3) != 0 || (i == 0 && j == 0) || (j == Height - 1 && i == Width - 1) || (j == 0 && i == Width - 1) || (j == Height - 1 && i == 0) //рисовка кирпичей
                                                             || (j == Height - 2 && i == Width - 1) || (j == Height - 1 && i == Width - 2)
                                                             || (i == 1 && j == 0) || (i == 0 && j == 1)
                                                             || (j == 0 && i == Width - 2) || (j == 1 && i == Width - 1)
                                                             || (j == Height - 2 && i == 0) || (j == Height - 1 && i == 1))
                    {
                        Blocks[i, j] = new Block() { BlockPosition = new Rectangle(i * 32, j * 32, 32, 32), DrawRectangle = new Rectangle(320, 0 + 32 * map, 32, 32), Type = 0 };
                    }
                    else
                        Blocks[i, j] = new Block() { BlockPosition = new Rectangle(i * 32, j * 32, 32, 32), DrawRectangle = new Rectangle(32, 0 + 32 * map, 32, 32), Type = 2 };
                }
            Blocks[0, 2] = new Block() { BlockPosition = new Rectangle(0 * 32, 2 * 32, 32, 32), DrawRectangle = new Rectangle(32, 0 + 32 * map, 32, 32), Type = 2 };
            Blocks[2, 0] = new Block() { BlockPosition = new Rectangle(2 * 32, 0 * 32, 32, 32), DrawRectangle = new Rectangle(32, 0 + 32 * map, 32, 32), Type = 2 };


            Blocks[Width - 3, 0] = new Block() { BlockPosition = new Rectangle((Width - 3) * 32, 0 * 32, 32, 32), DrawRectangle = new Rectangle(32, 0 + 32 * map, 32, 32), Type = 2 };
            Blocks[Width - 1, 2] = new Block() { BlockPosition = new Rectangle((Width - 1) * 32, 2 * 32, 32, 32), DrawRectangle = new Rectangle(32, 0 + 32 * map, 32, 32), Type = 2 };


            Blocks[Width - 3, Height - 1] = new Block() { BlockPosition = new Rectangle((Width - 3) * 32, (Height - 1) * 32, 32, 32), DrawRectangle = new Rectangle(32, 0 + 32 * map, 32, 32), Type = 2 };
            Blocks[Width - 1, Height - 3] = new Block() { BlockPosition = new Rectangle((Width - 1) * 32, (Height - 3) * 32, 32, 32), DrawRectangle = new Rectangle(32, 0 + 32 * map, 32, 32), Type = 2 };


            Blocks[0, Height - 3] = new Block() { BlockPosition = new Rectangle(0 * 32, (Height - 3) * 32, 32, 32), DrawRectangle = new Rectangle(32, 0 + 32 * map, 32, 32), Type = 2 };
            Blocks[2, Height - 1] = new Block() { BlockPosition = new Rectangle(2 * 32, (Height - 1) * 32, 32, 32), DrawRectangle = new Rectangle(32, 0 + 32 * map, 32, 32), Type = 2 };
          
        }

        int i;
        int j;
        public void Draw()
        {
            for (i = 0; i < Width; i++)
                for (j = 0; j < Height; j++)
                {
                    Blocks[i, j].Draw();
                }
        }
    }
}
