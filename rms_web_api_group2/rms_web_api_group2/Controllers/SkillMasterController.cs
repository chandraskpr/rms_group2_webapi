using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rms_web_api_group2.data;
using rms_web_api_group2.repository.Interface;

namespace rms_web_api_group2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillMasterController : ControllerBase { 
    private readonly ISkillMaster skillMasterRepository;

    public SkillMasterController(ISkillMaster skillMasterRepository)
    {
        this.skillMasterRepository = skillMasterRepository;
    }

    // GET: api/<RoleMasterController>
    [HttpGet]
    public List<SkillMasterDomain> Get()
    {
        return this.skillMasterRepository.GetAll();
    }


    [HttpGet]
    [Route("GetActiveSkill")]
    public List<SkillMasterDomain> GetActiveSkill()
    {
        return this.skillMasterRepository.GetActiveSkills();
    }

    [HttpGet("{isDeleted}")]
    public SkillMasterDomain Get(bool isDeleted)
    {
        return this.skillMasterRepository.GetAll().FirstOrDefault(x => x.IsDeleted == isDeleted);
    }

    // POST api/<RoleMasterController>
    [HttpPost]
    public int Post([FromBody] SkillMasterDomain value)
    {
        return this.skillMasterRepository.Create(value);

    }

    // PUT api/<RoleMasterController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] SkillMasterDomain value)
    {
        this.skillMasterRepository.Update(id, value);
    }

    // DELETE api/<RoleMasterController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        this.skillMasterRepository.Delete(id);
    }
}
    }

