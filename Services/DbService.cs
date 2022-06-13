using cwiczenia6_mp_s21461.Models;
using cwiczenia6_mp_s21461.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cwiczenia6_mp_s21461.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _context;

        public DbService(MainDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddDoctor(SomeSortOfDoctor doctor)
        {
            var result = await _context.Doctors.Where(e => e.FirstName == doctor.FirstName && e.LastName == doctor.LastName).FirstOrDefaultAsync();
            if (result != null)
            {
                return 1;
            }

            var addDoctor = new Doctor
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            };
            await _context.Doctors.AddAsync(addDoctor);
            await _context.SaveChangesAsync();
            return 0;


        }

        public async Task<int> DeleteDoctor(int id)
        {


            var result = await _context.Doctors.Where(e => e.IdDoctor == id).FirstOrDefaultAsync();
            if (result == null)
            {
                return 1;
            }

            //var doctor = new Doctor { IdDoctor = id };
            //_context.Doctors.Attach(result);
            _context.Doctors.Remove(result);

            await _context.SaveChangesAsync();

            return 0;
            
        }

        public async Task<int> EditDoctor(SomeSortOfDoctor doctor, int id)
        {
            var result = await _context.Doctors.Where(e => e.IdDoctor == id).FirstOrDefaultAsync();
            if (result == null)
            {
                return 1;
            }
 
            result.FirstName = doctor.FirstName;
            result.LastName = doctor.LastName;
            result.Email = doctor.Email;

            await _context.SaveChangesAsync();

            return 0;
            
        }

        public async Task<IEnumerable<SomeSortOfDoctor>> GetDoctors()
        {
            return await _context.Doctors.Select(e => new SomeSortOfDoctor
            {
                IdDoctor = e.IdDoctor,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email
            }).OrderByDescending(e => e.LastName).ToListAsync();
        }

    }
}
