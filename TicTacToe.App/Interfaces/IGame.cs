namespace TicTacToe
{
    /// <summary>
    /// IGame interface abstract methods which are more related to the Game
    /// </summary>
    public interface IGame
    {
        public string ChoosePlayerChoice(int currentPlayerr);

        public void DidPlayerWin();

        public void IsGameDraw();
    }
}
