using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rms_web_api_group2.data;
using rms_web_api_group2.repository.Interface;

namespace rms_web_api_group2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationMasterController : ControllerBase
    {
        private readonly IDesignationMaster designationMasterRepository;
        public DesignationMasterController(IDesignationMaster designationMasterRepository)
        {
            this.designationMasterRepository = designationMasterRepository;
        }
       

        // GET: api/<DesignationMasterController>
        [HttpGet]
        public List<DesignationMasterDomain> Get()
        {
            return this.designationMasterRepository.GetAll();
        }
        [HttpGet]
        [Route("GetActiveDesignation")]
        public List<DesignationMasterDomain> GetActiveDesignation()
        {
            return this.designationMasterRepository.GetActiveDesignations();
        }
        // POST api/<RoleMasterController>
        [HttpPost]
        public int Post([FromBody] DesignationMasterDomain value)
        {
            return this.designationMasterRepository.Create(value);
        }
        // PUT api/<RoleMasterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] DesignationMasterDomain value)
        {
            this.designationMasterRepository.Update(id, value);
        }
        // DELETE api/<RoleMasterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.designationMasterRepository.Delete(id);
        }
    }
}
 
  
