using Microsoft.AspNetCore.Mvc;
using RmsWebApi.Data;
using RmsWebApi.Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RmsWebApi.Controllers
{
    [Route("Shubham/[controller]")]
    [ApiController]
    public class UserNotificationsController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public UserNotificationsController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        // GET: api/<UserNotificationsController>
        [HttpGet]
        public IEnumerable<UserNotificationsData> Get()
        {
            return this.userRepository.GetNotifications();
        }

        // GET api/<UserNotificationsController>/5
        [HttpGet("{status}")]
        public IEnumerable<UserNotificationsData> Get(string status)
        {
            return this.userRepository.GetActiveNotification();
        }

        // POST api/<UserNotificationsController>
        [HttpPost]
        public void Post([FromBody] UserNotificationsData value)
        {
        }

        // PUT api/<UserNotificationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserNotificationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
