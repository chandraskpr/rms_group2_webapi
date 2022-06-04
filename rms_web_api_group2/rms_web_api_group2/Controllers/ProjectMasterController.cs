using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rms_web_api_group2.data;
using rms_web_api_group2.repository.Interface;

namespace rms_web_api_group2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectMasterController : ControllerBase
    {
        private readonly IProjectMaster projectMasterRepository;
        public ProjectMasterController(IProjectMaster projectMasterRepository)
        {
            this.projectMasterRepository = projectMasterRepository;
        }
        // GET: api/<ProjectMasterController>
        [HttpGet]
        public List<ProjectMasterDomain> Get()
        {
            return this.projectMasterRepository.GetAll();
        }
        [HttpGet]
        [Route("GetActiveProjects")]
        public List<ProjectMasterDomain> GetActiveProjects()
        {
            return this.projectMasterRepository.GetActiveProject();
        }

        // POST api/<RoleMasterController>
        [HttpPost]
        public int Post([FromBody] ProjectMasterDomain value)
        {
            return this.projectMasterRepository.Create(value);
        }
        // PUT api/<RoleMasterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProjectMasterDomain value)
        {
            this.projectMasterRepository.Update(id, value);
        }
        // DELETE api/<RoleMasterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.projectMasterRepository.Delete(id);
        }
    }
}
    

