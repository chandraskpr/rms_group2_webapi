using Microsoft.AspNetCore.Mvc;
using RmsWebApi.Data;
using RmsWebApi.Repository.Interfaces;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860



namespace RmsWebApi.Controllers
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
        public List<UserInfoData> Get()
        {
            return this.userRepository.GetAll();
        }



        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public UserInfoData Get(int id)
        {
            return this.userRepository.GetAll().FirstOrDefault(x => x.UserId == id);
        }



        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] UserInfoData value)
        {
            this.userRepository.Create(value);
        }



        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserInfoData value)
        {
            this.userRepository.Update(id, value);
        }



        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.userRepository.Delete(id);
        }

        [HttpGet]
        [Route("GetComment/{UserId}")]
        public List<ReviewTableData> GetComment(int UserId)
        {
            return this.userRepository.GetComment(UserId);
        }

        [HttpPost]
        [Route("CreateComment")]
        public int CreateComment([FromBody] ReviewTableData review)
        {
            return this.userRepository.CreateComment(review);
        }

        [HttpPut]
        [Route("EditComment/{id}")]
        public void EditComment([FromBody] ReviewTableData review, int id)
        {
            this.userRepository.EditComment(review, id);
        }
    }
}