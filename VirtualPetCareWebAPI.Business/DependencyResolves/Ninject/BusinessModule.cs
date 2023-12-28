using Microsoft.EntityFrameworkCore;
using Ninject.Modules;
using VirtualPetCareWebAPI.Business.Abstracts;
using VirtualPetCareWebAPI.Business.Concretes;
using VirtualPetCareWebAPI.Core.DataAccess.Abstracts;
using VirtualPetCareWebAPI.Core.DataAccess.Concretes.EntityFramework;
using VirtualPetCareWebAPI.DataAccess.Abstracts;
using VirtualPetCareWebAPI.DataAccess.Concretes.EntityFramework;

namespace VirtualPetCareWebAPI.Business.DependencyResolves.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();

            Bind<IPetService>().To<PetManager>().InSingletonScope();
            Bind<IPetDal>().To<EfPetDal>().InSingletonScope();

            Bind<IHealthStatusService>().To<HealthStatusManager>().InSingletonScope();
            Bind<IHealthStatusDal>().To<EfHealthStatusDal>().InSingletonScope();

            Bind<IFoodService>().To<FoodManager>().InSingletonScope();
            Bind<IFoodDal>().To<EfFoodDal>().InSingletonScope();

            Bind<IActivityService>().To<ActivityManager>().InSingletonScope();
            Bind<IActivityDal>().To<EfActivityDal>().InSingletonScope();

            Bind(typeof(IQueryableRepository<>)).To(typeof(EfQueryableRepository<>));
            Bind<DbContext>().To<PetCareDbContext>();
        }
    }
}
