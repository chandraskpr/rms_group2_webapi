using Microsoft.AspNetCore.Mvc;
using rms_web_api_group2.data.Resume;
using rms_web_api_group2.repository.Interface;
using rms_web_api_group2.RMSdb;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rms_web_api_group2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumesController : ControllerBase
    {
        IResumeRepository resumerepository;
        public ResumesController(IResumeRepository resumerepository)
        {
            this.resumerepository = resumerepository;
        }
        // GET: api/<ResumesController>
        [HttpGet]
        public List<ResumeDomain> Get()
        {
            return this.resumerepository.SelectAll();
        }

        // GET api/<ResumesController>/5
        [HttpGet("{id}")]
        
        public ResumeDomain Get(int id)
        {
            var res = this.resumerepository.SelectAll().FirstOrDefault(x => x.ResumeId == id);
            if(res != null)
            {
                return res; 
            }
            return null;
        }

        // POST api/<ResumesController>
        [HttpPost]
        public ResumeDomain Post([FromBody] ResumeDomain value)
        {
            return this.resumerepository.Insert(value);
        }

        // PUT api/<ResumesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ResumeDomain value)
        {
            this.resumerepository.Update(id,value);
        }

        // DELETE api/<ResumesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.resumerepository.Delete(id);
        }
    }
}
