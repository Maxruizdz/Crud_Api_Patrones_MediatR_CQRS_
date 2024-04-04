using FormulaOne.Entities.Dtos.Response;
using MediatR;

namespace Into_CQRS_MediatR.Feature.Queries.GetByIdQuey
{
    public class GetDriverByIdQuery : IRequest<GetDriverResponse>
    {

        public Guid DriverId { get; }

        public GetDriverByIdQuery(Guid id)
        {
            DriverId = id;
        }
    }
}
