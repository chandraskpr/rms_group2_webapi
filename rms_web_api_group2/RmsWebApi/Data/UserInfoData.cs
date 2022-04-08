using RMS.Data;
using System.ComponentModel.DataAnnotations;

namespace RmsWebApi.Data
{
    public class UserInfoData

    {
        public UserInfoData()
        {
            userResumeDomain = new List<UserResumeDomain>();

            userNotificationDomain = new List<UserNotificationsData>();
        }

        
        public int UserId { get; set; }
       
        public string UserName { get; set; }
        
        public string UserRole { get; set; }
       
        public string UserEmail { get; set; }

        public List<UserResumeDomain> userResumeDomain {get; set;}

        public List<UserNotificationsData> userNotificationDomain { get; set; }
    }
}
