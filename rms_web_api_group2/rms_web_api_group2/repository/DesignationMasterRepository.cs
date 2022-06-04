﻿using Microsoft.EntityFrameworkCore;
using rms_web_api_group2.data;
using rms_web_api_group2.repository;
using rms_web_api_group2.repository.Interface;
using rms_web_api_group2.RMSdb;
namespace rms_web_api_group2.repository
{
    public class DesignationMasterRepository : BaseRepository<DesignationMaster>, IDesignationMaster
    {
        public DesignationMasterRepository(RMSContext context) : base(context)
        {
        }
        public List<DesignationMasterDomain> GetAll()
        {
            var designations = base.SelectAll().Select(x => new DesignationMasterDomain()
            {
                DesignationId = x.DesignationId,
                DesignationName = x.DesignationName,
                DesignationDescription = x.DesignationDescription,
                IsDeleted = (bool)x.IsDeleted,
            }).ToList();
            return designations;
        }
        public List<DesignationMasterDomain> GetActiveDesignations()
        {
            var result = base.SelectAll().Where(x => x.IsDeleted.HasValue && !x.IsDeleted.Value).Select(x => new DesignationMasterDomain()
            {
                DesignationId = x.DesignationId,
                DesignationName = x.DesignationName,
                DesignationDescription = x.DesignationDescription,
                IsDeleted = (bool)x.IsDeleted,
            }).ToList();
            return result;
        }
        public int Create(DesignationMasterDomain designation)
        {
            var res = new DesignationMaster()
            {
                DesignationId = designation.DesignationId,
                DesignationName = designation.DesignationName,
                DesignationDescription = designation.DesignationDescription,
                IsDeleted = designation.IsDeleted,
            };
            var response = base.Insert(res);
            return response.DesignationId;
        }
        public void Delete(int desId)
        {
            var res = this.entitySet.FirstOrDefault(x => x.DesignationId == desId);
            if (res != null)
                base.Delete(res);
        }
        public void Update(int desId, DesignationMasterDomain designation)
        {
            var res = base.SelectAll().FirstOrDefault(x => x.DesignationId == desId);
            if (res != null)
            {
              
                res.DesignationName = designation.DesignationName;
                res.DesignationDescription = designation.DesignationDescription;
                res.IsDeleted = designation.IsDeleted;
            }
            base.Update(res);
        }
    }
}