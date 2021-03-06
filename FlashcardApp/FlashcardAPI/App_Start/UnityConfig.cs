using FlashcardAPI.Data;
using FlashcardAPI.Data.Repositories;
using FlashcardAPI.Data.Repositories.CardsetRepo;
using System.Data.Entity;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace FlashcardAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IFlashcardRepo, FlashcardRepo>();
            container.RegisterType<ICardsetRepo, CardsetRepo>();

            //container.RegisterType<DbContext, FlashcardDbContext>(new PerThreadLifetimeManager());
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}