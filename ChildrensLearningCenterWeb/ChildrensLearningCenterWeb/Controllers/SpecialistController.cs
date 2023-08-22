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
    public class SpecialistController : ControllerBase
    {
        private readonly ISpecialistService specialistService;

        private readonly ILogger<SpecialistController> logger;
        private readonly ChildrensLearningCenterContext _dbContext;

        public SpecialistController(ISpecialistService specialistService, ILogger<SpecialistController> logger, ChildrensLearningCenterContext dbContext)
        {
            this.specialistService = specialistService;
            this.logger = logger;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var specialists = specialistService.GetAll();
                var specialistViews = specialists.Select(s => getViewModel(s)).ToList();
                return Ok(specialistViews);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("TableFunction")]
        public IActionResult TableFunction()
        {
            try
            {
                var objs = specialistService.TableFunction();
                var viewObjs = objs.Select(o => getViewModel(o)).ToList();
                return Ok(viewObjs);

            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest();
            }
        }


        [HttpGet]
        [Route("ScalarFunction")]
        public IActionResult ScalarFunction()
        {
            try
            {
                return Ok(specialistService.ScalarFunction());
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("TwoTables")]

        public IActionResult TwoTables()
        {
            try
            {
               // List<Specialist> specialists = _dbContext.Specialists.Include(s => s.Direction).ToList();
               List<Specialist> specialists = specialistService.TwoTables();
                var twotablesViewModels = specialists.Select(s => getViewModelTwoTables(s)).ToList();

                return Ok(twotablesViewModels);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
        }

        private TwoTablesViewModel? getViewModelTwoTables(Specialist specialist)
        {
            try
            {
                return new TwoTablesViewModel
                {
                    SpecialistId = specialist.SpecialistId,
                    FirstName = specialist.FirstName,
                    SecondName = specialist.SecondName,
                    BirthdayDate = specialist.BirthdayDate,
                    DirectionId = specialist.DirectionId,
                    Title = specialist.Direction == null ? null : specialist.Direction.Title,
                    Price = specialist.Direction == null ? 0 : specialist.Direction.Price
                };
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }

            return null;
        }

        private StoredFunctionTableViewModel? getViewModel(StoredFunctionTableModel tableModel)
        {
            try
            {
                return new StoredFunctionTableViewModel
                {
                    SpecialistID = tableModel.SpecialistID,
                    DirectionID = tableModel.DirectionID
                };

            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }

            return null;
        }

        private SpecialistViewModel getViewModel(Specialist specialist)
        {
            try
            {
                return new SpecialistViewModel
                {
                    SpecialistId = specialist.SpecialistId,
                    FirstName = specialist.FirstName,
                    SecondName = specialist.SecondName,
                    Telephone = specialist.Telephone,
                    YearsExperience = specialist.YearsExperience,
                    BirthdayDate = specialist.BirthdayDate,
                    DirectionId = specialist.DirectionId,
                    RoomId = specialist.RoomId
                };
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return null;
            }
        }
    }
}
