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
    public class StudentPointService : IStudentPointService
    {
        private readonly ECV1DevContext _context;
        public StudentPointService(ECV1DevContext context)
        {
            _context = context;
        }
        public async Task<StudentPointTypeResult> CreateStudentPoint(StudentPointTypeInput studentPoint)
        {
            var stpoint = new StudentPoint
            {
                IdTranscript = studentPoint.IdTranscript,
                IdPoint = studentPoint.IdPoint,
            };
            await _context.StudentPoints.AddAsync(stpoint);
            await _context.SaveChangesAsync();
            return new StudentPointTypeResult
            {
                Id = stpoint.Id,
                IdPoint = stpoint.IdPoint,
                IdTranscript = stpoint.IdTranscript,
            };
        }

        public async Task DeleteStudentPoint(int id)
        {
            var studentPoint = _context.StudentPoints
                .Where(e => e.IdTranscript == id)
                .FirstOrDefaultAsync();
            if (studentPoint == null)
            {
                throw new Exception("Remove StudentPoint failed");
            }    
            _context.StudentPoints.Remove(await studentPoint);
            await _context.SaveChangesAsync();
        }

        public async Task<List<StudentPointTypeResult>> GetAllStudentPoint()
        {
            var listpoint = await _context.StudentPoints.Select
                (e => new StudentPointTypeResult
                {
                    Id = e.Id,
                    IdPoint = e.IdPoint,
                    IdTranscript = e.IdTranscript
                }).ToListAsync();
            return listpoint;
        }

        public async Task<StudentPointTypeResult> UpdateStudentPoint(int id, StudentPointTypeInput studentPoint)
        {

            var stpoint = await _context.StudentPoints.Where(e => e.Id == id)
                .FirstOrDefaultAsync();
            if(stpoint == null)
            {
                throw new Exception("Không tìm thấy điểm của học sinh");
            }
            stpoint.IdTranscript = studentPoint.IdTranscript;
            stpoint.IdPoint = studentPoint.IdPoint;
            await _context.SaveChangesAsync();
            return new StudentPointTypeResult
            {
                Id = stpoint.Id,
                IdPoint = stpoint.IdPoint,
                IdTranscript = stpoint.IdTranscript
            };
        }
    }
}
