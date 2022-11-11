﻿using BLL.Interfaces;
using ChildrensLearningCenterWeb.ViewModels;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChildrensLearningCenterWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialistController : ControllerBase
    {
        private readonly ISpecialistService specialistService;

        private readonly ILogger<SpecialistController> logger;

        public SpecialistController(ISpecialistService specialistService, ILogger<SpecialistController> logger)
        {
            this.specialistService = specialistService;
            this.logger = logger;
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