using Core.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class ClassRepository : IClassRepository
    {
        private readonly ChildrensLearningCenterContext _dbContext;

        public ClassRepository(ChildrensLearningCenterContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Class> GetAll()
        {
            var classes = _dbContext.Classes.ToList();
            return classes;
        }
    }
}
