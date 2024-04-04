using FormulaOne.Entities.Dtos.Request;
using FormulaOne.Entities.Dtos.Response;
using MediatR;

namespace Into_CQRS_MediatR.Feature.Achievements.Command.CreateCommand
{
    public class CreateAchievementCommand : IRequest<DriverAchievementResponse>
    {

        public  CreateDriverAchievementRequest  driverAchievement  { get; }

        public CreateAchievementCommand(CreateDriverAchievementRequest driverAchievementRequest) 
        {
            driverAchievement = driverAchievementRequest;
        
        }
    }
}
