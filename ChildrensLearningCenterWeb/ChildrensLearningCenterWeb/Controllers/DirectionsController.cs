using BLL.Interfaces;
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
                return Ok(directions);
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
    }
}
