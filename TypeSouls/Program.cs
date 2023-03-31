using TypeSouls.Combat;

Console.OutputEncoding = Encoding.UTF8;

//Initializes logic and data
GameService game = new();

Encounter encounter = new();
encounter.PlayWordGame();

//Starts the game
game.GameLoop();
