using backlogged.Core.IGenericRepository;
using backlogged.Core.Models;
using backlogged.Repostiory.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backlogged.Repostiory.GenericRepository
{
    public class GenericRepository<T> : IgenericRepoistory<T> where T : class
    {
        private readonly backloggdDbContext backloggdDbContext;
        public GenericRepository(backloggdDbContext dbContext)
        {
			backloggdDbContext = dbContext;
        }

       
        public async Task CreateAsync(T entity)
        {
            await this.backloggdDbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T enitiy)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync(IPagenation<T> pagenation)
        {
			//if(typeof(T)== typeof(Estate))
			//{


			//        //return (IReadOnlyList<T>)await this.onionbackloggedDbContext.Estates.Include(x => x.EstateType).ToListAsync();
			//        var query = (IQueryable<T>)this.onionbackloggedDbContext.Estates.Include(x => x.EstateType);
			//        var pageinateddata = (IReadOnlyList<T>) await pagenation.ApplyPageination(query);
			//        return pageinateddata;


			//}

			//return await this.onionbackloggedDbContext.Set<T>().ToListAsync();
			throw new NotImplementedException();

		}


		public async Task<T?> Getbyid(int id)
        {
			throw new NotImplementedException();

			//if (typeof(T) == typeof(Estate))
			//{
			//  return     await this.onionbackloggedDbContext.Estates.Include(x => x.EstateType).SingleOrDefaultAsync(p => p.Id == id) as T;
			//}
			//return await this.onionbackloggedDbContext.Set<T>().FindAsync(id);
		}

		public void Update(T enitiy)
        {
            throw new NotImplementedException();
        }
    }
}
