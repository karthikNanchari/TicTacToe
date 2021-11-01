using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    /// <summary>
    /// ICommon interface abstract methods which are common in nature
    /// </summary>
    public interface ICommon
    {
        public void PrintGameBoard();

        public void SetSuccessRows();

        public List<int[]> GetSuccessRows();
    }
}
