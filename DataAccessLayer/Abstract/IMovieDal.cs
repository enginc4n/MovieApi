using Core.DataAccessLayer.Abstract;
using Entities.Concrete;

namespace DataAccessLayer.Abstract;

public interface IMovieDal : IEntityRepostitory<Movie>
{
}
