using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;
using MongoDB.Bson;

namespace RepositoryExample.Domain.Helpers
{
    public static class ObjectIdParser
    {
        public static ObjectId ValidateAndParse(string id)
        {
            if (!ObjectId.TryParse(id, out var parsedId))
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
