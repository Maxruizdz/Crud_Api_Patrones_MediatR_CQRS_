using AutoMapper;
using FormulaOne.DataServices.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Request;
using FormulaOne.Entities.Dtos.Response;
using Into_CQRS_MediatR.Feature.Achievements.Command.CreateCommand;
using Into_CQRS_MediatR.Feature.Achievements.Query.GetByIdCommand;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace Into_CQRS_MediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementsController : BaseController
    {
        private readonly IMediator _mediator;
        public AchievementsController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator) : base(unitOfWork, mapper)
        {

            _mediator= mediator;
        }

        [HttpGet]
        [Route("{driverId:guid}")]

        public async Task<IActionResult> GetDriverAchievement(Guid driverId)
        {
            var result = _mediator.Send(new GetAchievementByIdQuery(driverId));

            if (result == null)
                return NotFound();


            return Ok(result);
        }
        [HttpPost]
   
        public async Task<IActionResult> AddAchievement([FromBody] CreateDriverAchievementRequest driverAchievementRequest) 
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var command = new CreateAchievementCommand(driverAchievementRequest);
            var result = await _mediator.Send(command);



            return CreatedAtAction(nameof(GetDriverAchievement), new { driverid = result.DriverId }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAchievements([FromBody] UpdateDriverAchievementRequest driverAchievementRequest) 
        {

            if (!ModelState.IsValid)
                return BadRequest();


            var result = _mapper.Map<Achievement>(driverAchievementRequest);

            await _unitOfWork._AchievementRepository.Update(result);
            await _unitOfWork.CompleteAsync();

            return NoContent();
        }
    }
}
