using RMS.Data;
using RmsWebApi.RMS_DB;
using System.ComponentModel.DataAnnotations;



namespace RmsWebApi.Data
{
    public class UserInfoData
    {
        public UserInfoData()
        {
            userResumeData = new List<UserResumeData>();
            userNotificationData = new List<UserNotificationsData>();
        }
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserRole { get; set; }
        [Required]
        public string UserEmail { get; set; }
        public List<UserResumeData> userResumeData { get; set; }
        public List<UserNotificationsData> userNotificationData { get; set; }
    }
}