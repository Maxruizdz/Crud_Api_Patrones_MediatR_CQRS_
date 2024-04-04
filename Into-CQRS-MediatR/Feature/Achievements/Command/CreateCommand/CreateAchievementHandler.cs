using AutoMapper;
using FormulaOne.DataServices.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Response;
using MediatR;

namespace Into_CQRS_MediatR.Feature.Achievements.Command.CreateCommand
{
    public class CreateAchievementHandler : IRequestHandler<CreateAchievementCommand, DriverAchievementResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAchievementHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<DriverAchievementResponse> Handle(CreateAchievementCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Achievement>(request.driverAchievement);
            await _unitOfWork._AchievementRepository.Add(result);
            await _unitOfWork.CompleteAsync();

            var response= _mapper.Map<DriverAchievementResponse>(result);
                
            return response;
        }
    }
}
