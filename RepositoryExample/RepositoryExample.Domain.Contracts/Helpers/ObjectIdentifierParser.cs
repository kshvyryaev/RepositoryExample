using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;
using RepositoryExample.Base.Identifier;

namespace RepositoryExample.Domain.Helpers
{
    public static class ObjectIdentifierParser
    {
        public static ObjectIdentifier ValidateAndParse(string id)
        {
            if (!ObjectIdentifier.TryParse(id, out var parsedId))
            {
                var failureList = new List<ValidationFailure>()
                {
                    new ValidationFailure(nameof(id), "Unable to parse", id)
                };

                throw new ValidationException(failureList);
            }

            return parsedId;
        }
    }
}
