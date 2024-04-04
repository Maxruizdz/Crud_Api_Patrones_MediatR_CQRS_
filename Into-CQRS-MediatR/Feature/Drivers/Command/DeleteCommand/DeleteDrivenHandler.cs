using AutoMapper;
using FormulaOne.DataServices.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Into_CQRS_MediatR.Feature.Drivers.Command.DeleteCommand
{
    public class DeleteDrivenHandler : IRequestHandler<DeleteDriverCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDrivenHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteDriverCommand request, CancellationToken cancellationToken)
        {
            var driver = await _unitOfWork._DriverRepository.GetById(request.drivenId);

            if (driver == null)
                return false;

            await _unitOfWork._DriverRepository.Delete(request.drivenId);
            await _unitOfWork.CompleteAsync();

            return true;

        }
    }
}
