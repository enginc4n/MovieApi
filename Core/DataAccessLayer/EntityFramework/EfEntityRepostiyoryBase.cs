using System.Linq.Expressions;
using Core.DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Core.DataAccessLayer.EntityFramework;

public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepostitory<TEntity>
  where TEntity : class, new()
  where TContext : DbContext, new()
{
  public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter, int pageSize = 20, int pageNumber = 1)
  {
    using (TContext context = new())
    {
      IQueryable<TEntity> query = context.Set<TEntity>();

      if (filter != null)
      {
        query = query.Where(filter);
      }

      // Calculate the number of items to skip
      int itemsToSkip = pageSize * (pageNumber - 1);

      List<TEntity> entities = query.Skip(itemsToSkip)
        .Take(pageSize)
        .AsNoTracking()
        .ToList();

      return entities;
    }
  }

  public TEntity Get(Expression<Func<TEntity, bool>> filter)
  {
    using (TContext context = new())
    {
      TEntity entity = context.Set<TEntity>()
        .SingleOrDefault(filter);
      if (entity == null)
      {
        throw new Exception($"Entity of type {typeof(TEntity).Name} not found.");
      }

      return entity;
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
