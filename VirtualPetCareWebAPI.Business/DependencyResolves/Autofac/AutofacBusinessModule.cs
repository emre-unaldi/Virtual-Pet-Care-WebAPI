using Autofac;
using Castle.DynamicProxy;
using VirtualPetCareWebAPI.Core.Utilities.Interceptors;
using VirtualPetCareWebAPI.Business.Abstracts;
using VirtualPetCareWebAPI.Business.Concretes;
using VirtualPetCareWebAPI.DataAccess.Abstracts;
using VirtualPetCareWebAPI.DataAccess.Concretes.EntityFramework;
using Autofac.Extras.DynamicProxy;

namespace VirtualPetCareWebAPI.Business.DependencyResolves.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            // User
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            // Pet
            builder.RegisterType<PetManager>().As<IPetService>().SingleInstance();
            builder.RegisterType<EfPetDal>().As<IPetDal>().SingleInstance();

            // Health Status
            builder.RegisterType<HealthStatusManager>().As<IHealthStatusService>().SingleInstance();
            builder.RegisterType<EfHealthStatusDal>().As<IHealthStatusDal>().SingleInstance();

            // Food
            builder.RegisterType<FoodManager>().As<IFoodService>().SingleInstance();
            builder.RegisterType<EfFoodDal>().As<IFoodDal>().SingleInstance();

            // Activity
            builder.RegisterType<ActivityManager>().As<IActivityService>().SingleInstance();
            builder.RegisterType<EfActivityDal>().As<IActivityDal>().SingleInstance();

            builder
                .RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                    {
                        Selector = new AspectInterceptorSelector()
                    }
                )
                .SingleInstance();
        }
    }
}
