﻿using rms_web_api_group2.data;
using rms_web_api_group2.repository.Interface;
using rms_web_api_group2.RMSdb;

namespace rms_web_api_group2.repository
{

    public class TechStackValueRepository : BaseRepository<TechStackValue>, ITechStackValue
    {
        public TechStackValueRepository(RMSContext context) : base(context)
        {

        }
        public List<TechStackValueDomain> GetAll()
        {
            var project = base.SelectAll().Select(x => new TechStackValueDomain()
            {
                ValueId = x.ValueId,
                ValueName = x.ValueName,
                TechStackId = x.TechStackId,
                IsDeleted = x.IsDeleted,
            }).ToList();
            return project;

        }

        public List<TechStackValueDomain> GetActiveTech()
        {
            var result = base.SelectAll().Where(x => !x.IsDeleted).Select(x => new TechStackValueDomain()
            {
                TechStackId = x.TechStackId,
                ValueId = x.ValueId,
                ValueName = x.ValueName,
                IsDeleted = x.IsDeleted,
            }).ToList();
            return result;
        }
        public int Create(TechStackValueDomain TValue)
        {
            var res = new TechStackValue()
            {
                ValueId = TValue.ValueId,
                ValueName = TValue.ValueName,
                TechStackId = TValue.TechStackId,
                IsDeleted = TValue.IsDeleted,

            };
            var response = base.Insert(res);
            return response.ValueId;

        }

        public void Delete(int TechId)
        {
            var res = this.entitySet.FirstOrDefault(x => x.ValueId == TechId);
            if (res != null)
                base.Delete(res);
        }

        public void Update(int TechId, TechStackValueDomain TValue)
        {
            var res = base.SelectAll().FirstOrDefault(x => x.ValueId == TechId);
            if (res != null)
            {

                res.ValueName = TValue.ValueName;
                res.TechStackId = TValue.TechStackId;
                res.IsDeleted = TValue.IsDeleted;
            }
            base.Update(res);
        }
    }
}
