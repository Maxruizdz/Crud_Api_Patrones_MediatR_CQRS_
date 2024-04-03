using AutoMapper;
using FormulaOne.DataServices.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Request;
using FormulaOne.Entities.Dtos.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Into_CQRS_MediatR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AchievementsController : BaseController
    {
        public AchievementsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        [HttpGet]
        [Route("{driverId:guid}")]

        public async Task<IActionResult> GetDriverAchievement(Guid driverId)
        {
            var driverAchievement = await _unitOfWork._AchievementRepository.GetDriverAchievementAsync(driverId);

            if (driverAchievement == null)
                return NotFound("Achievement not found");


            var result = _mapper.Map<DriverAchievementResponse>(driverAchievement);

            return Ok(result);
        }
        [HttpPost]
   
        public async Task<IActionResult> AddAchievement([FromBody] CreateDriverAchievementRequest driverAchievementRequest) 
        {
            if (!ModelState.IsValid)
                return BadRequest();


            var result = _mapper.Map<Achievement>(driverAchievementRequest);
            await _unitOfWork._AchievementRepository.Add(result);
            await _unitOfWork.CompleteAsync();



            return CreatedAtAction(nameof(GetDriverAchievement), new { driverid = result.Id }, result);
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
