using rms_web_api_group2.data;
using rms_web_api_group2.RMSdb;

namespace rms_web_api_group2.repository.Interface
{
    public interface ITechStackMaster : IBaseRepository<TechStackMaster>
    {
        public List<TechStackMasterDomain> GetAll();
    }
}
