using Autofac;
using MealTime.API.Infrastructure.Repositories;
using MealTime.Models.Repository;

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

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<FoodRepository>()
                .As<IFoodRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<MealRepository>()
                .As<IMealRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<WeeklyMenuRepository>()
                .As<IWeeklyMenuRepository>()
                .InstancePerLifetimeScope();

        }
    }
}
