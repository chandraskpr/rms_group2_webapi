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
                userResumeDomain = x.UserResumes.Select(a => new UserResumeDomain()
                {
                    UserResumeId = a.UserResumeId,
                    UserId = a.UserId,
                    ResumeId = a.ResumeId,
                }).ToList(),

                userNotificationDomain = x.UserNotifications.Select(b => new UserNotificationsData()
                {
                    NotificationId = b.NotificationId,
                    NotificationDescription = b.NotificationDescription,
                    NotificationState = b.NotificationState,
                    CreationDate = b.CreationDate,
                    UserId = b.UserId,
                }).ToList(),
            
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

            foreach(var record in userInfo.userResumeDomain)
            {
                user.UserResumes.Add(new UserResume()
                {
                    ResumeId = record.ResumeId,
                    UserId= record.UserId,
                    UserResumeId= record.UserResumeId,
                });
            }

            base.Create(user);
        }

        public void Delete(int UserId)
        {
            var user = this.entitySet
            .Include(x => x.UserResumes)
            .FirstOrDefault(x => x.UserId == UserId);
            base.Delete(user);

        }

        public void Update(int UserId, UserInfoData userInfo)
        {
            var user = base.SelectAll().FirstOrDefault(x => x.UserId == UserId);

            if (user != null)
            {
                user.UserName = userInfo.UserName;
                user.UserEmail = userInfo.UserEmail;
                user.UserRole = userInfo.UserRole;

                foreach (var record in userInfo.userResumeDomain)
                {
                    user.UserResumes.Add(new UserResume()
                    {
                        ResumeId = record.ResumeId,
                        UserId = record.UserId,
                        UserResumeId = record.UserResumeId,
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