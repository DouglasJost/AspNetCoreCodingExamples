using AspNetCoreCodingExamples.Domain.ParkingLot.Entities;
using AspNetCoreCodingExamples.Domain.ParkingLot.Enums;

namespace AspNetCoreCodingExamples.Domain.ParkingLot.Interfaces
{
    public interface IParkingSpotService
    {
        SpotType Type { get; }

        bool IsOccupied { get; }

        void Park();
        void Leave();
        bool CanFitVehicle(Vehicle vehicle);
    }
}
