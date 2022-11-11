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
        private readonly ChildrensLearningCenterContext _dbContext;

        public DirectionsController(ChildrensLearningCenterContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var directions = _dbContext.Directions.ToList();
            return Ok(directions);
        }

        [HttpGet]
        [Route("{price=int}")]
        public IActionResult StoredProceure([FromRoute] int price)
        {
            try
            {
                var res = _dbContext.Database.ExecuteSqlRaw($"Add_Description {price}");
                _dbContext.SaveChanges();
                return Ok(res);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
