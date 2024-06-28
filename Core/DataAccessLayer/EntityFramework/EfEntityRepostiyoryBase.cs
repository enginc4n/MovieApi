using System.Linq.Expressions;
using Core.DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Core.DataAccessLayer.EntityFramework;

public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepostitory<TEntity>
  where TEntity : class, new()
  where TContext : DbContext, new()
{
  public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
  {
    using (TContext context = new())
    {
      return filter == null
        ? context.Set<TEntity>().ToList()
        : context.Set<TEntity>().Where(filter).ToList();
    }
  }

  public TEntity Get(Expression<Func<TEntity, bool>> filter)
  {
    using (TContext context = new())
    {
      return context.Set<TEntity>().SingleOrDefault(filter);
    }
  }

  public void Add(TEntity entity)
  {
    using (TContext context = new())
    {
      EntityEntry<TEntity> addedEntry = context.Entry(entity);
      addedEntry.State = EntityState.Added;
      context.SaveChanges();
    }
  }

  public void Update(TEntity entity)
  {
    using (TContext context = new())
    {
      EntityEntry<TEntity> updatedEntity = context.Entry(entity);
      updatedEntity.State = EntityState.Modified;
      context.SaveChanges();
    }
  }

  public void Delete(TEntity entity)
  {
    using (TContext context = new())
    {
      EntityEntry<TEntity> deletedEntity = context.Entry(entity);
      deletedEntity.State = EntityState.Deleted;
      context.SaveChanges();
    }
  }
}
