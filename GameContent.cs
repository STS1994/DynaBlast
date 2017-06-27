using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynaBlast
{
    class GameContent
    {
        public static void InitializeContent(ContentManager Content)
        {
            Map = Content.Load<Texture2D>("Graphics/maps");
            Player = Content.Load<Texture2D>("Graphics/players");
            Monster = Content.Load<Texture2D>("Graphics/monsters");
            Bomb = Content.Load<Texture2D>("Graphics/bomb");
            Fire = Content.Load<Texture2D>("Graphics/fire");
            Bonus = Content.Load<Texture2D>("Graphics/bonus");
            exBomb = Content.Load<SoundEffect>("Effects/EXBOMB");
            bonusEffect = Content.Load<SoundEffect>("Effects/BONUS");
        }
        public static Texture2D Map;
        public static Texture2D Player;
        public static Texture2D Bomb;
        public static Texture2D Fire;
        public static Texture2D Bonus;
        public static Texture2D Monster;
        public static SoundEffect exBomb;
        public static SoundEffect bonusEffect;
    }
}
