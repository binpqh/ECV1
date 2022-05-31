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
    /*public class TeacherService : ITeacherService
    {
        private readonly ECV1DevContext _context;
        public TeacherService(ECV1DevContext context)
        {
            _context = context;
        }
        public async Task<TeacherTypeResult> CreateAsync(TeacherTypeInput create)
        {
            var tch = new Teacher
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
            await _context.Teachers.AddAsync(tch);
            await _context.SaveChangesAsync();
            return new TeacherTypeResult
            {
                Id = tch.Id,
                Name = tch.Name,
                Age = tch.Age,
                Address = tch.Address,
                Birthday = tch.Birthday,
                Classkey = tch.Classkey,
                Phone = tch.Phone,
                Email = tch.Email,
            };
        }

        public async Task DeleteAsync(int id)
        {
            var tch = await _context.Teachers.Where(e => e.Id == id && e.Status != Status.Deleted)
                .FirstOrDefaultAsync();
            if (tch != null)
            {
                tch.Status = Status.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<TeacherTypeResult>> GetAllAsync()
        {
            var listTch = await _context.Teachers.Where(e => e.Status == Status.Active)
                .Select(e => new TeacherTypeResult
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

            return listTch;
        }

        public async Task<TeacherTypeResult> GetByIdAsync(int id)
        {
            var tch = await _context.Teachers.Where(e => e.Id == id && e.Status != Status.Deleted)
                .Select(e => new TeacherTypeResult
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
            if (tch == null)
            {
                throw new Exception("Không tìm thấy id này");
            }
            return tch;
        }

        public async Task<TeacherTypeResult> UpdateAsync(int id, TeacherTypeInput update)
        {
            var std = await _context.Teachers.Where(e => e.Id == id && e.Status != Status.Deleted)
                 .FirstOrDefaultAsync();
            if (std != null)
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
            return new TeacherTypeResult
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
