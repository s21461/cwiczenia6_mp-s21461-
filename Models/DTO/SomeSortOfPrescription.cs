using cwiczenia6_mp_s21461.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia6_mp_s21461.Models.DTO
{
    public class SomeSortOfPrescription
    {
        public int IdPrescription { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public SomeSortOfPatient Patient { get; set; }
        public SomeSortOfDoctor Doctor { get; set; }
        public IEnumerable<SomeSortOfMedicament> Medicaments { get; set; }
    }
}
