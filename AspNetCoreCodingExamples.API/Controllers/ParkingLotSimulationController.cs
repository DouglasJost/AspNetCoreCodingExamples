using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreCodingExamples.Domain.ParkingLot.Interfaces;

namespace AspNetCoreCodingExamples.API.Controllers
{
    [ApiController]
    [Route("api/ParkingLotSimulation")]
    public class ParkingLotSimulationController : ControllerBase
    {
        private readonly IParkingLotSimulation _parkingLotSimulation;

        public ParkingLotSimulationController(IParkingLotSimulation parkingLotSimulation) 
        {
            _parkingLotSimulation = parkingLotSimulation;
        }
         
        [AllowAnonymous]
        [Route("RunSimulation")]
        [HttpGet]
        public IActionResult RunSimulation()
        {
            var response = _parkingLotSimulation.RunSimulation();
            return Ok(response);
        }
    }
}
