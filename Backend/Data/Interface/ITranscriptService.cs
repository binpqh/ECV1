using Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface ITranscriptService
    {
        Task<TranscriptTypeResult> CreateTranscript(TranscriptTypeInput create);
        Task<TranscriptTypeResult> GetTranscriptId(int id);
        Task<TranscriptTypeResult> UpdateTranscript(int id, TranscriptTypeInput transcript);
        
    }
}
