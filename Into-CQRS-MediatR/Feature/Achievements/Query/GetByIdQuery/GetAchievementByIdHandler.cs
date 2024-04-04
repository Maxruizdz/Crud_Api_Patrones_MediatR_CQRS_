using AutoMapper;
using FormulaOne.DataServices.Repositories;
using FormulaOne.DataServices.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Response;
using Into_CQRS_MediatR.Feature.Achievements.Query.GetByIdCommand;
using MediatR;

namespace Into_CQRS_MediatR.Feature.Achievements.Query.GetByIdQuery
{
    public class GetAchievementByIdHandler : IRequestHandler<GetAchievementByIdQuery, DriverAchievementResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAchievementByIdHandler(IUnitOfWork unitWork, IMapper mapper)
        {
            _unitOfWork = unitWork;
            _mapper = mapper;
        }
        public async Task<DriverAchievementResponse> Handle(GetAchievementByIdQuery request, CancellationToken cancellationToken)
        {

            var driverAchievement = await _unitOfWork._AchievementRepository.GetDriverAchievementAsync(request.Id);

            if (driverAchievement == null)
                return null;


            var result = _mapper.Map<DriverAchievementResponse>(driverAchievement);

            return result;
        }
    }
}
