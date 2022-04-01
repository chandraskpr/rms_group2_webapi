using RmsWebApi.Data;
using RmsWebApi.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace RmsWebApi.Repository
{
    public class BaseRepository<T>:IBaseRepository<T> where T:class
    { 
        protected List<T> _list;
        
       public  List<T> SelectAll<T>()
       {
             throw new NotImplementedException();
       }
       public void Create<T>(T entity) { 
            throw new NotImplementedException();
        }
       public void Update<T>(T entity) {
            throw new NotImplementedException();
        } 
       public void Delete<T>(T entity) { 
            throw new NotImplementedException();
        } 
        
    }
   
}
