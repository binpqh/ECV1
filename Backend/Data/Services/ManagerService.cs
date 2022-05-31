using Data.Defined.Enum;
using Data.Interface;
using Data.Tables;
using Data.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public class ManagerService : IManagerService
    {
        private readonly ECV1DevContext _context;
        public ManagerService(ECV1DevContext context)
        {
            _context = context;
        }    
        public async Task<ManagerTypeResult> CreateAsync(ManagerTypeInput create)
        {
            var tch = new Manager
            {
                Name = create.Name,
                Age = create.Age,
                Address = create.Address,
                Birthday = create.Birthday,
                Phone = create.Phone,
                Email = create.Email,
                Status = Status.Active
            };
            await _context.Managers.AddAsync(tch);
            await _context.SaveChangesAsync();
            return new ManagerTypeResult
            {
                Id = tch.Id,
                Name = tch.Name,
                Age = tch.Age,
                Address = tch.Address,
                Birthday = tch.Birthday,
                Phone = tch.Phone,
                Email = tch.Email,
            };
        }

        public async Task DeleteAsync(int id)
        {
            var tch = await _context.Managers.Where(e => e.Id == id && e.Status != Status.Deleted)
                .FirstOrDefaultAsync();
            if (tch != null)
            {
                tch.Status = Status.Deleted;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ManagerTypeResult>> GetAllAsync()
        {
            var listTch = await _context.Managers.Where(e => e.Status == Status.Active)
                .Select(e => new ManagerTypeResult
                {
                    Id = e.Id,
                    Name = e.Name,
                    Age = e.Age,
                    Address = e.Address,
                    Birthday = e.Birthday,
                    Phone = e.Phone,
                    Email = e.Email
                }).ToListAsync();

            return listTch;
        }

        public async Task<ManagerTypeResult> GetByIdAsync(int id)
        {
            var tch = await _context.Managers.Where(e => e.Id == id && e.Status != Status.Deleted)
                .Select(e => new ManagerTypeResult
                {
                    Id = e.Id,
                    Name = e.Name,
                    Age = e.Age,
                    Address = e.Address,
                    Birthday = e.Birthday,
                    Phone = e.Phone,
                    Email = e.Email
                }).FirstOrDefaultAsync();
            if (tch == null)
            {
                throw new Exception("Không tìm thấy id này");
            }
            return tch;
        }

        public async Task<ManagerTypeResult> UpdateAsync(int id, ManagerTypeInput update)
        {
            var std = await _context.Managers.Where(e => e.Id == id && e.Status != Status.Deleted)
                 .FirstOrDefaultAsync();
            if (std != null)
            {
                std.Name = update.Name ?? std.Name;
                std.Age = update.Age ?? std.Age;
                std.Address = update.Address ?? std.Address;
                std.Birthday = update.Birthday ?? std.Birthday;
                std.Phone = update.Phone ?? std.Phone;
                std.Email = update.Email ?? std.Email;
                await _context.SaveChangesAsync();
            }
            return new ManagerTypeResult
            {
                Id = std.Id,
                Name = std.Name,
                Age = std.Age,
                Address = std.Address,
                Birthday = std.Birthday,
                Phone = std.Phone,
                Email = std.Email
            };
        }
    }
}
