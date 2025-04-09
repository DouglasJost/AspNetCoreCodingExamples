using FluentAssertions;
using AspNetCoreCodingExamples.Domain.ParkingLot;
using AspNetCoreCodingExamples.Tests.Mocks;

namespace AspNetCoreCodingExamples.Tests.ParkingLot
{
    public class ParkingLotSimulationTests
    {
        [Fact]
        public void RunSimulation_ShouldProduceExpectedResults()
        {
            // Arrange
            var logger = new FakeLogger<ParkingLotSimulation>();
            var simulation = new ParkingLotSimulation(logger);

            // Act
            var result = simulation.RunSimulation();

            // Assert
            result.Should().NotBeNull();
            result.SimulationName.Should().Be("Parking Lot");
            result.SimulationResults.Should().NotBeEmpty();
            result.SimulationResults.Count.Should().BeGreaterThan(5);

            logger.Logs.Should().NotBeEmpty();
            logger.Logs.Should().Contain(l => l.Contains("Starting RunSimulation"));
            logger.Logs.Should().Contain(l => l.Contains("Ending simulation"));
        }
    }
}