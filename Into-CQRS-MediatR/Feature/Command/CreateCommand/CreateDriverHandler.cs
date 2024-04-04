using AutoMapper;
using FormulaOne.DataServices.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Request;
using FormulaOne.Entities.Dtos.Response;
using MediatR;

namespace Into_CQRS_MediatR.Feature.Command.CreateCommand
{
    public class CreateDriverHandler : IRequestHandler<CreateDriverCommand, GetDriverResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async  Task<GetDriverResponse> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            var driver = _mapper.Map<Driver>(request._request);

            await _unitOfWork._DriverRepository.Add(driver);
            await _unitOfWork.CompleteAsync();

            var driverResult = _mapper.Map<GetDriverResponse>(driver);
            return driverResult;

        }
    }
}
