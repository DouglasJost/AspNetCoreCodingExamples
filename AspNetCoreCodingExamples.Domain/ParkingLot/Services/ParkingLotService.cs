using System.Collections.Generic;
using System.Linq;
using AspNetCoreCodingExamples.Domain.ParkingLot.Entities;
using AspNetCoreCodingExamples.Domain.ParkingLot.Enums;
using AspNetCoreCodingExamples.Domain.ParkingLot.Interfaces;

namespace AspNetCoreCodingExamples.Domain.ParkingLot.Services
{
    public class ParkingLotService : IParkingLotService
    {
        private List<IParkingSpotService>? _motorcycleSpots;
        private List<IParkingSpotService>? _compactSpots;
        private List<IParkingSpotService>? _largeSpots;

        public ParkingLotService(int motorcycleCount, int compactCount, int largeCount)
        {
            _motorcycleSpots = new List<IParkingSpotService>();
            _compactSpots = new List<IParkingSpotService>();
            _largeSpots = new List<IParkingSpotService>();

            for (int i = 0; i < motorcycleCount; i++)
            {
                _motorcycleSpots.Add(new ParkingSpotService(SpotType.Motorcycle));
            }

            for (int i = 0;i < compactCount; i++)
            {
                _compactSpots.Add(new ParkingSpotService(SpotType.Compact));
            }

            for (int i = 0; i <= largeCount; i++)
            {
                _largeSpots.Add(new ParkingSpotService(SpotType.Large));
            }
        }

        public int GetNumberOfMotorcycleSpots()
        {
            return _motorcycleSpots != null ? _motorcycleSpots.Count : 0;
        }
        public int GetNumberOfCompactSpots()
        {
            return _compactSpots != null ? _compactSpots.Count : 0;
        }
        public int GetNumberOfLargeSpots()
        {
            return _largeSpots != null ? _largeSpots.Count : 0;
        }
        public int GetTotalSpots()
        {
            return GetNumberOfMotorcycleSpots() + GetNumberOfCompactSpots() + GetNumberOfLargeSpots();
        }

        public int GetRemainingSpots()
        {
            var remainingMotorcycleSpots = _motorcycleSpots != null ? _motorcycleSpots.Count(s => !s.IsOccupied) : 0;
            var remainingCompactSpots = _compactSpots != null ? _compactSpots.Count(s => !s.IsOccupied) : 0;
            var remainingLargeSpots = _largeSpots != null ? _largeSpots.Count(s => !s.IsOccupied) : 0;

            var remainingSpots = remainingMotorcycleSpots + remainingCompactSpots + remainingLargeSpots;

            return remainingSpots;
        }

        public bool IsFull()
        {
            return (GetRemainingSpots() == 0);
        }

        public bool IsEmpty()
        {
            return (GetTotalSpots() == GetRemainingSpots());
        }

        public bool AreMotorcycleSpotsFull()
        {
            return _motorcycleSpots != null ? _motorcycleSpots.All(s => s.IsOccupied) : true;
        }
        public bool AreCompactSpotsFull()
        {
            return _compactSpots != null ? _compactSpots.All(s => s.IsOccupied) : true;
        }
        public bool AreLargeSpotsFull()
        {
            return _largeSpots != null ? _largeSpots.All(s => s.IsOccupied) : true;
        }

        public int GetSpotsTakenByMotorcycles()
        {
            return _motorcycleSpots != null ? _motorcycleSpots.Count(s => s.IsOccupied) : 0;
        }
        public int GetSpotsTakenByCars()
        {
            return _compactSpots != null ? _compactSpots.Count(s => s.IsOccupied) : 0;
        }
        public int GetSpotsTakenByVans()
        {
            return _largeSpots != null ? _largeSpots.Count(s => s.IsOccupied) : 0;
        }

        public bool ParkVehicle(Vehicle vehicle)
        {
            // ParkVehicle is an example of the SOLID Liskov Substitution Principle (LSP)
            // --------------------------------------------------------------------------
            //   Using a subclass (child / derived class) MotorCycle, Van, Car,
            //   whenever a SuperClass (parent / base class) Vehicle is expected.

            var parkedSuccessfully = false;
            var requiredSpots = vehicle.GetRequiredSpots();

            if (vehicle is MotorCycle)
            {
                parkedSuccessfully = ParkInAvailableSpots(_motorcycleSpots, requiredSpots) ||
                                     ParkInAvailableSpots(_compactSpots, requiredSpots) ||
                                     ParkInAvailableSpots(_largeSpots, requiredSpots);
            }
            else if (vehicle is Car)
            {
                parkedSuccessfully = ParkInAvailableSpots(_compactSpots, requiredSpots) ||
                                     ParkInAvailableSpots(_largeSpots, requiredSpots);
            }
            else if (vehicle is Van)
            {
                parkedSuccessfully = ParkInAvailableSpots(_largeSpots, requiredSpots);
            }

            return parkedSuccessfully;
        }

        private bool ParkInAvailableSpots(List<IParkingSpotService>? spots, int requiredSpots)
        {
            var parkedSuccessfully = false;

            if (spots != null) 
            {
                var availableSpots = 0;

                for (var i = 0; i < spots.Count; i++)
                {
                    if (!spots[i].IsOccupied)
                    {
                        availableSpots++;
                    }
                    else 
                    {
                        availableSpots = 0;
                    }

                    if (availableSpots == requiredSpots)
                    {
                        // Mark spot as occupied
                        for (var j = i; j > i - requiredSpots; j--)
                        {
                            spots[j].Park();
                        }
                        return true;
                    }
                }
            }

            return parkedSuccessfully;
        }

        public void LeaveVehicle(Vehicle vehicle)
        {
            // LeaveVehicle is an example of the SOLID Liskov Substitution Principle (LSP)
            // ---------------------------------------------------------------------------
            //   Using a subclass (child / derived class) MotorCycle, Van, Car,
            //   whenever a SuperClass (parent / base class) Vehicle is expected.

            var requiredSpots = vehicle.GetRequiredSpots();
            if (vehicle is MotorCycle) 
            {
                LeaveSpots(_motorcycleSpots, requiredSpots);
            }
            else if (vehicle is Car)
            {
                LeaveSpots(_compactSpots, requiredSpots);
            }
            else if (vehicle is Van) 
            {
                LeaveSpots(_largeSpots, requiredSpots);
            }
        }

        private void LeaveSpots(List<IParkingSpotService>? spots, int requiredSpots)
        {
            if (spots != null)
            {
                var count = 0;
                foreach (var spot in spots)
                {
                    if (spot.IsOccupied)
                    {
                        spot.Leave();
                        count++;
                    }
                    if (count == requiredSpots)
                    {
                        break;
                    }
                }
            }
        }
    }
}
