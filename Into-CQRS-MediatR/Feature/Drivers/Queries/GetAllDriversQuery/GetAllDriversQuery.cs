using FormulaOne.Entities.Dtos.Response;
using MediatR;

namespace Into_CQRS_MediatR.Feature.Drivers.Queries.GetAllDriversQuery
{
    public class GetAllDriversQuery : IRequest<IEnumerable<GetDriverResponse>>
    {
    }
}
