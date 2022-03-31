using rms_web_api_group2.data;
using rms_web_api_group2.repository.Interface;

namespace rms_web_api_group2.repository
{
    public class UserRepository : BaseRepository<UserData>, IUserRepository
    {
        public List<UserData> users;
        public UserRepository()
        {
            users = new List<UserData>();
        }

        public void GetUserNotification()
        {
            throw new NotImplementedException();
        }
    }
}
