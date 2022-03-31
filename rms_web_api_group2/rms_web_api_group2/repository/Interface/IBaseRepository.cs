using rms_web_api_group2.data;

namespace rms_web_api_group2.repository.Interface
{
    public interface IBaseRepository <T> where T: class

     {
        List<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(object id);
        void Save();
    }
}
