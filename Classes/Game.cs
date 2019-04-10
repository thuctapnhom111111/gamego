using System;
using System.Collections.Generic;
using System.Text;

namespace Reversi.Classes
{
    public delegate void GameEventHandler();

    public class Game
    {
        #region Events

        public event GameEventHandler Started;
        public event FieldColorEventHandler MoveFinished;
        public event GameEventHandler MoveStarted;
        public event GameEventHandler Finished;

        #endregion

        #region Fields

        private Board mBoard;
        private Player mPlayer1;
        private Player mPlayer2;

        private Player mCurrentPlayer;
        private bool mIsFinished = false;
        private bool mIsStopped = false;
        private bool mIsPaused = false;

        #endregion

        #region Constructors

        public Game(Board board)
        {
            this.mBoard = board;
        }

        #endregion

}
