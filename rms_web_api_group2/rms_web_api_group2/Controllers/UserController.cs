using Microsoft.AspNetCore.Mvc;
using rms_web_api_group2.data;
using rms_web_api_group2.data.Resume;
using rms_web_api_group2.repository.Interface;
using rms_web_api_group2.RMSdb;




// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860



namespace rms_web_api_group2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;




        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }



        // GET: api/<UserController>
        [HttpGet]
        public List<UserData> Get()
        {
            return this.userRepository.SelectAll();
        }



        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public UserData Get(int id)
        {
            var res = this.userRepository.SelectAll().FirstOrDefault(x => x.UserId == id);
            if (res != null)
            {
                return res; 
            }
            return null;
        }



        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] UserData value)
        {
            this.userRepository.Insert(value);
        }



        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserData value)
        {
            this.userRepository.Update(id,value);
        }



        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.userRepository.Delete(id);
        }
        [HttpGet]
        [Route("GetComment/{UserId}")]
        public List<ReviewTableDomain> GetComment(int UserId)
        {
            return this.userRepository.GetComment(UserId);
        }

        [HttpPost]
        [Route("CreateComment")]
        public int CreateComment([FromBody] ReviewTableDomain review)
        {
            return this.userRepository.CreateComment(review);
        }

        [HttpPut]
        [Route("EditComment/{id}")]
        public void EditComment([FromBody] ReviewTableDomain review, int id)
        {
            this.userRepository.EditComment(review, id);
        }
    }
}
