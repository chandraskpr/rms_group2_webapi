using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RmsWebApi.Repository.Interfaces;
using System.Linq;
using RmsWebApi.Data;
using RmsWebApi.Repository;
using RMS.Data.ResumeData;




namespace RmsWebApi.Controllers.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumeController : ControllerBase
    {
        private readonly IResumeRepository resumeRepository;

        public ResumeController(IResumeRepository resumeRepository)
        {
            this.resumeRepository = resumeRepository;
        }

        [HttpGet]
        public List<ResumeData> Get()
        {
            return this.resumeRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ResumeData Get(int id)
        {
            return this.resumeRepository.GetAll().FirstOrDefault(x => x.ResumeId == id);
        }
        [HttpGet]
        [Route("GetNonDraftResume")]
        public List<ResumeData> GetNonDraftResume()
        {
            return this.resumeRepository.GetNonDraftResume();
        }

       

        [HttpPost]
        public ResumeData Post([FromBody] ResumeData value)
        {
            return this.resumeRepository.Create(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.resumeRepository.Delete(id);
        }

        [HttpPut("{id}")]
        public void Update(int id, ResumeData resume)
        {
            this.resumeRepository.Update(id, resume);
        }
        [HttpGet]
        [Route("GetResumeBySkills/{skillIds}")]
        public List<ResumeData> GetResumeBySkills(int skillIds)
        {
            return this.resumeRepository.GetResumeBySkills(skillIds);

        }
    }
}