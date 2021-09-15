using BojanDamchevski.MoviesAPI.App.Db;
using BojanDamchevski.MoviesAPI.App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BojanDamchevski.MoviesAPI.App.Services
{
    public class DirectorService
    {
        private AppDbContext _dbContext;
        public DirectorService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Director> GetAll()
        {
            return _dbContext.Directors
                .Include(x=>x.Movies)
                .ToList();
        }
    }
}
