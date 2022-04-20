using rms_web_api_group2.data;
using rms_web_api_group2.RMSdb;

namespace rms_web_api_group2.repository.Interface
{
    public interface IDesignationMaster : IBaseRepository<DesignationMaster>
    {
        public List<DesignationMasterDomain> GetAll();
        public int Create(DesignationMasterDomain designation);
        public void Delete(int degId);
        public void Update(int degId, DesignationMasterDomain designation);
    }
}

