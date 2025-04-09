using AspNetCoreCodingExamples.Domain.ParkingLot.Entities;
using AspNetCoreCodingExamples.Domain.ParkingLot.Enums;
using AspNetCoreCodingExamples.Domain.ParkingLot.Interfaces;

namespace AspNetCoreCodingExamples.Domain.ParkingLot.Services
{
    public class ParkingSpotService : IParkingSpotService
    {
        public SpotType Type { get; private set; }
        public bool IsOccupied { get; private set; }

        public ParkingSpotService(SpotType type)
        {
            Type = type;
            IsOccupied = false;
        }

        public void Park()
        {
            IsOccupied = true;
        }

        public void Leave()
        {
            IsOccupied = false;
        }

        public bool CanFitVehicle(Vehicle vehicle)
        {
            return !IsOccupied && (vehicle.GetSpotType() <= Type);
        }
    }
}
