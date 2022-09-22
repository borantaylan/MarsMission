using MarsMission.Mappers;

namespace MarsMission.Entities
{
    internal class Rover
    {
        public Rover(double x, double y, double rotationDegree)
        {
            X = x;
            Y = y;
            RotationDegree = rotationDegree;
        }

        public double X { get; private set; }
        public double Y { get; private set; }
        public double RotationDegree { get; private set; }//East looking rover is 0
        //Prepared for more sensitive rotation
        public CardinalPoints CardinalPoints => (RotationDegree % 360).ToCardinalPoint();

        public void Move(double unit = 1) //TODO As a start is 1 unit in the document, but should we give the chance to move 2 or 1.5? Makes sense to keep it like that?
        {
            var xDistanceToGo = Math.Cos(RotationDegree * Math.PI / 180.0 * unit);
            X += xDistanceToGo;
            var yDistanceToGo = Math.Sin(RotationDegree * Math.PI / 180.0 * unit);
            Y += yDistanceToGo;
        }
        public void Rotate(bool isClockWise, double degree = 90) //TODO As a start 90 degree as in the document, but should we give the change to move more sensitive? Makes sense to keep it like that?
        {
            //Circular enum values
            //Guarantee given degree less than 360, as well as overall rotation.
            RotationDegree = isClockWise ? (RotationDegree - degree % 360) % 360 : (RotationDegree + degree % 360) % 360;
            //Wow... Negative mod doesnt work in C#.
            if (RotationDegree < 0)
            {
                RotationDegree += 360;
            }
        }
    }

}
