using RMS.Data;
using RmsWebApi.Data;
using RmsWebApi.RMS_DB;

namespace RmsWebApi.Repository.Interfaces
{
    public interface IUserRepository : IBaseRepository<UserInfo>
    {
        public List<UserInfoData> GetAll();

        public void Create(UserInfoData userInfo);

        public void Delete(int UserId);

        public void Update(int UserId, UserInfoData userInfo);
        public List<UserNotificationsData> GetNotifications();

        public List<UserNotificationsData> GetActiveNotification();

    }
}
