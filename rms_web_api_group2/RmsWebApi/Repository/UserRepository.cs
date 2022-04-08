using Microsoft.EntityFrameworkCore;
using RMS.Data;
using RmsWebApi.Data;
using RmsWebApi.Repository.Interfaces;
using RmsWebApi.RMS_DB;


namespace RmsWebApi.Repository
{
    public class UserRepository : BaseRepository<UserInfo>, IUserRepository
    {

        public UserRepository(RMSContext context)
        : base(context)
        {

        }

        public List<UserInfoData> GetAll()
        {
            var records = base.SelectAll().Select(x => new UserInfoData()
            {
                UserId = x.UserId,
                UserName = x.UserName,
                UserEmail = x.UserEmail,
                UserRole = x.UserRole,

                userResumeData = x.UserResumes.Select(a => new UserResumeData()
                {
                    UserId = a.UserResumeId,
                    UserResumeId = a.UserResumeId,
                    ResumeId = a.ResumeId,
                }).ToList(),

                userNotificationData = x.UserNotifications.Select(n => new UserNotificationsData()
                {
                    UserId = n.UserId,
                    CreationDate = n.CreationDate,
                    NotificationDescription = n.NotificationDescription,
                    NotificationId = n.NotificationId,
                    NotificationState = n.NotificationState,
                }
                ).ToList(),

            }).ToList();
            return records;
        }

        public void Create(UserInfoData userInfo)
        {
            var user = new UserInfo()
            {
                UserName = userInfo.UserName,
                UserEmail = userInfo.UserEmail,
                UserRole = userInfo.UserRole,

            };
            foreach (var record in userInfo.userResumeData)
            {
                user.UserResumes.Add(new UserResume()
                {
                    UserResumeId = record.UserResumeId,
                    UserId = record.UserId,
                    ResumeId = record.ResumeId,

                });
            }

            foreach (var record in userInfo.userNotificationData)
            {
                user.UserNotifications.Add(new UserNotification()
                {
                    NotificationId = record.NotificationId,
                    CreationDate = record.CreationDate,
                    NotificationDescription = record.NotificationDescription,
                    NotificationState = record.NotificationState,
                    UserId = record.UserId,
                });

            }
            base.Create(user);

        }

        public void Delete(int UserId)
        {
            var res = this.entitySet
            .Include(x => x.UserResumes)
            .Include(y => y.UserNotifications)
            .FirstOrDefault(x => x.UserId == UserId);


            base.Delete(res);
        }

        public void Update(int UserId, UserInfoData userInfo)
        {
            var user = base.SelectAll().FirstOrDefault(x => x.UserId == UserId);

            if (user != null)
            {
                user.UserName = userInfo.UserName;
                user.UserEmail = userInfo.UserEmail;
                user.UserRole = userInfo.UserRole;

                foreach (var record in userInfo.userResumeData)
                {
                    user.UserResumes.Add(new UserResume()
                    {
                        UserResumeId = record.UserResumeId,
                        UserId = record.UserId,
                        ResumeId = record.ResumeId,

                    });
                }

                foreach (var record in userInfo.userNotificationData)
                {
                    user.UserNotifications.Add(new UserNotification()
                    {
                        NotificationId = record.NotificationId,
                        CreationDate = record.CreationDate,
                        NotificationDescription = record.NotificationDescription,
                        NotificationState = record.NotificationState,
                        UserId = record.UserId,
                    });

                }
                base.Update(user);

            }

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