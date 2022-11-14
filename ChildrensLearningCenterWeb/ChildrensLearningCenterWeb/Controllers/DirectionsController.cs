using BLL.Interfaces;
using ChildrensLearningCenterWeb.ViewModels;
using Core.Models;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChildrensLearningCenterWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectionsController : ControllerBase
    {
        private readonly IDirectionService directionService;
        private readonly ILogger<DirectionsController> logger;

        public DirectionsController(ILogger<DirectionsController> logger, IDirectionService directionService)
        {
            this.logger = logger;
            this.directionService = directionService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var directions = directionService.GetAll();
                var directionViews = directions.Select(d => getViewModel(d)).ToList();
                return Ok(directionViews);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{price=int}")]
        public IActionResult StoredProceure([FromRoute] int price)
        {
            try
            {
                directionService.StoredPeocedure(price);
                return Ok();
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        private DirectionViewModel getViewModel(Direction direction)
        {
            return new DirectionViewModel
            {
                DirectionId = direction.DirectionId,
                Title = direction.Title,
                Purpose = direction.Purpose,
                Price = direction.Price,
                Description = direction.Description
            };

        }
    }
}
