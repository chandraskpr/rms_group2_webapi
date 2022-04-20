using RmsWebApi.Data;
using RmsWebApi.RMS_DB;

namespace RmsWebApi.Repository.Interfaces
{
    public interface IRoleMaster :IBaseRepository<RoleMaster>
    {
        public List<RoleMasterData> GetAll();

        public int Create(RoleMasterData role);

        public void Delete(int roleId);
        public List<RoleMasterData> GetActiveRole();
        public void Update(int roleId, RoleMasterData role);
    }
}
