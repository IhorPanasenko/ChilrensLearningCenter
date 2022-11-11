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
    public class DirectionService : IDirectionService
    {
        private readonly IDirectionRepository directionRepository;

        private readonly ILogger<DirectionService> logger;

        public DirectionService(IDirectionRepository directionRepository, ILogger<DirectionService> logger)
        {
            this.directionRepository = directionRepository;
            this.logger = logger;
        }

        public List<Direction> GetAll()
        {
            List<Direction> directions = new List<Direction>();
            try
            {
                directions = directionRepository.GetAll();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }

            return directions;
        }

        public void StoredPeocedure(int price)
        {
            try
            {
                directionRepository.StoredProcedure(price);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }
        }
    }
}
