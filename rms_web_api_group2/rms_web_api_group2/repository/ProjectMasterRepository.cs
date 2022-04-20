
using Microsoft.EntityFrameworkCore;
using rms_web_api_group2.data;
using rms_web_api_group2.repository.Interface;
using rms_web_api_group2.RMSdb;

namespace rms_web_api_group2.repository
{
    public class ProjectMasterRepository : BaseRepository<ProjectMaster>, IProjectMaster
    {
        public ProjectMasterRepository(RMSContext context) : base(context)
        {
        }
        public List<ProjectMasterDomain> GetAll()
        {
            var project = base.SelectAll().Select(x => new ProjectMasterDomain()
            {
                ProjectId = x.ProjectId,
                ProjectName = x.ProjectName,
                ProjectDescription = x.ProjectDescription,
            }).ToList();
            return project;
        }
        public int Create(ProjectMasterDomain project)
        {
            var res = new ProjectMaster()
            {
                ProjectId = project.ProjectId,
                ProjectName = project.ProjectName,
                ProjectDescription = project.ProjectDescription,
            };
            var response = base.Insert(res);
            return response.ProjectId;
        }
        public void Delete(int projId)
        {
            var res = this.entitySet.FirstOrDefault(x => x.ProjectId == projId);
            if (res != null)
                base.Delete(res);
        }
        public void Update(int projId, ProjectMasterDomain project)
        {
            var res = base.SelectAll().FirstOrDefault(x => x.ProjectId == projId);
            if (res != null)
            {
               
                res.ProjectName = project.ProjectName;
                res.ProjectDescription = project.ProjectDescription;
                res.IsDeleted = project.IsDeleted;
            }
            base.Update(res);
        }
    }
}
