using FormulaOne.Entities.Dtos.Request;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Into_CQRS_MediatR.Feature.Drivers.Command.UpdateCommand
{
    public class UpdateDriverCommand : IRequest<bool>
    {
   

        public UpdateDriverRequest UpdateDriverRequest { get; }

        public UpdateDriverCommand(UpdateDriverRequest updateDriverRequest) {  

            UpdateDriverRequest = updateDriverRequest; 
        
        
        }

    }
}
