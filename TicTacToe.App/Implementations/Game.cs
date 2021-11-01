using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace TicTacToe
{
    public class Game : IGame
    {
        private readonly ICommon _common;
        private readonly IGameMove _checkMoves;
        private readonly IGameConsole _gameConsole;
        private bool _didPlayerWin;
        private bool _didGameDraw;

        public static char[] static_array_of_characters_for_game_current = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public static int player = 1;
        public static List<char[]> static_list_of_characters_for_game = Enumerable.Range(0, 9).
            Select(x => new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }).ToList();
        public static int moves = 0;

        public Game(ICommon common, IGameMove checkMoves, IGameConsole gameConsole)
        {
            _common = common;
            _checkMoves = checkMoves;
            _gameConsole = gameConsole;
        }

        #region Public methods
        
        /// <summary>
        /// Game starts from InitiateGame(),
        /// </summary>
        public void InitiateGame()
        {
            do
            {
                _gameConsole.Clear();

                _gameConsole.WriteLine("Player1:X and Player2:O");

                _gameConsole.WriteLine("\n");

                _gameConsole.WriteLine(ChoosePlayerChoice(player));

                _gameConsole.WriteLine("\n");

                _common.PrintGameBoard();

                GetGameStatus();

            } while (!DidGameFinish());

            _checkMoves.DisplayPlayerMoves(moves, player, DidPlayerWinTheGame());
        }

        /// <summary>
        /// returns which user turn is now
        /// </summary>
        /// <param name="currentPlayer"></param>
        /// <returns></returns>
        public  string ChoosePlayerChoice(int currentPlayer)    
        {
            var result= (currentPlayer % 2 == 0)? "Player 2's Turn": "Player 1's Turn";
            return result;
        }

        #endregion

        #region private methods

        private bool DidPlayerWinTheGame()
        {
            return _didPlayerWin;
        }

        private bool DidGameFinish()
        {
            return _didGameDraw || _didPlayerWin;
        }

        private void GetGameStatus()
        {
            var playerChoice= ReadPlayerChoice();

            if (IsValid(playerChoice))
            {
                if (IsPositionAvailableForPlayerChoice(playerChoice))
                {
                    SettingPlayerChoiceInBoard(playerChoice);

                    player++;
                }
                else
                {
                    InvalidChoiceNotifyPlayer(playerChoice);
                }
                IsGameFinished();

                RecordingPlayerMoves(moves);

            }
            else
            {
               _gameConsole.WriteLine($"Invalid input {playerChoice}");
                Thread.Sleep(2000);
            }
            

        }

        private static void RecordingPlayerMoves(int move)
        {
            SetPlayerMoves(move);
            static_array_of_characters_for_game_current.CopyTo(static_list_of_characters_for_game[moves - 1], 0);
        }

        private static void SetPlayerMoves(int move)
        {
            moves = move + 1;
        }

        private  void InvalidChoiceNotifyPlayer(int playerChoice)
        {
           _gameConsole.WriteLine($"{playerChoice} {static_array_of_characters_for_game_current[playerChoice]}");
           _gameConsole.WriteLine("\n");
           _gameConsole.WriteLine("Please wait 2secs");
            Thread.Sleep(2000);
        }

        private static void SettingPlayerChoiceInBoard(int playerChoice)
        {
            if (player % 2 == 0) static_array_of_characters_for_game_current[playerChoice] = 'O';
            else
                static_array_of_characters_for_game_current[playerChoice] = 'X';
        }

        private static bool IsPositionAvailableForPlayerChoice(int playerChoice)
        {
            return static_array_of_characters_for_game_current[playerChoice] != 'X' &&
                                static_array_of_characters_for_game_current[playerChoice] != 'O';
        }

        private static bool IsValid(int playerChoice)
        {       
            return 
                (playerChoice <= GamePosition.GameMaxPosition ||
                playerChoice > GamePosition.GameMinPosition);
        }

        private int ReadPlayerChoice()
        {
            var input =_gameConsole.ReadLine();
            int.TryParse(input, out int playerInput);
            return playerInput;
        }

        private void IsGameFinished()
        {
            DidPlayerWin();

            IsGameDraw();
        }

        public void DidPlayerWin()
        {
            // player won
            for (var i = 0; i < _common.GetSuccessRows().Count; i++)
            {
                if (Game.static_array_of_characters_for_game_current[_common.GetSuccessRows()[i][0]] == Game.static_array_of_characters_for_game_current[_common.GetSuccessRows()[i][1]] &&
                    Game.static_array_of_characters_for_game_current[_common.GetSuccessRows()[i][1]] == Game.static_array_of_characters_for_game_current[_common.GetSuccessRows()[i][2]])
                {
                    _didPlayerWin = true;
                    return;
                }
            }
        }

        public void IsGameDraw()
        {
            // Game is Draw
            if (Game.static_array_of_characters_for_game_current[1] != '1' &&
                Game.static_array_of_characters_for_game_current[2] != '2' &&
                Game.static_array_of_characters_for_game_current[3] != '3' &&
                Game.static_array_of_characters_for_game_current[4] != '4' &&
                Game.static_array_of_characters_for_game_current[5] != '5' &&
                Game.static_array_of_characters_for_game_current[6] != '6' &&
                Game.static_array_of_characters_for_game_current[7] != '7' &&
                Game.static_array_of_characters_for_game_current[8] != '8' &&
                Game.static_array_of_characters_for_game_current[9] != '9')
            {
                _didGameDraw = true;
                return;
            }
        }

        #endregion
    }
}
