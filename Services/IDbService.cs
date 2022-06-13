using cwiczenia6_mp_s21461.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia6_mp_s21461.Services
{
    public interface IDbService
    {
        Task<IEnumerable<SomeSortOfDoctor>> GetDoctors();
        Task<int> DeleteDoctor(int id);
        Task<int> AddDoctor(SomeSortOfDoctor doctor);
        Task<int> EditDoctor(SomeSortOfDoctor doctor, int id);
    }
}
