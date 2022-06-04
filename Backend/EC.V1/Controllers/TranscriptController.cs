using Data.Interface;
using Data.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EC.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranscriptController : ControllerBase
    {
        private readonly ITranscriptService _transcriptservice;
        public TranscriptController(ITranscriptService transcriptService)
        {
            _transcriptservice = transcriptService;
        }
        [HttpPost]
        public async Task<TranscriptTypeResult> CreateTranscript(TranscriptTypeInput create)
        {
            return await _transcriptservice.CreateTranscript(create);
        }
        [HttpGet("{id:int}")]
        public async Task<TranscriptTypeResult> GetTranscriptId(int id)
        {
            return await _transcriptservice.GetTranscriptId(id);
        }
        [HttpPut("{id:int}")]
        public async Task<TranscriptTypeResult> UpdateTranscript(int id, TranscriptTypeInput transcript)
        {
            return await _transcriptservice.UpdateTranscript(id, transcript);
        }
    }
}
