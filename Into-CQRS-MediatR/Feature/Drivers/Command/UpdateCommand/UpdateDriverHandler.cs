using AutoMapper;
using FormulaOne.DataServices.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using MediatR;

namespace Into_CQRS_MediatR.Feature.Drivers.Command.UpdateCommand
{
    public class UpdateDriverHandler : IRequestHandler<UpdateDriverCommand, bool>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateDriverCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Driver>(request.UpdateDriverRequest);

            await _unitOfWork._DriverRepository.Update(result);
            await _unitOfWork.CompleteAsync();


            return true;

        } 
    
    

    }

}
