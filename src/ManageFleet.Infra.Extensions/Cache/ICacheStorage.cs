namespace ManageFleet.Infra.Extensions.Cache
{
    public interface ICacheStorage
    {
        void Store(string key, object data, int minutes = 20);

        void Remove(string key);

        T Get<T>(string key);
    }
}