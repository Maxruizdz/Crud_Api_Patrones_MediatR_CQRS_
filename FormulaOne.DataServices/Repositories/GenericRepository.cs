using FormulaOne.DataServices.Data;
using FormulaOne.DataServices.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.DataServices.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public readonly ILogger _logger;
        protected AppDbContext _appDbContext;
        internal DbSet<T> _DbSet;


        public GenericRepository( ILogger logger, AppDbContext appDbContext
            ) 
        {
            _appDbContext = appDbContext;
            _logger = logger;
            _DbSet = appDbContext.Set<T>();
        
        
        }




        public async  Task<bool> Add(T entity)
        {
            await _DbSet.AddAsync(entity);

            return true;
        }

        public virtual Task<IEnumerable<T>> All()
        {
            throw new NotImplementedException();
        }

        public virtual  async Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetById(Guid id)
        {

          var user=  await _DbSet.FindAsync(id);

            return user;
        }

        public virtual Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
