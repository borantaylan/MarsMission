using MarsMission.Mappers;
using MarsMission.Validators;

namespace MarsMission.Entities
{
    internal class Plateau
    {
        public Plateau(double x, double y)
        {
            Invariants.ThrowIfLengthOrHeightNegative(x, y);
            X = x;
            Y = y;
            rovers = new List<Rover>();
        }

        public double X { get; }
        public double Y { get; }

        private readonly IList<Rover> rovers;
        public IEnumerable<Rover> Rovers => rovers;

        public Rover? CurrentRover { get; private set; } //In the future maybe the user will want to choose a different rover already on the plateau to move, private set should be considered.

        public void AddRover(double x, double y, CardinalPoints cardinalPoints)
        {
            //TODO I think it makes sense to throw
            //When there is already a rover on the coordinate.
            //Doesnt say in the document. Discuss! Maybe we also should block anyone making a move to a coordinate where there is already a rover on the path. COLLUSION DETECTION.

            //Invariants.ThrowIfThereIsAlreadyRover(x, y, Rovers);
            Invariants.ThrowIfRoversCoordinateOutsideOfThePlateau(x, y, X, Y);
            var newRover = new Rover(x, y, cardinalPoints.ToDegree());
            rovers.Add(newRover);
            CurrentRover = newRover;
        }

        public void MoveCurrentRover(string commands)
        {
            if (CurrentRover == null) throw new InvalidOperationException("There is no rover to move");
            foreach (char command in commands)
            {
                switch (command)
                {
                    case 'L':
                        CurrentRover?.Rotate(false);
                        break;
                    case 'R':
                        CurrentRover?.Rotate(true);
                        break;
                    case 'M':
                        CurrentRover?.Move();
                        Invariants.ThrowIfRoversCoordinateOutsideOfThePlateau(CurrentRover.X, CurrentRover.Y, X, Y);
                        break;
                    default: throw new ArgumentException("Not recognized command"); //TODO ignore or throw? Discuss
                }
            }
        }
    }
}
