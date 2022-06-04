
using rms_web_api_group2.data;
using rms_web_api_group2.data.Resume;
using rms_web_api_group2.RMSdb;

namespace rms_web_api_group2.repository.Interface
{
    public interface IResumeRepository:IBaseRepository<Resume>
     {
        List<ResumeDomain> SelectAll();

        public ResumeDomain Insert(ResumeDomain obj);
        public void Update(int id,ResumeDomain obj);
        public void Delete(int entity);
        public List<ResumeDomain> GetNonDraftResume();
        public List<ResumeDomain> GetResumeBySkills(int skillIds);
    }
}
