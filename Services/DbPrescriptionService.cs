﻿using cwiczenia6_mp_s21461.Models;
using cwiczenia6_mp_s21461.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia6_mp_s21461.Services
{
    public class DbPrescriptionService : IDbPrescriptionService
    {
        private readonly MainDbContext _context;

        public DbPrescriptionService(MainDbContext context)
        {
            _context = context;
        }

        public async Task<SomeSortOfPrescription> GetPrescription(int idPrescription)
        {
            return await _context.Prescriptions
                .Include(e => e.Prescription_Medicaments)
                .Where(e => e.IdPrescription == idPrescription)
                .Select(e => new SomeSortOfPrescription
                {
                    IdPrescription = e.IdPrescription,
                    Date = e.Date,
                    DueDate = e.DueDate,
                    Patient = new SomeSortOfPatient { FirstName = e.Patient.FirstName, LastName = e.Patient.LastName, Birthdate = e.Patient.Birthdate },
                    Doctor = new SomeSortOfDoctor { FirstName = e.Doctor.FirstName, LastName = e.Doctor.LastName, Email = e.Doctor.Email },
                    Medicaments = e.Prescription_Medicaments.Select(e => new SomeSortOfMedicament { Name = e.Medicament.Name }).ToList()
                }).FirstOrDefaultAsync(); 
                
        }
    }
}
