using MarsMission.Entities;

namespace MarsMission.Validators
{
    internal static class Invariants
    {
        public static void ThrowIfLengthOrHeightNegative(double x, double y)
        {
            if (x < 0 || y < 0) throw new ArgumentException("Coordinates of the plateau are wrong!");
        }

        internal static void ThrowIfRoversCoordinateOutsideOfThePlateau(double roverX, double roverY, double plateauX, double plateauY)
        {
            if (plateauX < roverX || plateauY < roverY) throw new ArgumentException("We lost the rover!");
        }

        internal static void ThrowIfThereIsAlreadyRover(double x, double y, IEnumerable<Rover> rovers)
        {
            if (rovers.Any(rover => rover.X == x && rover.Y == rover.Y)) throw new ArgumentException("There is already a rover in the specified coordinate");
        }
    }
}
