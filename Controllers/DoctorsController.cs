using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cwiczenia6_mp_s21461.Models;
using cwiczenia6_mp_s21461.Services;
using cwiczenia6_mp_s21461.Models.DTO;

namespace cwiczenia6_mp_s21461.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorsController : Controller
    {
        
        private readonly IDbService _dbService;

       
        public DoctorsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _dbService.GetDoctors();
            return Ok(doctors);
        }

        [HttpDelete]
        [Route("{idDoctor}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int idDoctor)
        {
            var result = await _dbService.DeleteDoctor(idDoctor);
            switch (result)
            {
                case 0:
                    return Ok("Doctor deleteted");
                case 1:
                    return NotFound("Doctor not found");
                default:
                    return BadRequest(result);
            }

        }

        [HttpPut]
        [Route("{idDoctor}")]
        public async Task<IActionResult> EditDoctor([FromBody] SomeSortOfDoctor doctor, [FromRoute] int idDoctor)
        {

            var result = await _dbService.EditDoctor(doctor, idDoctor);
            switch (result)
            {
                case 0:
                    return Ok("Doctor edited");
                case 1:
                    return NotFound("Doctor not found");
                default:
                    return BadRequest(result);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor([FromBody] SomeSortOfDoctor doctor)
        {
            var result = await _dbService.AddDoctor(doctor);
            switch (result)
            {
                case 0:
                    return Ok("Doctor added");
                case 1:
                    return NotFound("Doctor already exist");
                default:
                    return BadRequest(result);
            }
        }

    }
}
