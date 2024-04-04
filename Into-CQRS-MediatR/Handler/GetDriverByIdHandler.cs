using AutoMapper;
using FormulaOne.DataServices.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Response;
using Into_CQRS_MediatR.Feature.Queries;
using MediatR;

namespace Into_CQRS_MediatR.Handler
{
    public class GetDriverByIdHandler : IRequestHandler<GetDriverByIdQuery,GetDriverResponse>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDriverByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetDriverResponse> Handle(GetDriverByIdQuery request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork._DriverRepository.GetById(request.DriverId);

           
               var result = _mapper.Map<GetDriverResponse>(driver);


            return result;

        }
    }
}
