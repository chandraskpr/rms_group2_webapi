
using rms_web_api_group2.data;
using rms_web_api_group2.data.Resume;
using rms_web_api_group2.RMSdb;

namespace rms_web_api_group2.repository.Interface
{
    public interface IResumeRepository:IBaseRepository<Resume>
     {
        List<ResumeDomain> SelectAll();

        void Insert(ResumeDomain obj);
        void Update(int id,ResumeDomain obj);
        void Delete(int entity);
    }
}
