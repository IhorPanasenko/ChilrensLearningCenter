using BLL.Interfaces;
using ChildrensLearningCenterWeb.ViewModels;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChildrensLearningCenterWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService classService;

        private readonly ILogger<ClassController> logger;

        public ClassController(ILogger<ClassController> logger, IClassService classService)
        {
            this.logger = logger;
            this.classService = classService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var classes = classService.GetAll();
                var classViews = classes.Select(c => getViewModel(c)).ToList();
                return Ok(classViews);

            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        private ClassViewModel? getViewModel(Class clas)
        {
            try
            {
                return new ClassViewModel
                {
                    ClassId = clas.ClassId,
                    DayOfWeek = clas.DayOfWeek,
                    ChildId = clas.ChildId,
                    SpecialistId = clas.SpecialistId,
                    Time = clas.Time
                };
            }catch (Exception e)
            {
                logger.LogError(e.Message);
            }

            return null;
        }
    }
}
