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
    public class TranscriptService : ITranscriptService
    {
        private readonly ECV1DevContext _context;
        public TranscriptService(ECV1DevContext context)
        {
            _context = context;
        }
        public async Task<TranscriptTypeResult> CreateTranscript(TranscriptTypeInput create)
        {
            var trans = new Transcript
            {
                IdClass = create.IdClass,
                IdTeacher = create.IdTeacher,
                IdStudent = create.IdStudent,
                Status = Defined.Enum.Status.Active,
                IdManager = create.IdManager,
                StatusPay = create.StatusPay,
                
            };
            await _context.Transcripts.AddAsync(trans);
            await _context.SaveChangesAsync();
            return new TranscriptTypeResult
            {
                Id = trans.Id,
                IdManager = trans.IdManager,
                IdStudent = trans.IdStudent,
                IdClass = trans.IdClass,
                IdTeacher = trans.IdTeacher,
                IdPoint = trans.IdPoint,
                StatusPay = trans.StatusPay,
            };
        }
        public async Task<TranscriptTypeResult> GetTranscriptId(int id)
        {
            var trans = await _context.Transcripts
                .Where(e => e.IdStudent == id && e.Status == Defined.Enum.Status.Active)
                .Select(e => new TranscriptTypeResult
                {
                    Id = e.Id,
                    IdClass = e.IdClass,
                    IdTeacher = e.IdTeacher,
                    IdManager = e.IdManager,
                    IdStudent = e.IdStudent,
                    IdPoint = e.IdPoint,
                    StatusPay = e.StatusPay,
                }).FirstOrDefaultAsync();
            if(trans == null)
            {
                throw new Exception("Không tìm thấy bảng điểm");
            }    
            return trans;
        }

        public async Task<TranscriptTypeResult> UpdateTranscript(int id, TranscriptTypeInput transcript)
        {
            var trans = await _context.Transcripts
                .Where(e => e.Id == id && e.Status == Status.Active)
                .FirstOrDefaultAsync();
            if(trans == null)
            {
                throw new Exception("Không tìm thấy bảng điểm");
            }
            trans.StatusPay = transcript.StatusPay ?? trans.StatusPay;
            trans.StudentPoints
            throw new NotImplementedException();
        }
    }
}
