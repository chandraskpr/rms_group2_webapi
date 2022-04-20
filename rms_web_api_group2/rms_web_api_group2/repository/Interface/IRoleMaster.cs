using rms_web_api_group2.data;
using rms_web_api_group2.RMSdb;

namespace rms_web_api_group2.repository.Interface
{
    public interface IRoleMaster : IBaseRepository<RoleMaster>
    {
        public List<RoleMasterDomain> GetAll();

        public int Create(RoleMasterDomain role);
        public void Delete(int roleId);
        public void Update(int roleId, RoleMasterDomain role);
    }
}

