using System.Collections.Generic;

namespace AspNetCoreCodingExamples.Domain.ParkingLot.DTOs
{
    public class ParkingLotSimulationResponseDto
    {
        public string SimulationName { get; set; } = string.Empty;
        public List<string>? SimulationResults { get; set; }
    }
}
