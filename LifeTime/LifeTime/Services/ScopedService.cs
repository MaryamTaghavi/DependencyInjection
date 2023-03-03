namespace DependencyInjectionLifeTime.Services
{
    public class ScopedService
    {
        private readonly string guid;

        public ScopedService()
        {
            guid = Guid.NewGuid().ToString();
        }

        public string GetGuid()
        {
            return guid;
        }
    }
}
