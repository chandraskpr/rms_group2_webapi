using rms_web_api_group2.data;
using rms_web_api_group2.data.Resume;
using rms_web_api_group2.data.User;
using rms_web_api_group2.RMSdb;

namespace rms_web_api_group2.repository.Interface
{
    public interface IUserRepository:IBaseRepository<UserInfo>
     {
        //void GetUserNotification();
        List<UserData> SelectAll();

        void Insert(UserData obj);
        void Update(int id,UserData obj);
        void Delete(int entity);
        List<UserNotificationsData> GetNotifications();
        List<UserNotificationsData> GetActiveNotification();
        public int CreateComment(ReviewTableDomain review);

        public void EditComment(ReviewTableDomain review, int id);

        public List<ReviewTableDomain> GetComment(int userId);
    }
}
