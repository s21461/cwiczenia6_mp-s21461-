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
    [Route("api/prescription")]
    [ApiController]
    public class PrescriptionController : Controller
    {
        
        private readonly IDbPrescriptionService _dbService;

       
        public PrescriptionController(IDbPrescriptionService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        [Route("{idPrescription}")]
        public async Task<IActionResult> GetPrescription([FromRoute] int idPrescription)
        {
            var prescription = await _dbService.GetPrescription(idPrescription);
            return Ok(prescription);
        }

        

    }
}
