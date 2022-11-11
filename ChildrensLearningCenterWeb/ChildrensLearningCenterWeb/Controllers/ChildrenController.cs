using BLL.Interfaces;
using ChildrensLearningCenterWeb.ViewModels;
using Core.Models;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ChildrensLearningCenterWeb.Controllers
{
    public class ChildrenController: ControllerBase
    {
        private readonly IChildrenService childrenService;

        private readonly ILogger<ChildrenController> logger;
        public ChildrenController(IChildrenService childrenService, ILogger<ChildrenController> logger)
        {
            this.childrenService = childrenService;
            this.logger = logger;
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
                //var client = 
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

    }
}
