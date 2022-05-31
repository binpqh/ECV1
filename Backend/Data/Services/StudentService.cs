using Data.Defined.Enum;
using Data.Interface;
using Data.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    /*public class StudentService : IStudentService
    {
        private readonly ECV1DevContext _context;
        public StudentService(ECV1DevContext context)
        {
            _context = context;
        }
        public async Task<StudentTypeResult> CreateAsync(StudentTypeInput create)
        {
            var std = new Student
            {
                Name = create.Name,
                Age = create.Age,
                Address = create.Address,
                Birthday = create.Birthday,
                Classkey = create.Classkey,
                Phone = create.Phone,
                Email = create.Email,
                Status = Status.Active
            };
            await _context.Students.AddAsync(std);
            await _context.SaveChangesAsync();
            return new StudentTypeResult
            {
                Id = std.Id,
                Name = std.Name,
                Age = std.Age,
                Address = std.Address,
                Birthday=std.Birthday,
                Classkey=std.Classkey,
                Phone =std.Phone,
                Email=std.Email,
            };
        }

        public async Task DeleteAsync(int id)
        {
            var std = await _context.Students.Where(e => e.Id == id && e.Status != Status.Deleted)
                .FirstOrDefaultAsync();
            if(std != null)
            {
                std.Status = Status.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<StudentTypeResult>> GetAllAsync()
        {
            var listStd = await _context.Students.Where(e => e.Status == Status.Active)
                .Select(e => new StudentTypeResult
                {
                    Id = e.Id,
                    Name = e.Name,
                    Age = e.Age,
                    Address = e.Address,
                    Birthday = e.Birthday,
                    Classkey = e.Classkey,
                    Phone = e.Phone,
                    Email = e.Email
                }).ToListAsync();

            return listStd;
        }

        public async Task<StudentTypeResult> GetByIdAsync(int id)
        {
            var std = await _context.Students.Where(e => e.Id == id && e.Status != Status.Deleted)
                .Select(e => new StudentTypeResult
                {
                    Id = e.Id,
                    Name = e.Name,
                    Age = e.Age,
                    Address = e.Address,
                    Birthday = e.Birthday,
                    Classkey = e.Classkey,
                    Phone = e.Phone,
                    Email = e.Email
                }).FirstOrDefaultAsync();
            if(std == null)
            {
                throw new Exception("Không tìm thấy id này");
            }    
            return std;
        }

        public async Task<StudentTypeResult> UpdateAsync(int id, StudentTypeInput update)
        {
            var std = await _context.Students.Where(e => e.Id == id && e.Status != Status.Deleted)
                .FirstOrDefaultAsync();
            if(std != null)
            {
                std.Name = update.Name ?? std.Name;
                std.Age = update.Age ?? std.Age;
                std.Address = update.Address ?? std.Address;
                std.Birthday = update.Birthday ?? std.Birthday;
                std.Classkey = update.Classkey ?? std.Classkey;
                std.Phone = update.Phone ?? std.Phone;
                std.Email = update.Email ?? std.Email;
                await _context.SaveChangesAsync();
            }
            return new StudentTypeResult
            {
                Id = std.Id,
                Name = std.Name,
                Age = std.Age,
                Address = std.Address,
                Birthday = std.Birthday,
                Classkey = std.Classkey,
                Phone = std.Phone,
                Email = std.Email
            };
        }
    }*/
}
