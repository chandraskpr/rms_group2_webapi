using rms_web_api_group2.data;
using rms_web_api_group2.repository.Interface;
using rms_web_api_group2.RMSdb;

namespace rms_web_api_group2.repository
{
    public class SkillsMasterRepository : BaseRepository<SkillsMaster>, ISkillMaster
    {
        public SkillsMasterRepository(RMSContext context) : base(context)
        {
        }
        public List<SkillMasterDomain> GetAll()
        {
            var Skills = base.SelectAll().Select(x => new SkillMasterDomain()
            {
                SkillsId = x.SkillsId,
                SkillName = x.SkillName,
                SkillCategory = x.SkillCategory,
                IsDeleted = x.IsDeleted,
            }).ToList();
            return Skills;
        }

        public List<SkillMasterDomain> GetActiveSkills()
        {
            var result = base.SelectAll().Where(x => x.IsDeleted.HasValue && !x.IsDeleted.Value).Select(x => new SkillMasterDomain()
            {
                SkillsId = x.SkillsId,
                SkillName = x.SkillName,
                SkillCategory = x.SkillCategory,
                IsDeleted = x.IsDeleted,
            }).ToList();
            return result;
        }
        public int Create(SkillMasterDomain Skills)
        {
            var res = new SkillsMaster()
            {
                SkillsId = Skills.SkillsId,
                SkillName = Skills.SkillName,
                SkillCategory = Skills.SkillCategory,
                IsDeleted = Skills.IsDeleted,
            };
            var response = base.Insert(res);
            return response.SkillsId;
        }

        public void Delete(int SkillsId)
        {
            var res = this.entitySet.FirstOrDefault(x => x.SkillsId == SkillsId);
            if (res != null)
                base.Delete(res);
        }

        public void Update(int SkillsId, SkillMasterDomain Skills)
        {
            var res = base.SelectAll().FirstOrDefault(x => x.SkillsId == SkillsId);
            if (res != null)
            {
                //res.SkillsId = Skills.SkillsId;
                res.SkillName = Skills.SkillName;
                res.SkillCategory = Skills.SkillCategory;
                res.IsDeleted = Skills.IsDeleted;
            }
            base.Update(res);
        }
    }
}
   
