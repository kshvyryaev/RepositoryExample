namespace RepositoryExample.Domain.Commands.Entities
{
    public class UpdateEntityCommand
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
