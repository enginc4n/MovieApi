using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<MovieManager>().As<IMovieService>();
    builder.RegisterType<EfMovieDal>().As<IMovieDal>();
  }
}
