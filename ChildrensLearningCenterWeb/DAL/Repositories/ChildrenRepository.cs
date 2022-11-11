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
    internal class ChildrenRepository : IChildrenRepository
    {
        private readonly ChildrensLearningCenterContext _dbContext;

        public ChildrenRepository(ChildrensLearningCenterContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Children children)
        {
            _dbContext.Childrens.Add(children);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var child = _dbContext.Childrens.Find(id);

            if (child is null)
            {
                throw new ArgumentException($"No child with id {id}");
            }

            _dbContext.Childrens.Remove(child);
             _dbContext.SaveChanges();
        }

        public Children? Get(int id)
        {
            return _dbContext.Childrens.Include(ch=>ch.Client).FirstOrDefault(ch=>ch.ChildId == id);
        }

        public List<Children> GetAll()
        {
            return _dbContext.Childrens.Include(ch=>ch.Client).ToList();
        }

        public void Update(int id, Children children)
        {
            var child = _dbContext.Childrens.Find(id);

            if(child is null)
            {
                throw new ArgumentException($"No child with id {id}");
            }

            child.FirstName = children.FirstName;
            child.SecondName = children.SecondName;
            child.BirthdayDate = children.BirthdayDate;
            child.ClientId = children.ClientId;

            _dbContext.Childrens.Update(child);
            _dbContext.SaveChanges();
        }
    }
}
