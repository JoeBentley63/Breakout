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

namespace Breakout
{
    
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        Texture2D _ballTexture;
        Texture2D _brickTexture;
        Texture2D _paddleTexture;
        SpriteBatch spriteBatch;
        BrickManager _brickManager;
        Ball _gameBall;
        Paddle _paddle;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 480;
            graphics.PreferredBackBufferWidth = 640;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _ballTexture = Content.Load<Texture2D>("ball");
            _brickTexture = Content.Load<Texture2D>("block");
            _paddleTexture = Content.Load<Texture2D>("Paddle");
            _gameBall = new Ball(new Vector2(200, 200), _ballTexture, new Vector2(5, 5));
            int[,] _map = new int[5,10]
            {
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1},
            {1,1,1,1,1,1,1,1,1,1}
            };
            _brickManager = new BrickManager(_map, _brickTexture, 5, 10);
            _brickManager.Init();

            _paddle = new Paddle(new Vector2(200, 400), _paddleTexture);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            for (int i = 0; i < _brickManager._bricksInGame.Count; i++)
            {
                if (_brickManager._bricksInGame[i]._shouldBeDestroyed)
                {
                    _brickManager._bricksInGame.Remove(_brickManager._bricksInGame[i]);
                }
             }
            _gameBall.Update();
            _paddle.Update();
            CollisionDetection();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public void CollisionDetection()
        {
            if(_paddle._boundingBox.Intersects(_gameBall._boundingBox))
            {
                _gameBall._velocity.Y *= -1; 
            }
            foreach (Brick item in _brickManager._bricksInGame)
            {
                if (_gameBall._boundingBox.Intersects(item._boundingBox))
                {
                    _gameBall._velocity.Y *= -1;
                    item._shouldBeDestroyed = true;
                }    
            }
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            _brickManager.Draw(spriteBatch);
            _gameBall.Draw(spriteBatch);
            _paddle.Draw(spriteBatch);
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
