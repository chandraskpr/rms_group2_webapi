using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rms_web_api_group2.data;
using rms_web_api_group2.repository.Interface;

namespace rms_web_api_group2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleMasterController : ControllerBase
    {
        private readonly IRoleMaster roleMasterRepository;
        public RoleMasterController(IRoleMaster roleMasterRepository)
        {
            this.roleMasterRepository = roleMasterRepository;
        }
        // GET: api/<RoleMasterController>
        [HttpGet]
        public List<RoleMasterDomain> Get()
        {
            return this.roleMasterRepository.GetAll();
        }
        [HttpGet]
        [Route("GetActiveRoles")]
        public List<RoleMasterDomain> GetActiveRoles()
        {
            return this.roleMasterRepository.GetActiveRole();
        }
        // POST api/<RoleMasterController>
        [HttpPost]
        public int Post([FromBody] RoleMasterDomain value)
        {
            return this.roleMasterRepository.Create(value);
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] RoleMasterDomain value)
        {
            this.roleMasterRepository.Update(id, value);
        }
        // DELETE api/<RoleMasterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.roleMasterRepository.Delete(id);
        }
    }
}
