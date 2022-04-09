using RMS.Domain.ResumeDomain;
using rms_web_api_group2.data.User;

namespace rms_web_api_group2.data
{
    public class UserData
    {
        public UserData()
        {
            Usernotifications = new List<UserNotificationsData>();
            userResume = new List<UserResumeDomain>();
        }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public string UserEmail { get; set; }
        public List<UserNotificationsData> Usernotifications { get; set; }
        public List<UserResumeDomain> userResume { get; set; }


    }
}
