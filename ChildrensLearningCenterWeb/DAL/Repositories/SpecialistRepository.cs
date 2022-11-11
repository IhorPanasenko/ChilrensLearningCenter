using Core.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SpecialistRepository : ISpecialistsRepository
    {
        private readonly ChildrensLearningCenterContext _dbContext;

        public SpecialistRepository(ChildrensLearningCenterContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Specialist> GetAll()
        {
            return _dbContext.Specialists.ToList();
        }
    }
}
