using System;

namespace TicTacToe
{
    public class GameConsole : IGameConsole
    {
        public void Clear()
        {
             Console.Clear();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
