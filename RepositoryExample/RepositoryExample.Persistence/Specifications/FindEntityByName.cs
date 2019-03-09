using System;
using System.Linq.Expressions;
using RepositoryExample.Base.Domain;
using RepositoryExample.Entities;

namespace RepositoryExample.Persistence.Specifications
{
    public class FindEntityByName : ISpecification<Entity>
    {
        private readonly string _name;

        public FindEntityByName(string name)
        {
            _name = name;
        }

        public Expression<Func<Entity, bool>> Predicate => e => e.Name == _name;
    }
}
