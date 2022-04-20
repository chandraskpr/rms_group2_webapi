using rms_web_api_group2.data;
using rms_web_api_group2.repository.Interface;
using rms_web_api_group2.RMSdb;

namespace rms_web_api_group2.repository
{
   
    public class TechStackMasterRepository : BaseRepository<TechStackMaster>, ITechStackMaster
    {
        public TechStackMasterRepository(RMSContext context) : base(context)
        { }

        public List<TechStackMasterDomain> GetAll()
        {
            var records = base.SelectAll().Select(x => new TechStackMasterDomain()
            {
                TechStackId = x.TechStackId,
                Category = x.Category,
            }).ToList();
            return records;
        }
    }
}
