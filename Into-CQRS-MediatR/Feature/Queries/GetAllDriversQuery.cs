using FormulaOne.Entities.Dtos.Response;
using MediatR;

namespace Into_CQRS_MediatR.Feature.Queries
{
    public class GetAllDriversQuery : IRequest<IEnumerable<GetDriverResponse>>
    {
    }
}
