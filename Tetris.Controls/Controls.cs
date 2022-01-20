﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TetrisGame.Tetris.Controls
{
    using TetrisGame.Tetris.Game;
    using TetrisGame.Tetris.Display;

    enum GameKeys
    {
        Left = 37,
        Right = 39,
        Down = 40
    }

    class Controls
    {
        private Grid grid;
        private Display display;

        public Controls(Grid grid, Display display)
        {
            this.grid = grid;
            this.display = display;

            this.display.UpdateFrame();

            new Thread(InputProcess).Start();
        }

        private void InputProcess()
        {
            while(true)
            {
                GameKeys currentKey = (GameKeys)Console.ReadKey(false).Key;
                if (currentKey == GameKeys.Down || currentKey == GameKeys.Left || currentKey == GameKeys.Right)
                {
                    this.grid.GetCurrentCube().Move(currentKey);
                    this.display.UpdateFrame();
                }
            }
        }
    }
}
