using rms_web_api_group2.data;
using rms_web_api_group2.RMSdb;

namespace rms_web_api_group2.repository.Interface
{
   
        public interface ISkillMaster : IBaseRepository<SkillsMaster>
        {
            public List<SkillMasterDomain> GetAll();
            public int Create(SkillMasterDomain skills);
            public void Delete(int skillsId);

            public List<SkillMasterDomain> GetActiveSkills();
            public void Update(int skillsId, SkillMasterDomain skills);
        }
}
