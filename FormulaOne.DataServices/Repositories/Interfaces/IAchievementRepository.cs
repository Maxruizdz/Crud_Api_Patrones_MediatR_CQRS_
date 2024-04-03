﻿using FormulaOne.Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataServices.Repositories.Interfaces
{
    public interface IAchievementRepository: IGenericRepository<Achievement>
    {

        Task<Achievement> GetDriverAchievementAsync(Guid driverid);

    }
}
