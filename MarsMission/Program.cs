using MarsMission;
using MarsMission.Entities;

Console.WriteLine("Please enter the right top coordinations of the pleatau, firstly x-axis, secondly y-axis, leaving a space between them, then enter.");
//Null, format check etc.
double[] pleatauCoordinates = Console.ReadLine().Split(' ').Select(x => Convert.ToDouble(x)).ToArray();
var p = new Plateau(pleatauCoordinates[0], pleatauCoordinates[1]);
Console.WriteLine("Plateau created!");

Console.WriteLine("Please enter the coordinations of the first rover, firstly x-axis, secondly y-axis, thirdly compass cardinal point -> N,S,W,E, leaving a space between them, then enter.");
//Null, format check etc.
string[] roverCoordinates = Console.ReadLine().Split(' ').ToArray();
do
{
    p.AddRover(Convert.ToDouble(roverCoordinates[0]), Convert.ToDouble(roverCoordinates[1]), Enum.Parse<CardinalPoints>(roverCoordinates[2]));
    Console.WriteLine("Rover placed!");

    Console.WriteLine("Please move the rover, L is to rotate counter clockwise, R is for clockwise, M is move.");
    string commands = Console.ReadLine();
    foreach (char command in commands)
    {
        switch (command)
        {
            case 'L':
                p.CurrentRover?.Rotate(false);
                break;
            case 'R':
                p.CurrentRover?.Rotate(true);
                break;
            case 'M':
                p.CurrentRover?.Move();
                break;
            default: throw new ArgumentException("Not recognized command");
        }
    }
    Console.WriteLine("Commands are executed succesfully, current rovers coordinates and direction:");
    Console.WriteLine($"{(int)p.CurrentRover.X} {(int)p.CurrentRover.Y} {p.CurrentRover.CardinalPoints}");
    Console.WriteLine("If you wish to stop sending rovers, just write q or Q and enter. Otherwise please enter the next rover's coordinates");
    roverCoordinates = Console.ReadLine().Split(' ').ToArray();
}
while (!(roverCoordinates[0] == "q" || roverCoordinates[0] == "Q"));




