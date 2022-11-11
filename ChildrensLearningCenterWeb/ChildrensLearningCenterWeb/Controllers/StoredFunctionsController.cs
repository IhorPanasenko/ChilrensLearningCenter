using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChildrensLearningCenterWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoredFunctionsController : ControllerBase
    {
        private readonly ChildrensLearningCenterContext _dbContext;

        public StoredFunctionsController(ChildrensLearningCenterContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult ScalarFunction()
        {
            //var res = _dbContext.Database.SqlQuery<int>("SELECT [dbo].[ManyOldestSpecialistsDirection] ()");
            int res = _dbContext.Database.
            return Ok(res);
        }
    }
}
