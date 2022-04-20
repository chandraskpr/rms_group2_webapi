using RmsWebApi.Data;
using RmsWebApi.RMS_DB;
namespace RmsWebApi.Repository.Interfaces
{
    public interface IDesignationMaster : IBaseRepository<DesignationMaster>
    {
        public List<DesignationMasterData> GetAll();

        public int Create(DesignationMasterData designation);

        public void Delete(int degId);
        public List<DesignationMasterData> GetActiveDesignations();

        public void Update(int degId, DesignationMasterData designation);
    }
}
