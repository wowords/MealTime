using Autofac;

namespace MealTime.API.Infrastructure
{
    public class MealTimeApplicationModule : Autofac.Module
    {
        string QueriesConnectionString { get; }
        public MealTimeApplicationModule(string queriesConnectionString)
        {
            QueriesConnectionString = queriesConnectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {

            //Add queries

            //builder.Register(_ => new Queries(QueriesConnectionString))
            //     .As<IQueries>().InstancePerlifetimeScope();

            //Add repositories

            //builder.RegisterType<Repository>()
            //    .As<Irepository>()
            //    .InstancePerLifetimeScope();
        }
    }
}
