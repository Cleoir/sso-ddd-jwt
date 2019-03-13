using SSO.CrossCutting.Factory;

namespace SSO.Domain.Services.Base
{
    public abstract class BaseService
    {
        public T GetInstance<T>()
        {
            return Factory.GetInstance<T>();
        }
    }
}
