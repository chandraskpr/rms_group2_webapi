using rms_web_api_group2.data;
using rms_web_api_group2.RMSdb;

namespace rms_web_api_group2.repository.Interface
{
    public interface IProjectMaster : IBaseRepository<ProjectMaster>
    {
        public List<ProjectMasterDomain> GetAll();
        public int Create(ProjectMasterDomain projct);
        public void Delete(int projectId);
        public void Update(int projectId, ProjectMasterDomain project);
    }
}

