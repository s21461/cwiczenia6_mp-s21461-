using cwiczenia6_mp_s21461.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia6_mp_s21461.Services
{
    public interface IDbPrescriptionService
    {
        Task<SomeSortOfPrescription> GetPrescription(int id);
        
    }
}
