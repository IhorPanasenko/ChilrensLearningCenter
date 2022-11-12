using ChildrensLearningCenterWeb.ViewModels;
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

        public string ScalarFunction()
        {
            var res = _dbContext.Database.SqlQuery<string>($"SELECT [dbo].[ManyOldestSpecialistsDirection] ()").ToList()[0];
            return res;
        }

        List<StoredFunctionTableModel> ISpecialistsRepository.TableFunction()
        {
            var res = _dbContext.StoredFunctionTableModels.FromSql($"SELECT * FROM [dbo].[TableOldestSpecialist] ()").ToList();
            return res;
        }
    }
}
