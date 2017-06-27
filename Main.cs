using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace DynaBlast
{

    class Main : Microsoft.Xna.Framework.Game
    {
        public static GraphicsDeviceManager graphics;
        public static SpriteBatch spriteBatch;
        public static KeyboardState keyboradState;
        public static Random mainRandom = new Random();
        public static Bonus mainBonus;
        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 608;
            gameMap = new Map(graphics.PreferredBackBufferHeight / 32, graphics.PreferredBackBufferWidth / 32);
            mainBonus = new Bonus();
        }


        protected override void Initialize()
        {

            base.Initialize();
        }


        protected override void LoadContent()
        {

            spriteBatch = new SpriteBatch(GraphicsDevice);
            GameContent.InitializeContent(Content);
            gameMap.GenerateMap();
            mainBonus.CreateBonusMap();
        }

        protected override void UnloadContent()
        {

        }

        internal static Map gameMap;
        Player player = new Player(new Rectangle(0, 0, 32, 32), 0);
        Monster monster = new Monster(new Rectangle(0, 0, 32, 32), 0);

        protected override void Update(GameTime gameTime)
        {
            keyboradState = Keyboard.GetState();
            if (keyboradState.IsKeyDown(Keys.Escape))
                this.Exit();
            player.Update();
            monster.Update();
            player.UpdateWalk();
            monster.UpdateWalk();
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
           
            gameMap.Draw();
            player.Draw();
            monster.Draw();
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
