using rms_web_api_group2.data.Resume;
using rms_web_api_group2.repository.Interface;

namespace rms_web_api_group2.repository
{
    public class ResumeRepository : BaseRepository<Resume>, IResumeRepository
    {
        public List<Resume> users;
        public ResumeRepository()
        {
            users = new List<Resume>();
        }

        public void GetResumeById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
