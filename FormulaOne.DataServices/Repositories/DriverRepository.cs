using FormulaOne.DataServices.Data;
using FormulaOne.DataServices.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataServices.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(ILogger<DriverRepository>logger, AppDbContext appDbContext) : base(logger, appDbContext)
        {
        }


        public override async Task<IEnumerable<Driver>> All() 
        {


            try
            {
                return await _DbSet.Where(p => p.Status == 1).
                        AsNoTracking().
                        AsSplitQuery().
                        OrderBy(x => x.AddedDate)
                        .ToListAsync();


            }
            catch (Exception ex)
            {

                _logger.LogError(ex,message: "{Repo} all function error ", typeof(DriverRepository));


                throw;
            }
        
        
        }

        public override async Task<bool> Delete(Guid id)
        {
            try 
            {                       
                  var result = await _DbSet.FirstOrDefaultAsync(x => x.Id == id);
                if (result != null)
                    return false;

                result.Status = 0;
                result.UpdateDate = DateTime.UtcNow;
                return true;


            } 
            catch (Exception ex){
                _logger.LogError(ex, message: "{Repo} Delete function error ", typeof(DriverRepository));


                throw;


            }
        }


        public override async  Task<bool> Update(Driver entity)
        {
            try
            {
                var driveDb = await _DbSet.FirstOrDefaultAsync(p => p.Id == entity.Id);


                if (driveDb == null)
                    return false;



                driveDb.DriverNumber = entity.DriverNumber;
                driveDb.UpdateDate = DateTime.UtcNow;
                driveDb.FirstName = entity.FirstName;
                driveDb.LastName = entity.LastName;
                driveDb.DateOfBirth = entity.DateOfBirth;

                return true;
            }
            catch(Exception ex) {

                _logger.LogError(ex, message: "{Repo} Update function error ", typeof(DriverRepository));


                throw;

            }
           
        }
    }
}
