using System;
using System.Collections.Generic;
using System.Text;

namespace Reversi.Classes
{
    public delegate void FieldColorEventHandler(int rowIndex, int columnIndex, DiscColor color);

    public class Board : ICloneable
    {
        #region ReadOnly

        public const int DEFAULT_BOARD_SIZE = 8;

        #endregion

        #region Events

        public event FieldColorEventHandler MoveFinished;

        #endregion

        #region Fields

        private int mBoardSize;

        private DiscColor[,] mFieldColors;

        private int mInvertedDiscsLastMove = 0;

        #endregion

       #region Constructors

        public Board()
            : this(DEFAULT_BOARD_SIZE)
        { }

        public Board(int boardSize)
        {
            this.mBoardSize = boardSize;
            this.mFieldColors = new DiscColor[boardSize, boardSize];

            for (int rowIndex = 0; rowIndex < boardSize; rowIndex++)            
            {
                for (int columnIndex = 0; columnIndex < boardSize; columnIndex++)
                {
                    this.mFieldColors[rowIndex, columnIndex] = DiscColor.None;
                }
            }

            if (boardSize >= 2)
            {
                this.mFieldColors[boardSize / 2 - 1, boardSize / 2 - 1] = DiscColor.White;
                this.mFieldColors[boardSize / 2, boardSize / 2] = DiscColor.White;
                this.mFieldColors[boardSize / 2 - 1, boardSize / 2] = DiscColor.Black;
                this.mFieldColors[boardSize / 2, boardSize / 2 - 1] = DiscColor.Black;
            }
        }

        private Board(Board orignalBoard)
        {
            this.mBoardSize = orignalBoard.Size;
            this.mFieldColors = new DiscColor[this.Size, this.Size];

            for (int rowIndex = 0; rowIndex < this.Size; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < this.Size; columnIndex++)
                {
                    this.mFieldColors[rowIndex, columnIndex] = orignalBoard[rowIndex, columnIndex];
                }
            }
        }

        #endregion
