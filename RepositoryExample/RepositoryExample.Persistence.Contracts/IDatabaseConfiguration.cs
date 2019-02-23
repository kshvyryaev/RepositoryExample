namespace RepositoryExample.Persistence
{
    public interface IDatabaseConfiguration
    {
        string ConnectionString { get; }

        string Database { get; }
    }
}
