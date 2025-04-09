using AspNetCoreCodingExamples.Domain.ParkingLot.Enums;

namespace AspNetCoreCodingExamples.Domain.ParkingLot.Entities
{
    public class MotorCycle : Vehicle
    {
        public override int GetRequiredSpots()
        {
            return 1;
        }

        public override SpotType GetSpotType()
        {
            return SpotType.Motorcycle;
        }
    }
}
