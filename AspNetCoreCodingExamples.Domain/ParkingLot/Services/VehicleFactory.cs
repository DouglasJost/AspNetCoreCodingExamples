using System;
using AspNetCoreCodingExamples.Domain.ParkingLot.Entities;
using AspNetCoreCodingExamples.Domain.ParkingLot.Enums;

namespace AspNetCoreCodingExamples.Domain.ParkingLot.Services
{
    public class VehicleFactory
    {
        public static Vehicle CreateVehicle(VehicleType vehicleType)
        {
            Vehicle requrestedVehicle;

            switch (vehicleType)
            {
                case VehicleType.Motorcycle:
                {
                    requrestedVehicle = new MotorCycle();
                    break;
                }
                case VehicleType.Car:
                {
                    requrestedVehicle = new Car();
                    break;
                }
                case VehicleType.Van:
                {
                    requrestedVehicle = new Van();
                    break;
                }
                default:
                {
                    throw new ArgumentException($"Invalid vehicle type.  VehicleType: {vehicleType.ToString()}");
                }
            }

            return requrestedVehicle;
        }
    }
}
