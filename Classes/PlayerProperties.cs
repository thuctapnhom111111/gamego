using System;
using System.Collections.Generic;
using System.Text;

namespace Reversi.Classes
{
    [Serializable]
    public class PlayerProperties
    {
        public readonly PlayerType Type;
        public readonly string Name;
        public readonly int MaxDepth;

        public PlayerProperties(PlayerType type, string name, int maxDepth)
        {
            this.Type = type;
            this.Name = name;
            this.MaxDepth = maxDepth;
        }

        public PlayerProperties(PlayerType type, string name)
            : this(type, name, 2)
        { }
        #region Properties

        public override PlayerType Type
        {
            get
            {
                return PlayerType.Computer;
            }
        }

        private int Depth
        {
            get
            {
                return this.mMaxDepth;
            }
        }

        #endregion

        #region Methods

        public override void StartMove()
        {
            base.StartMove();



            Thread threadDoNextMove = new Thread(this.DoNextMove);
            threadDoNextMove.Start();
        }

        private void DoNextMove()
        {
            MoveSolver solver = new MoveSolver(this, this.Depth);
            int rowIndex;
            int columnIndex;

            solver.GetNextMove(out rowIndex, out columnIndex);
            if (!this.Game.IsStopped && !this.Game.IsPaused && (rowIndex >= 0) && (columnIndex >= 0))
            {
                this.Game.Board.SetFieldColor(rowIndex, columnIndex, this.Color);
            }
        }

        #endregion
    }
}
