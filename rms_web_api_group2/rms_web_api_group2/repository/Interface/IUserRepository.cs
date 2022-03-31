using rms_web_api_group2.data;

namespace rms_web_api_group2.repository.Interface
{
    public interface IUserRepository:IBaseRepository<UserData>
     {
        void GetUserNotification();
    }
}
