using FormulaOne.DataServices.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataServices.Repositories.Interfaces
{
    public interface IUnitOfWork
    {


        IDriverRepository _DriverRepository { get; }
        IAchievementRepository _AchievementRepository { get; }

        Task<bool> CompleteAsync();





    }
}
