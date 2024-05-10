using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backlogged.Repostiory.Data
{
	public class backloggdDbContext : DbContext
	{
		public backloggdDbContext(DbContextOptions<backloggdDbContext> options)
	 : base(options)
		{

		}
	}
}
