using rms_web_api_group2.repository.Interface;

namespace rms_web_api_group2.repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected List<T> _list;

        public void Delete(object id)
        {
           this._list.Remove((T)id);
        }

        public List<T> GetAll()
        {
           return _list;
        }

        public T GetById(object id)
        {
           return  _list;
        }

        public void Insert(T obj)
        {
            this._list.Add(obj);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
    
}
