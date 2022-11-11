using BLL.Interfaces;
using ChildrensLearningCenterWeb.ViewModels;
using Core.Models;
using DAL;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ChildrensLearningCenterWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChildrenController: ControllerBase
    {
        private readonly IChildrenService childrenService;

        private readonly ILogger<ChildrenController> logger;
        private readonly ChildrensLearningCenterContext _dbContext;

        public ChildrenController(IChildrenService childrenService, ILogger<ChildrenController> logger, ChildrensLearningCenterContext dbContext)
        {
            this.childrenService = childrenService;
            this.logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet("{id=int}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                Children? children = childrenService.Get(id); ;

                if(children == null)
                {
                    return NotFound($"No child with id {id}");
                }

                var childrenViewModel = getChildrenViewModel(children);
                return Ok(childrenViewModel);

            }
            catch (ArgumentNullException e)
            {
                logger.LogError(e.Message);
                return ValidationProblem(e.Message);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return ValidationProblem(e.Message);
            }
        }

        private ChildrenViewModel? getChildrenViewModel (Children children)
        {
            try
            {
                return new ChildrenViewModel
                {
                    ChildId = children.ChildId,
                    FirstName = children.FirstName,
                    SecondName = children.SecondName,
                    BirthdayDate = children.BirthdayDate,
                    ClientId = children.ClientId
                };
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }

            return null;
        }

        [HttpPost]
        [Route("StoredProcedure")]
        
        public void StroedProcedureCreate(ChildParentViewModel view)
        {
            _dbContext.Childrens.FromSqlRaw($"CreateNewClientWithChild {view.ClientFirstName}, {view.ClientSecondName}, {view.ClientTelephone}, {view.ClientEmail}, {view.ClientBirthdayDate}, {view.ChildFirstName}, {view.ChildSecondName}, {view.ChildBirthdayDate}").ToList();
            _dbContext.SaveChanges();
        }

    }
}
