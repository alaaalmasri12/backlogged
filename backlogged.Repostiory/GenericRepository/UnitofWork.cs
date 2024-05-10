using backlogged.Core.IGenericRepository;
using backlogged.Repostiory.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backlogged.Repostiory.GenericRepository
{
    public class UnitofWork : IunitofWork
    {
        private readonly backloggdDbContext _DbContext;

        public IGameApiepoistory gameApiepoistory { get; set; }
        public UnitofWork(backloggdDbContext dbContext)
        {
			gameApiepoistory = new backloggedRepository(dbContext);
         
            this._DbContext = dbContext;
        }

       

        public async Task<int> SaveAsync()
        {
            return await _DbContext.SaveChangesAsync();
        }
    }
}
