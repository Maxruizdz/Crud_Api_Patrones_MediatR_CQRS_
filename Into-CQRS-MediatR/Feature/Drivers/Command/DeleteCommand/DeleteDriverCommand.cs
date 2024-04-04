using MediatR;

namespace Into_CQRS_MediatR.Feature.Drivers.Command.DeleteCommand
{
    public class DeleteDriverCommand : IRequest<bool>
    {

        public Guid drivenId { get; }


        public DeleteDriverCommand(Guid drivenId)
        {

            this.drivenId = drivenId;
        }
    }
}
