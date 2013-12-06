using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout
{
    class Ball
    {
        public Vector2 _position;
        Texture2D _texture;
        public Vector2 _velocity;
        public Rectangle _boundingBox
        {
            get
            {
                return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
            }
        }

        public Ball(Vector2 _position, Texture2D _texture,Vector2 _beginningVel)
        {
            this._position = _position;
            this._texture = _texture;
            _velocity = _beginningVel;
        }

        public void Update()
        {
            _position += _velocity;

            if (_position.X < 0)
            {
                _velocity.X *= -1;
            }
            if (_position.X + _texture.Width > 640)
            {
                _velocity.X *= -1;
            }
            if (_position.Y < 0)
            {
                _velocity.Y *= -1;
            }
            if (_position.Y  > 480)
            {
                _velocity.Y *= -1;
            }
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(_texture, _position, Color.Green);
        }

    }
}
