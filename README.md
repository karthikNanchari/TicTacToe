# TicTacToe
 a .Netcore modular application
 
TicTacToe Application:
A TicTacToe is a boardgame, played by 2 players at a time. A player who selects three consecutive numbers in the board wins the game.

Setup:
This is a .NetCore Console application. It inculdes injecting requried services through Dependency Injection. XUnit test is writter for the methods.

What's Special:
Main focus of this project is to develop a modular code so that it will be easy to reuse the components.
Interface like 
 1) IGameMove has methods to respond according to user input i.e. refresh Userinterface after every input.
 2) IGame has methods to accepts user input, validate it and proceed to next step.
 3) IGameConsole has methods which are common in nature like setting initial values etc.
 4) IGameConsole has methods which are used to display response after user input, which is useful to expand the project into webapplication if requried. ( For example right now this is a console output project if we want to convert this into a webapplication then we need to just create a class which converts output value into JSON and provide to the consumer.)
 

How it works : 
Player 1: selects a number then system displays the selection.
Player 2: selects a number then system displays the selection.
This process continues till one of the player selects three numbers in a row or column or diagonally.
Game can be won by a player of be a Draw.

Roles:
Player-1, Player-2, backen code displays the player choice of number.


