using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rms_web_api_group2.data;
using rms_web_api_group2.repository.Interface;

namespace rms_web_api_group2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechStackMasterController : ControllerBase
    {
        private readonly ITechStackMaster techRepository;

        public TechStackMasterController(ITechStackMaster techRepository)
        {
            this.techRepository = techRepository;
        }



        [HttpGet]
        public List<TechStackMasterDomain> Get()
        {
            return this.techRepository.GetAll();
        }
    }
}
