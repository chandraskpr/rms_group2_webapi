using RmsWebApi.Data;
using RmsWebApi.RMS_DB;

namespace RmsWebApi.Repository.Interfaces
{
    public interface IProjectMaster :IBaseRepository<ProjectMaster>
    {
        public List<ProjectMasterData> GetAll();

        public int Create(ProjectMasterData projct);

        public void Delete(int projectId);
        public List<ProjectMasterData> GetActiveProject();

        public void Update(int projectId, ProjectMasterData project);
    }
}
