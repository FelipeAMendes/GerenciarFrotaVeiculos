using System;

namespace ManageFleet.Infra.Extensions.Cache
{
    public class CacheStorage : ICacheStorage
    {
        public T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public void Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void Store(string key, object data, int minutes = 20)
        {
            throw new NotImplementedException();
        }
    }
}