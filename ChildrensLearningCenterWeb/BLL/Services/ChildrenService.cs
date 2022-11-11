using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Core.Models;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;

namespace BLL.Services
{

    internal class ChildrenService : IChildrenService
    {
        private readonly IChildrenRepository childrenRepository;
        private readonly ILogger<ChildrenService> logger;

        public ChildrenService(IChildrenRepository childrenRepository, ILogger<ChildrenService> logger)
        {
            this.childrenRepository = childrenRepository;
            this.logger = logger;
        }

        public void Create(Children children)
        {
            try
            {
                childrenRepository.Create(children);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }
        }

        public void Delete(int id)
        {
            if (id < 0)
            {
                throw new ArgumentNullException("id must be > 0");
            }

            try
            {
                childrenRepository.Delete(id);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }
        }

        public Children? Get(int id)
        {
            if (id < 0)
            {
                throw new ArgumentNullException("id must be > 0");
            }

            try
            {
                return childrenRepository.Get(id);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }

            return null;
        }

        public List<Children> GetAll()
        {
           List<Children> childrens = new List<Children>();

            try
            {
                childrens = childrenRepository.GetAll();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }

            return childrens;
        }

        public void Update(int id, Children children)
        {
            if (id < 0)
            {
                throw new ArgumentNullException("id must be > 0");
            }

            try
            {
                childrenRepository.Update(id, children);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }
        }
    }
}
