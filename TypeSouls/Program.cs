Console.OutputEncoding = Encoding.UTF8;

//Initializes logic and data
//ConsoleService.TestLayoutThing();
var test = ConsoleService.testLayout();
ConsoleService.PrintLayout(test);

GameService game = new();

game.GameLoop();
