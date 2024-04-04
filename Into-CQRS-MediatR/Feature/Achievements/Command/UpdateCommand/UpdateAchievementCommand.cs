using FormulaOne.Entities.Dtos.Request;
using FormulaOne.Entities.Dtos.Response;
using MediatR;

namespace Into_CQRS_MediatR.Feature.Achievements.Command.UpdateCommand
{
    public class UpdateAchievementCommand : IRequest<bool>
    {

       public UpdateDriverAchievementRequest request;

        public UpdateAchievementCommand(UpdateDriverAchievementRequest updateDriverAchievement) 
        { 
            request = updateDriverAchievement;
        
        }
    }
}
