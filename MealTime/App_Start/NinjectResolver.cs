using Ninject;
using System.Configuration;

namespace MealTime.App_Start
{
    public class NinjectResolver 
    {
        private readonly IKernel _kernel;

        public void Dispose()
        {

        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _kernel.GetAll(serviceType);
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }

        private void AddBindings()
        {
            //this._kernel.Bind<IService>()
            //    .To<Service>()
            //    .WithConstructorArgument("");
        }
    }
}
