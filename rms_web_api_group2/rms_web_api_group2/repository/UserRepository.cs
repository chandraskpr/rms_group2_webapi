using rms_web_api_group2.data;
using rms_web_api_group2.data.User;
using rms_web_api_group2.repository.Interface;
using rms_web_api_group2.RMSdb;

namespace rms_web_api_group2.repository
{
    public class UserRepository : BaseRepository<UserInfo>, IUserRepository
    {
        
        public UserRepository(RMSContext context):base(context)
        {
           
        }

        public new List<UserData> SelectAll()
        {
            var records = base.SelectAll().Select(x => new UserData()
            {
                UserId = x.UserId,
                UserName = x.UserName,
               UserEmail = x.UserEmail,
                UserRole = x.UserRole,
                
            }).ToList();
            return (records);
        }
        public void Insert(UserData userdata)
        {
            var res = new UserInfo()
            {
                UserId = userdata.UserId,
                UserName = userdata.UserName,
                UserEmail = userdata.UserEmail,
                UserRole = userdata.UserRole,


            }; 
        }
           
            public void Delete(int UserId)
            {
                var res = base.SelectAll().Find(e => e.UserId == UserId);
                if (res != null)
                {
                    base.Delete(res);
                }

            }
        public void Update(int UserId, UserData userdata)
        {
            var res = base.SelectAll().Find(e => e.UserId == UserId);
            if (res != null)
            {

                res.UserId = userdata.UserId;
                res.UserName = userdata.UserName;
                res.UserEmail = userdata.UserEmail;
                res.UserRole = userdata.UserRole;
            };
            base.Update(res);
        }
        public List<UserNotificationsData> GetNotifications()
        {
            var records = context.UserNotifications.Select(x => new UserNotificationsData()
            {
                NotificationId = x.NotificationId,
                UserId = x.UserId,
                NotificationDescription = x.NotificationDescription,
                CreationDate = x.CreationDate,
                NotificationState = x.NotificationState,

            }).ToList();
            return records;
        }

        public List<UserNotificationsData> GetActiveNotification()
        {
            var records = context.UserNotifications.Select(x => new UserNotificationsData()
            {
                NotificationId = x.NotificationId,
                UserId = x.UserId,
                NotificationDescription = x.NotificationDescription,
                CreationDate = x.CreationDate,
                NotificationState = x.NotificationState,

            }).Where(x => x.NotificationState == "Active").ToList();
            return records;
        }


    }
}
