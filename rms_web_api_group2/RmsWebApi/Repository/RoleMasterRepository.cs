﻿using Microsoft.EntityFrameworkCore;
using RmsWebApi.Data;
using RmsWebApi.Repository.Interfaces;
using RmsWebApi.RMS_DB;
namespace RmsWebApi.Repository
{
    public class RoleMasterRepository : BaseRepository<RoleMaster>, IRoleMaster
    {
        public RoleMasterRepository(RMSContext context) : base(context)
        {

        }

        public List<RoleMasterData> GetAll()
        {
            var role = base.SelectAll().Select(x => new RoleMasterData()
            {
                RoleId = x.RoleId,
                RoleName = x.RoleName,
                RoleDescription = x.RoleDescription,
                IsDeleted = x.IsDeleted,
            }).ToList();
            return role;

        }
        public List<RoleMasterData> GetActiveRole()
        {
            var result = base.SelectAll().Select(x => new RoleMasterData()
            {
                RoleId = x.RoleId,
                RoleDescription = x.RoleDescription,
                RoleName = x.RoleName,
            }).ToList();
            return result;
        }

        public int Create(RoleMasterData role)
        {
            var res = new RoleMaster()
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName,
                RoleDescription = role.RoleDescription,
                IsDeleted=role.IsDeleted,

            };
            var response = base.Create(res);
            return response.RoleId;

        }

        public void Delete(int roleId)
        {
            var res = this.entitySet.FirstOrDefault(x => x.RoleId == roleId);
            if (res != null)
                base.Delete(res);
        }

        public void Update(int roleId , RoleMasterData role)
        {
            var res = base.SelectAll().FirstOrDefault(x => x.RoleId == roleId);
            if(res != null)
            {
                res.RoleName = role.RoleName;
                res.RoleDescription = role.RoleDescription;
                res.IsDeleted = role.IsDeleted;
            }
            base.Update(res);
        }
    }
}