using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Response;
using MediatR;

namespace Into_CQRS_MediatR.Feature.Achievements.Query.GetByIdCommand
{
    public class GetAchievementByIdQuery: IRequest<DriverAchievementResponse>
    {

        public Guid Id { get; }

        public GetAchievementByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
