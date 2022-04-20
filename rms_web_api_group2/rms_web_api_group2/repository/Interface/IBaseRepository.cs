using rms_web_api_group2.data;

namespace rms_web_api_group2.repository.Interface
{
    public interface IBaseRepository <T> where T: class

     {
        List<T> SelectAll();
       
        T Insert(T obj);
        void Update(T obj);
        void Delete(T entity);
       
    }
}
