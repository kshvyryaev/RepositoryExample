namespace RepositoryExample.Base.Domain
{
    public interface IEntity<TIdentifier>
    {
        TIdentifier Id { get; set; }
    }
}
