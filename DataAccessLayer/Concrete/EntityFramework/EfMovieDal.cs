using Core.DataAccessLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccessLayer.Concrete.EntityFramework;

public class EfMovieDal : EfEntityRepositoryBase<Movie, MovieApiContext>, IMovieDal
{
}
