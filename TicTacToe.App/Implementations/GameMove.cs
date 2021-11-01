using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TicTacToe
{
    public class GameMove : IGameMove
    {
        private readonly ICommon _common;
        private readonly IGameConsole _gameConsole;

        public GameMove(ICommon common, IGameConsole gameConsole)
        {
            _common = common;
            _gameConsole = gameConsole;
        }

        /// <summary>
        /// This method is used for final display of result
        /// </summary>
        /// <param name="moves"></param>
        public void DisplayAllPlayerChoices(int moves)
        {
            int player;
            for (int move = 1; move < moves + 1; move++)
            {
                player = 1;
                if (move % 2 == 0) player = 2;
                _gameConsole.WriteLine("\n");
                _gameConsole.WriteLine($"Player {player}");
                Game.static_list_of_characters_for_game[move - 1].CopyTo(Game.static_array_of_characters_for_game_current, 0);
                _common.PrintGameBoard();
            }
        }

        /// <summary>
        /// DisplayPlayerMoves is used to display Board after user input & final response.
        /// </summary>
        /// <param name="moves"></param>
        /// <param name="player"></param>
        /// <param name="didplayerWinTheGame"></param>
        public void DisplayPlayerMoves(int moves, int player, bool didplayerWinTheGame)
        {
            _gameConsole.Clear();

            _common.PrintGameBoard();

            if (didplayerWinTheGame)
                _gameConsole.WriteLine($"Player {(player % 2) + 1} has won");
            else
                _gameConsole.WriteLine("Game is Draw");

            _gameConsole.WriteLine("show all moves ? Y OR N");

            var action = _gameConsole.ReadLine();

            if (action.ToLower()=="y")
            {
                DisplayAllPlayerChoices(moves);
                _gameConsole.ReadLine();
            }
            else
            {
                _gameConsole.WriteLine($"Invalid input {action}");
                Thread.Sleep(2000);
            }
        }
    }
}
