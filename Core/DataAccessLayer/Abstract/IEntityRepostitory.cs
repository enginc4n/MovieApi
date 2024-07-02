using System.Linq.Expressions;

namespace Core.DataAccessLayer.Abstract;

public interface IEntityRepostitory<T>
{
  List<T> GetList(Expression<Func<T, bool>> filter=null, int pageSize = 20, int pageNumber = 1);
  T? Get(Expression<Func<T, bool>> filter);
  void Add(T entity);
  void Update(T entity);
  void Delete(T entity);
}
