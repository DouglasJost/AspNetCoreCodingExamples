using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using AspNetCoreCodingExamples.Domain.ParkingLot.DTOs;
using AspNetCoreCodingExamples.Domain.ParkingLot.Enums;
using AspNetCoreCodingExamples.Domain.ParkingLot.Interfaces;
using AspNetCoreCodingExamples.Domain.ParkingLot.Services;
using AspNetCoreCodingExamples.Domain.Services;

namespace AspNetCoreCodingExamples.Domain.ParkingLot
{
    public class ParkingLotSimulation : DomainServiceBase<ParkingLotSimulation>, IParkingLotSimulation
    {
        public ParkingLotSimulation(ILogger<ParkingLotSimulation> logger)
            : base(logger) { }

        public ParkingLotSimulationResponseDto RunSimulation()
        {
            var response = new ParkingLotSimulationResponseDto()
            {
                SimulationName = "Parking Lot",
                SimulationResults = new List<string>()
            };

            AddSimulationResult($"Starting {nameof(RunSimulation)}", LogLevel.Information, response);

            try
            {
                var parkingLotService = new ParkingLotService(5, 5, 5);
                AddSimulationResult($"Initializing Parking Lot Service with 5 motorcycles, 5 cars, and 5 van parking slots", LogLevel.Information, response);

                AddSimulationResult($"Total spots: {parkingLotService.GetTotalSpots()}", LogLevel.Information, response);
                AddSimulationResult($"Total Motorcycle spots: {parkingLotService.GetNumberOfMotorcycleSpots()}", LogLevel.Information, response);
                AddSimulationResult($"Total Compact spots: {parkingLotService.GetNumberOfCompactSpots()}", LogLevel.Information, response);
                AddSimulationResult($"Total Large spots: {parkingLotService.GetNumberOfLargeSpots()}", LogLevel.Information, response);

                AddSimulationResult($"Remaining spots: {parkingLotService.GetRemainingSpots()}", LogLevel.Information, response);
                AddSimulationResult($"Is Full: {parkingLotService.IsFull()}", LogLevel.Information, response);
                AddSimulationResult($"Is Empty: {parkingLotService.IsEmpty()}", LogLevel.Information, response);

                var motorcycle = VehicleFactory.CreateVehicle(VehicleType.Motorcycle);
                var car = VehicleFactory.CreateVehicle(VehicleType.Car);
                var van = VehicleFactory.CreateVehicle(VehicleType.Van);

                AddSimulationResult($"Parked a motorcycle.  Was successful:{parkingLotService.ParkVehicle(motorcycle)}", LogLevel.Information, response);
                AddSimulationResult($"Parked a car.  Was successful:{parkingLotService.ParkVehicle(car)}", LogLevel.Information, response);
                AddSimulationResult($"Parked a van.  Was successful:{parkingLotService.ParkVehicle(van)}", LogLevel.Information, response);

                AddSimulationResult($"Remaining spots after parking: {parkingLotService.GetRemainingSpots()}", LogLevel.Information, response);
                AddSimulationResult($"Is Full: {parkingLotService.IsFull()}", LogLevel.Information, response);
                AddSimulationResult($"Is Empty: {parkingLotService.IsEmpty()}", LogLevel.Information, response);

                AddSimulationResult($"Are motorcycle spots fill: {parkingLotService.AreMotorcycleSpotsFull()}", LogLevel.Information, response);
                AddSimulationResult($"Are car spots fill: {parkingLotService.AreCompactSpotsFull()}", LogLevel.Information, response);
                AddSimulationResult($"Are var spots fill: {parkingLotService.AreLargeSpotsFull()}", LogLevel.Information, response);

                AddSimulationResult($"Get spots taken by motorcycles: {parkingLotService.GetSpotsTakenByMotorcycles()}", LogLevel.Information, response);
                AddSimulationResult($"Get spots taken by cars: {parkingLotService.GetSpotsTakenByCars()}", LogLevel.Information, response);
                AddSimulationResult($"Get spots taken by vans: {parkingLotService.GetSpotsTakenByVans()}", LogLevel.Information, response);

                AddSimulationResult($"Ending simulation", LogLevel.Information, response);
            }
            catch (Exception ex)
            {
                AddSimulationResult($"An exception was thrown.  Exception.Message: {ex.Message}", LogLevel.Critical, response);
                throw;
            }

            return response;
        }

        private void AddSimulationResult(string message, LogLevel logLevel, ParkingLotSimulationResponseDto response)
        {
            if (response?.SimulationResults != null)
            {
                response.SimulationResults.Add(message);
                Logger.Log(logLevel, message);
            }
        }
    }
}
