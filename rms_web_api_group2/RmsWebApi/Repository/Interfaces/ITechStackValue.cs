using RmsWebApi.Data;
using RmsWebApi.RMS_DB;
namespace RmsWebApi.Repository.Interfaces
{
    public interface ITechStackValue:IBaseRepository<TechStackValue>
    {
        public List<TechStackValueData> GetAll();

        public int Create(TechStackValueData TValue);

        public void Delete(int TechId);
        public List<TechStackValueData> GetActiveTech();

       
        public void Update(int TechId, TechStackValueData TValue);
    }
}
