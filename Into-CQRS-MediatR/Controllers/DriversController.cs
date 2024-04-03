using AutoMapper;
using FormulaOne.DataServices.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Request;
using FormulaOne.Entities.Dtos.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Into_CQRS_MediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : BaseController
    {
        public DriversController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [Route("{driverId:Guid}")]
        public async Task<IActionResult> GetDriver(Guid driverId) 
        {

            var driver = await _unitOfWork._DriverRepository.GetById(driverId);

            if(driver is null)
                return NotFound();


            var result = _mapper.Map<GetDriverResponse>(driver);
            

            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody]CreateDriverRequest driverRequest) 
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var driver = _mapper.Map<Driver>(driverRequest);

            await _unitOfWork._DriverRepository.Add(driver);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetDriver), new { driverId = driver.Id }, driver);
        }
        [HttpPut]

        public async Task<IActionResult> UpdateDriver(UpdateDriverRequest updateDriver) {
        
            if(!ModelState.IsValid)
                return BadRequest();

            var result = _mapper.Map<Driver>(updateDriver);

            await _unitOfWork._DriverRepository.Update(result);
            await _unitOfWork.CompleteAsync();
            return Ok();
        
        
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            var drivers = await _unitOfWork._DriverRepository.All();

            var result = _mapper.Map<IEnumerable<GetDriverResponse>> (drivers);


            return Ok(result);
        
        
        }

        [HttpDelete]
        [Route("{driverId:guid}")]

        public async Task<IActionResult> DeleteDriver(Guid driverId)
        {
            var driver = await _unitOfWork._DriverRepository.GetById(driverId);

            if (driver == null)
                return NotFound();

            await _unitOfWork._DriverRepository.Delete(driverId);
            await  _unitOfWork.CompleteAsync();

            return NoContent();
        
        }
    }

}
