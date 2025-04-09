using AspNetCoreCodingExamples.Domain.ParkingLot.Entities;

namespace AspNetCoreCodingExamples.Domain.ParkingLot.Interfaces
{
    public interface IParkingLotService
    {
        int GetTotalSpots();

        int GetNumberOfMotorcycleSpots();
        int GetNumberOfCompactSpots();
        int GetNumberOfLargeSpots();

        int GetRemainingSpots();

        bool IsFull();
        bool IsEmpty();

        bool AreMotorcycleSpotsFull();
        bool AreCompactSpotsFull();
        bool AreLargeSpotsFull();

        int GetSpotsTakenByMotorcycles();
        int GetSpotsTakenByCars();
        int GetSpotsTakenByVans();

        bool ParkVehicle(Vehicle vehicle);
        void LeaveVehicle(Vehicle vehicle);
    }
}
