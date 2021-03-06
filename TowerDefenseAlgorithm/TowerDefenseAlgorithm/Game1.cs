﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TowerDefenseAlgorithm
{
  
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Board board;
        GameManager gm;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            board = new Board();
            gm = new GameManager();

            PathFinder.CreateMap(); //Skapar matrix med väggar
            PathFinder.CalculateClosestPath();  //Skapar path här
            //PathFinder.FindPath(new Point(3, 3), new Point(6, 6));
            //gm.AddMainTower(new Vector2(150, 150));
            //gm.AddMainTower(new Vector2(200, 200));
            graphics.PreferredBackBufferWidth = 750;
            graphics.PreferredBackBufferHeight = 750;
            graphics.ApplyChanges();

        }

        protected override void Initialize()
        {
            IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Globals.LoadTextures(Content);
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
   
            gm.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            board.Draw(spriteBatch);

            gm.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
