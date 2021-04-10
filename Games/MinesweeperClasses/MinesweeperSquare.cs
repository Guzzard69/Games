﻿using Games.MinesweeperClasses.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Games.MinesweeperClasses
{
    public class MinesweeperSquare
    {
        public int xPos { get; set; }

        public int yPos { get; set; }

        public MinesweeperSquareStatus Status { get; set; } = MinesweeperSquareStatus.Empty;

        public bool IsBomb { get; set; } = false;

        public MinesweeperSquare(int xPosition, int yPosition)
        {
            xPos = xPosition;
            yPos = yPosition;
        }
    }
}
