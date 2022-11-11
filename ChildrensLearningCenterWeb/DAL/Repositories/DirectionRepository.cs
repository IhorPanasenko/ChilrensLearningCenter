using Core.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class DirectionRepository : IDirectionRepository
    {
        private readonly ChildrensLearningCenterContext _dbContext;

        public DirectionRepository(ChildrensLearningCenterContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Direction> GetAll()
        {
            return _dbContext.Directions.ToList();
        }

        public void StoredProcedure(int price)
        {
            _dbContext.Database.ExecuteSqlRaw($"Add_Description {price}");
            _dbContext.SaveChanges();
        }
    }
}
