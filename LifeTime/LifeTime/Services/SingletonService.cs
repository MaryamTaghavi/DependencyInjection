namespace DependencyInjectionLifeTime.Services
{
    public class SingletonService
    {
        private readonly string guid;

        public SingletonService()
        {
            guid = Guid.NewGuid().ToString();
        }

        public string GetGuid()
        {
            return guid;
        }
    }
}
