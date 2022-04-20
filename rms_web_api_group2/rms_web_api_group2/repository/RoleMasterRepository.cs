using Microsoft.EntityFrameworkCore;
using rms_web_api_group2.data;
using rms_web_api_group2.repository;
using rms_web_api_group2.repository.Interface;
using rms_web_api_group2.RMSdb;
namespace rms_web_api_group2.repository
{
    public class RoleMasterRepository : BaseRepository<RoleMaster>, IRoleMaster
    {
        public RoleMasterRepository(RMSContext context) : base(context)
        {
        }

        public List<RoleMasterDomain> GetAll()
        {
            var role = base.SelectAll().Select(x => new RoleMasterDomain()
            {
                RoleId = x.RoleId,
                RoleName = x.RoleName,
                RoleDescription = x.RoleDescription,
                IsDeleted = (bool)x.IsDeleted,
            }).ToList();
            return role;
        }
        public int Create(RoleMasterDomain role)
        {
            var res = new RoleMaster()
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                RoleDescription = role.RoleDescription,
                IsDeleted = role.IsDeleted,
            };
            var response = base.Insert(res);
            return response.RoleId;
        }

        public void Delete(int roleId)
        {
            var res = this.entitySet.FirstOrDefault(x => x.RoleId == roleId);
            if (res != null)
                base.Delete(res);
        }
        public void Update(int roleId, RoleMasterDomain role)
        {
            var res = base.SelectAll().FirstOrDefault(x => x.RoleId == roleId);
            if (res != null)
            {
               
                res.RoleName = role.RoleName;
                res.RoleDescription = role.RoleDescription;
                res.IsDeleted = role.IsDeleted;
            }
            base.Update(res);
        }
    }
}
