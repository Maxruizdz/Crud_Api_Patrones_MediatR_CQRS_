using FormulaOne.DataServices.Data;
using FormulaOne.DataServices.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataServices.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _appContext;
      public IDriverRepository _DriverRepository { get; }

        public IAchievementRepository _AchievementRepository { get; }

        public UnitOfWork(AppDbContext appDbContext, ILoggerFactory loggerFactory , IDriverRepository driverRepository, IAchievementRepository achievementRepository)
        {   _appContext = appDbContext;
            var logger = loggerFactory.CreateLogger("Logs");
            _DriverRepository = driverRepository;
            _AchievementRepository = achievementRepository;
            
        }

        public async Task<bool> CompleteAsync()
        {
            var result = await _appContext.SaveChangesAsync();

            return result > 0;
        }

        public void Dispose()
        {
            _appContext.Dispose();
        }
    }
}
