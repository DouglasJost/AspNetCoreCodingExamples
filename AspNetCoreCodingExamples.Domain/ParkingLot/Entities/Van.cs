using AspNetCoreCodingExamples.Domain.ParkingLot.Enums;

namespace AspNetCoreCodingExamples.Domain.ParkingLot.Entities
{
    public class Van : Vehicle
    {
        public override int GetRequiredSpots()
        {
            return 3;
        }

        public override SpotType GetSpotType()
        {
            return SpotType.Large;
        }
    }
}
