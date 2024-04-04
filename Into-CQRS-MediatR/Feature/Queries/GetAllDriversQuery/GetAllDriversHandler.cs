using AutoMapper;
using FormulaOne.DataServices.Repositories.Interfaces;
using FormulaOne.Entities.Dtos.Response;
using MediatR;
using MediatR.Wrappers;

namespace Into_CQRS_MediatR.Feature.Queries.GetAllDriversQuery
{
    public class GetAllDriversHandler : IRequestHandler<GetAllDriversQuery, IEnumerable<GetDriverResponse>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllDriversHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetDriverResponse>> Handle(GetAllDriversQuery request, CancellationToken cancellationToken)
        {
            var drivers = await _unitOfWork._DriverRepository.All();

            var result = _mapper.Map<IEnumerable<GetDriverResponse>>(drivers);

            return result;
        }
    }
}
