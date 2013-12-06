using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Breakout
{
    class BrickManager
    {
        int[,] _brickMap;
        Texture2D _brickTexture;
        int _height;
        int _width;
        public List<Brick> _bricksInGame = new List<Brick>();
        public BrickManager(int[,] _brickMap, Texture2D _brick, int _height, int _width)
        {
            this._brickMap = _brickMap;
            this._brickTexture = _brick;
            this._height = _height;
            this._width = _width;
        }

        public void Init()
        {
            for (int i = 0; i < _height; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    if (_brickMap[i,j] == 1)
                    {
                        _bricksInGame.Add(new Brick(new Vector2(j * 64, i * 32), _brickTexture,Color.Red));
                    }
                    if (_brickMap[i, j] == 2)
                    {
                        _bricksInGame.Add(new Brick(new Vector2(j * 64, i * 32), _brickTexture,Color.Orange));
                    }
                }
            }
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            foreach (Brick item in _bricksInGame)
            {
                item.Draw(_spriteBatch);
            }
        }
    }
}