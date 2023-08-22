using BLL.Interfaces;
using Core.Models;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ClassService: IClassService
    {
        private readonly IClassRepository classRepository;

        private readonly ILogger<ClassService> logger;

        public ClassService(IClassRepository classRepository, ILogger<ClassService> logger)
        {
            this.classRepository = classRepository;
            this.logger = logger;
        }

        public List<Class> GetAll()
        {
            List<Class> classes = new List<Class>();   

            try
            {
               classes = classRepository.GetAll();
            }catch(Exception e)
            {
                logger.LogError(e.Message);
            }

            return classes;
        }
    }
}
