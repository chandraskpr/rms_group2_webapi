using rms_web_api_group2.data;
using rms_web_api_group2.RMSdb;

namespace rms_web_api_group2.repository.Interface
{
    public interface ITechStackValue : IBaseRepository<TechStackValue>
    {
        public List<TechStackValueDomain> GetAll();

        public int Create(TechStackValueDomain TValue);

        public void Delete(int TechId);

        public List<TechStackValueDomain> GetActiveTech();
        public void Update(int TechId, TechStackValueDomain TValue);
    }

}
