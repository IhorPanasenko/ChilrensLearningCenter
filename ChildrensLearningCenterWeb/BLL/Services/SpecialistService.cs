using BLL.Interfaces;
using Core.Models;
using DAL.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SpecialistService : ISpecialistService
    {
        private readonly ISpecialistsRepository specialistsRepository;

        private readonly ILogger<SpecialistService> logger;

        public SpecialistService(ISpecialistsRepository specialistsRepository, ILogger<SpecialistService> logger)
        {
            this.specialistsRepository = specialistsRepository;
            this.logger = logger;
        }

        public List<Specialist> GetAll()
        {
            List<Specialist> specialists = new List<Specialist>();
            try
            {
                specialists =  specialistsRepository.GetAll();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }

            return specialists;
        }
    }
}
