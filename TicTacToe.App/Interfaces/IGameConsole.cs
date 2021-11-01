

namespace TicTacToe
{
    /// <summary>
    /// IConsole Interface which inturn implemented to display response in screen 
    /// </summary>
    public interface IGameConsole
    {
        void WriteLine(string message);
        string ReadLine();
        void Clear();
    }
}

