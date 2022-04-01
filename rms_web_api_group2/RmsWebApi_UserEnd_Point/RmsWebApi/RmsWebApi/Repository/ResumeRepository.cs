
using RmsWebApi.Data;
using RmsWebApi.Repository.Interfaces;

namespace RmsWebApi.Repository
{
    public class ResumeRepository : BaseRepository<Resume>, IResumeRepository
    {
        public List<Resume> resume;

        public ResumeRepository()
        {
            resume = new List<Resume>();
        }

        public List<Resume> SelectAll()
        {
            return resume;
        }
        public void Create(Resume resume)
        {
            this.resume.Add(resume);
        }
        public void Delete(Resume resume)
        {
            this.resume.Remove(resume);
        }

        public void Update (Resume resume)
        {
            var editable = this.resume.FirstOrDefault(x=> x.Title == resume.Title );
            if (editable != null)
            {
                editable.Title = resume.Title;
                editable.Status = resume.Status;
                editable.CreationDate = resume.CreationDate;
                editable.UpdationDate = resume.UpdationDate;
            }
        }
    }
}
