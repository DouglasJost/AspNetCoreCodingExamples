using AspNetCoreCodingExamples.Domain.ParkingLot.DTOs;

namespace AspNetCoreCodingExamples.Domain.ParkingLot.Interfaces
{
    public interface IParkingLotSimulation
    {
        ParkingLotSimulationResponseDto RunSimulation();
    }
}
