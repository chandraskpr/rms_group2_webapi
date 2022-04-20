using RmsWebApi.Data;
using RmsWebApi.RMS_DB;

namespace RmsWebApi.Repository.Interfaces
{
    public interface ISkillsMaster : IBaseRepository<SkillsMaster>
    {
        public List<SkillsMasterData> GetAll();
        public int Create(SkillsMasterData skills);
        public void Delete(int skillsId);

        public List<SkillsMasterData> GetActiveSkills();
        public void Update(int skillsId, SkillsMasterData skills);
    }
}