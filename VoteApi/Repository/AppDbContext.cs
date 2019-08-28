using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VoteApi.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<DbContext> options): base(options)
        {

        }
    }
}
