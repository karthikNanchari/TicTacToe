using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class Common : ICommon
    {
        private readonly IGameConsole _gameConsole;
        public readonly List<int[]> successRow = new List<int[]>();


        public Common(IGameConsole gameConsole)
        {
            _gameConsole = gameConsole;
            SetSuccessRows();
        }
        public void PrintGameBoard()
        {
            _gameConsole.WriteLine("     |     |      ");
            _gameConsole.WriteLine($"  { Game.static_array_of_characters_for_game_current[1]}  |  { Game.static_array_of_characters_for_game_current[2]}  |  {Game.static_array_of_characters_for_game_current[3]}");
            _gameConsole.WriteLine("_____|_____|_____ ");
            _gameConsole.WriteLine("     |     |      ");
            _gameConsole.WriteLine($"  { Game.static_array_of_characters_for_game_current[4]}  |  { Game.static_array_of_characters_for_game_current[5]}  |  {Game.static_array_of_characters_for_game_current[6]}");
            _gameConsole.WriteLine("_____|_____|_____ ");
            _gameConsole.WriteLine("     |     |      ");
            _gameConsole.WriteLine($"  { Game.static_array_of_characters_for_game_current[7]}  |  { Game.static_array_of_characters_for_game_current[8]}  |  {Game.static_array_of_characters_for_game_current[9]}");
            _gameConsole.WriteLine("     |     |      ");
        }


        /// <summary>
        /// SetSuccessRows is used to set successRow, successRow is used to check if game is ended in IsGameFinished()
        /// </summary>
        public void SetSuccessRows()
        {
            successRow.Add(new[] { 1, 2, 3 });
            successRow.Add(new[] { 4, 5, 6 });
            successRow.Add(new[] { 7, 8, 9 });
            successRow.Add(new[] { 1, 4, 7 });
            successRow.Add(new[] { 2, 5, 8 });
            successRow.Add(new[] { 3, 6, 9 });
            successRow.Add(new[] { 1, 5, 9 });
            successRow.Add(new[] { 3, 5, 7 });
        }

        /// <summary>
        /// Returns success row conditions is list format, which is later used to loop and find if user won
        /// </summary>
        /// <returns></returns>
        public List<int[]> GetSuccessRows()
        {
            return successRow;
        }
    }
}
