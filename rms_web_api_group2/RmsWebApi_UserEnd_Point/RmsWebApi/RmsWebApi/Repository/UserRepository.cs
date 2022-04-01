
using RmsWebApi.Data;
using RmsWebApi.Repository.Interfaces;

namespace RmsWebApi.Repository
{
    public class UserRepository : BaseRepository<UserInfo> ,IUserRepository
    {

        public List<UserInfo> users;

        public UserRepository()
        {
            users = new List<UserInfo>();
            
        }

        void Create(UserInfo user)
        {
            this.users.Add(user);
        }

        void Delete(UserInfo user)
        {
            this.users.Remove(user);
        }

        void Update(UserInfo user)
        {
            var editable = this.users.FirstOrDefault(x=> x.Name == user.Name);
            if(editable != null)
            {
                editable.Name = user.Name;
                editable.Email = user.Email;
                editable.Role = user.Role;
            }
        }

        List<UserInfo> SelectAll()
        {
            return this.users;
        }
    }






}
