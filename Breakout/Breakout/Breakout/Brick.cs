using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Breakout
{
    class Brick
    {
        Color _colour;
        Vector2 _position;
        Texture2D _texture;
        public bool _shouldBeDestroyed = false;
        public Rectangle _boundingBox
        {
            get
            {
                return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
            }
        }

        public Brick(Vector2 _position, Texture2D _texture,Color _colour)
        {
            this._position = _position;
            this._texture = _texture;
            this._colour = _colour;
        }

        public void Update()
        {

        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(_texture, _position, _colour);
        }

    }
}
