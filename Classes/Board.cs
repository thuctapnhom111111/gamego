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

      
