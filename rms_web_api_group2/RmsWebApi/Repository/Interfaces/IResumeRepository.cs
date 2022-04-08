using RmsWebApi.Data;
using RmsWebApi.RMS_DB;

namespace RmsWebApi.Repository.Interfaces
{
    public interface IResumeRepository : IBaseRepository<Resume>
    {
        public List<ResumeData> GetAll();

        public void Create(ResumeData resume);

        public void Delete(int ResumeId);

        public void Update(int ResumeId, ResumeData resume);
    }
}
