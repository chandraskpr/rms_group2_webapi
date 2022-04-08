using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RmsWebApi.Repository.Interfaces;
using System.Linq;
using RmsWebApi.Data;
using RmsWebApi.Repository;

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

        [HttpPost]
        public void Post([FromBody] ResumeData value)
        {
            this.resumeRepository.Create(value);
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
    }
}