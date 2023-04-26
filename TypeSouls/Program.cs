Console.OutputEncoding = Encoding.UTF8;

//Initializes logic and data
//ConsoleService.TestLayoutThing();
//var test = ConsoleService.testLayout();
//ConsoleService.PrintLayout(test);

GameService game = new();

foreach (var n in game.NpcList)
{
    Console.WriteLine(n.Name);
    Console.WriteLine();
    foreach (var d in n.Dialogue)
    {
        Console.WriteLine(d);
    }
}

Console.ReadLine();

game.GameLoop();
