using StructureMap;
using System.Web.Http;
using DataModels.unitofwork;

namespace webapi.config.DependencyInjection
{
    public static class StructureDIResolver
    {
        public static void RegisterDependencyResolver(HttpConfiguration config)
        {
            IContainer container = new Container(c =>
            {
                c.For<UnitOfWork>().Singleton().Use<UnitOfWork>();
                //c.For(typeof(ITreeRepository<>)).Use(typeof(TreeRepository<>)).Ctor<ISession>("session").Is(SessionManager.GetCurrentSession());
                //c.For(typeof(IRepository<>)).Use(typeof(Repository<>)).Ctor<ISession>("uow").Is(SessionManager.GetCurrentSession());
                //c.For(typeof(ICategoryRepository)).Use(typeof(CategoryRepository)).Ctor<ISession>("session").Is(SessionManager.GetCurrentSession());
                //c.For(typeof(IContractorRepository)).Use(typeof(ContractorRepository)).Ctor<ISession>("session").Is(SessionManager.GetCurrentSession());
                //c.For(typeof(IGoodsCategoryRepository)).Use(typeof(GoodsCategoryRepository)).Ctor<ISession>("session").Is(SessionManager.GetCurrentSession());
                //c.For(typeof(IProjectRootRepository)).Use(typeof(ProjectRootRepository)).Ctor<ISession>("session").Is(SessionManager.GetCurrentSession());
                //c.For(typeof(IHopDongRepository)).Use(typeof(HopDongRepository)).Ctor<ISession>("session").Is(SessionManager.GetCurrentSession());
                //c.For(typeof(IUserRepository)).Use(typeof(UserRepository)).Ctor<ISession>("session").Is(SessionManager.GetCurrentSession());
                
                c.Scan(scanner =>
                 {
                     //scanner.TheCallingAssembly();
                     //scanner.AssemblyContainingType(typeof(IUnitOfWork));
                     scanner.Assembly("webapi");
                     scanner.Assembly("DataModels");
                     scanner.Assembly("BusinessServices");
                     //scanner.Assembly("gtel.a77pms.tests");
                     //scanner.AddAllTypesOf(typeof(IRepository<>));
                     //scanner.AddAllTypesOf(typeof(ITreeRepository<>));
                     scanner.WithDefaultConventions();
                 });
               // c.For<ISessionFactory>().Singleton().Use(SessionFactoryManager.GetSessionFactory());
                //c.For<IUnitOfWork>()
                    //.LifecycleIs(new HttpContextLifecycle())
                   // .Use<UnitOfWork>();
            });
            config.DependencyResolver = new StructureMapContainer(container);
        }
    }
}