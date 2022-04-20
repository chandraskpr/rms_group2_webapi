using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rms_web_api_group2.data;
using rms_web_api_group2.repository.Interface;

namespace rms_web_api_group2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechStackValuesController : ControllerBase
    {
        private readonly ITechStackValue valueRepository;

        public TechStackValuesController(ITechStackValue valueRepository)
        {
            this.valueRepository = valueRepository;
        }

        [HttpGet]
        public List<TechStackValueDomain> Get()
        {
            return this.valueRepository.GetAll();
        }

        [HttpGet]
        [Route("GetActiveTechs")]
        public List<TechStackValueDomain> GetActiveTechs()
        {
            return this.valueRepository.GetActiveTech();
        }

        [HttpGet("{isDeleted}")]
        public TechStackValueDomain Get(bool isDeleted)
        {
            return this.valueRepository.GetAll().FirstOrDefault(x => x.IsDeleted == isDeleted);
        }

        [HttpPost]
        public int Post([FromBody] TechStackValueDomain value)
        {
            return this.valueRepository.Create(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.valueRepository.Delete(id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TechStackValueDomain value)
        {
            this.valueRepository.Update(id, value);
        }
    }
}
