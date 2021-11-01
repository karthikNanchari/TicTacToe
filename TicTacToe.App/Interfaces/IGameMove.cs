namespace TicTacToe
{

    /// <summary>
    /// IGame interface which has abstract methods related to displaying response after user input
    /// </summary>
    public interface IGameMove
    {
        public void DisplayAllPlayerChoices(int number);

        public void DisplayPlayerMoves(int moves,int player, bool didPlayerWinTheGame);
    }
}
