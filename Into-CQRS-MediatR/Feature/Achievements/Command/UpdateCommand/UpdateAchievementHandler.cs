using AutoMapper;
using FormulaOne.DataServices.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Response;
using MediatR;

namespace Into_CQRS_MediatR.Feature.Achievements.Command.UpdateCommand
{
    public class UpdateAchievementHandler : IRequestHandler<UpdateAchievementCommand, bool>
    {
       private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public UpdateAchievementHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(UpdateAchievementCommand request, CancellationToken cancellationToken)
        {
            var Update_Achievement= _mapper.Map<Achievement>(request.request);

            await _unitOfWork._AchievementRepository.Update(Update_Achievement);
            await _unitOfWork.CompleteAsync();



            return true;

        }



    }
}
