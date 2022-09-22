namespace MarsMission.Mappers
{
    public static class DomainExtensions
    {
        public static double ToDegree(this CardinalPoints cardinalPoints)
        {
            switch (cardinalPoints)
            {
                case CardinalPoints.N:
                    return 90;
                case CardinalPoints.E:
                    return 0;
                case CardinalPoints.S:
                    return 270;
                case CardinalPoints.W:
                    return 180;
                default:
                    throw new ArgumentException("Couldnt convert from cardinal points to degree");
            }
        }

        public static CardinalPoints ToCardinalPoint(this double cardinalPoints)
        {
            switch (cardinalPoints)
            {
                case 90:
                    return CardinalPoints.N;
                case 0:
                    return CardinalPoints.E;
                case 270:
                    return CardinalPoints.S;
                case 180:
                    return CardinalPoints.W;
                default:
                    throw new ArgumentException("Couldnt convert from degree to Cardinal points");
            }
        }
    }
}
