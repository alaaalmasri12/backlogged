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
    public class backloggedRepository : GenericRepository<GameApi>, IGameApiepoistory
	{
		private readonly backloggdDbContext _dbContext;

		public backloggedRepository(backloggdDbContext dbContext) : base(dbContext)
		{
			_dbContext= dbContext;
		}

		public Task<IReadOnlyList<GameApi>> Getegamebyname(string? gamename)
		{
			throw new NotImplementedException();
		}

		

		

		public Task<IReadOnlyList<GameApi>> getgameByid(int? Typeid)
		{
			throw new NotImplementedException();
		}
	}
}
