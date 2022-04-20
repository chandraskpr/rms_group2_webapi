using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RmsWebApi.Repository.Interfaces;
using System.Linq;
using RmsWebApi.Data;
using RmsWebApi.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RmsWebApi.Controllers
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
        public List<TechStackValueData> Get()
        {
            return this.valueRepository.GetAll();
        }
        [HttpGet]
        [Route("GetActiveTechs")]
        public List<TechStackValueData> GetActiveTechs()
        {
            return this.valueRepository.GetActiveTech();
        }
        [HttpGet("{isDeleted}")]
        public TechStackValueData Get(bool isDeleted)
        {
            return this.valueRepository.GetAll().FirstOrDefault(x => x.IsDeleted == isDeleted);
        }

       

        [HttpPost]
        public int Post([FromBody] TechStackValueData value)
        {
            return this.valueRepository.Create(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.valueRepository.Delete(id);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TechStackValueData value)
        {
            this.valueRepository.Update(id, value);
        }
    }
}
