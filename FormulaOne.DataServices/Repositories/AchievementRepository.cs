using FormulaOne.DataServices.Data;
using FormulaOne.DataServices.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataServices.Repositories
{
    public class AchievementRepository : GenericRepository<Achievement>, IAchievementRepository
    {
        public AchievementRepository(ILogger<AchievementRepository> logger, AppDbContext appDbContext) : base(logger, appDbContext)
        {
        }

        public  async Task<Achievement> GetDriverAchievementAsync(Guid driverid)
        {
            try 
            {

                return _DbSet.FirstOrDefault(p => p.DriverId == driverid);
           
            }
            catch (Exception ex) {

                _logger.LogError(ex, message: "{Repo} GetDriverAchievement function error ", typeof(Achievement));


                throw;



            }
        }


        public async override Task<IEnumerable<Achievement>> All()
        {
            try { 
            
            
            return _DbSet.Where(prop=>prop.Status==1 )
                    .AsNoTracking().
                    AsSplitQuery().
                    OrderBy(prop=>prop.AddedDate).
                    ToList();
            
            
            
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, message: "{Repo} All function error ", typeof(Achievement));


                throw;



            }
        }

        public async override Task<bool> Delete(Guid id)
        {
            try
            {
                var achieventmentDB = await _DbSet.FirstOrDefaultAsync(pro => pro.Id == id);

                if (achieventmentDB is null)
                    return false;


                achieventmentDB.Status = 0;
                achieventmentDB.UpdateDate  = DateTime.UtcNow;

                return true;


            }


              catch (Exception ex)
            {

                _logger.LogError(ex, message: "{Repo} Delete function error ", typeof(Achievement));


                throw;



            }
        
        }

        public async override Task<bool> Update(Achievement entity)
        {
            try
            {
                var achievemennDB = await _DbSet.FirstOrDefaultAsync(prop => prop.Id == entity.Id);

                if (achievemennDB is null)
                    return false;

                achievemennDB.UpdateDate = DateTime.UtcNow;
                achievemennDB.FastestLab = entity.FastestLab;
                achievemennDB.PolePosition = entity.PolePosition;
                achievemennDB.RaceWins = entity.RaceWins;
                achievemennDB.WorldChampionship = entity.WorldChampionship;


                return true;
            }
         
                  catch (Exception ex)
            {

                _logger.LogError(ex, message: "{Repo} Update function error ", typeof(Achievement));


                throw;

            }

        }
    }
}
