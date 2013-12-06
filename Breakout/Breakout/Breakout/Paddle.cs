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
    class Paddle
    {
        Vector2 _position;
        Texture2D _texture;
        public Rectangle _boundingBox
        {
            get
            {
                return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
            }
        }


        public Paddle(Vector2 _position, Texture2D _texture)
        {
            this._position = _position;
            this._texture = _texture;
         
        }

        public void Update()
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Left) == true)
            {
                _position.X -= 5;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Right) == true)
            {
                _position.X += 5;
            }
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(_texture, _position, Color.Blue);
        }

    }
}
