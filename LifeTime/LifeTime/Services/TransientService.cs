namespace DependencyInjectionLifeTime.Services
{
    public class TransientService
    {
        private readonly string guid;

        public TransientService()
        {
            guid = Guid.NewGuid().ToString();
        }

        public string GetGuid()
        {
            return guid;
        }
    }
}
