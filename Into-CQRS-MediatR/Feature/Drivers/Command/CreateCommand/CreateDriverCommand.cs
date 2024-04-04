using FormulaOne.Entities.Dtos.Request;
using FormulaOne.Entities.Dtos.Response;
using MediatR;

namespace Into_CQRS_MediatR.Feature.Drivers.Command.CreateCommand
{
    public class CreateDriverCommand : IRequest<GetDriverResponse>
    {

        public CreateDriverRequest _request { get; }

        public CreateDriverCommand(CreateDriverRequest request)
        {
            _request = request;
        }
    }
}
