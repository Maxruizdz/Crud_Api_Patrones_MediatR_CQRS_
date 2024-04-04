using AutoMapper;
using FormulaOne.DataServices.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Request;
using FormulaOne.Entities.Dtos.Response;
using Into_CQRS_MediatR.Feature.Command.CreateCommand;
using Into_CQRS_MediatR.Feature.Queries;
using Into_CQRS_MediatR.Feature.Queries.GetAllDriversQuery;
using Into_CQRS_MediatR.Feature.Queries.GetByIdQuey;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Into_CQRS_MediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : BaseController
    {

        private readonly IMediator _mediator;
        public DriversController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator) : base(unitOfWork, mapper)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{driverId:Guid}")]
        public async Task<IActionResult> GetDriver(Guid driverId) 
        {
            var query = new GetDriverByIdQuery(driverId);
            var result = await _mediator.Send(query);

            if(result is null)
                return NotFound();


            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody]CreateDriverRequest driverRequest) 
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var command = new CreateDriverCommand(driverRequest);
           
            var driver= await _mediator.Send(command);

            return CreatedAtAction(nameof(GetDriver), new { driverId = driver.DriveId }, driver);
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
            var query = new GetAllDriversQuery();
         var result =  await _mediator.Send(query);

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
