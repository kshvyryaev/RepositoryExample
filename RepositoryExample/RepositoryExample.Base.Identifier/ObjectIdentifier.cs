using MongoDB.Bson;

namespace RepositoryExample.Base.Identifier
{
    public struct ObjectIdentifier
    {
        public ObjectIdentifier(ObjectId id)
        {
            this.Id = id;
        }

        public ObjectIdentifier(string id)
        {
            this.Id = ObjectId.Parse(id);
        }

        public ObjectId Id { get; }

        public static ObjectIdentifier Empty => ObjectId.Empty;

        public override bool Equals(object obj)
        {
            if (obj is ObjectIdentifier objectIdentifier)
            {
                return objectIdentifier.Id.Equals(this.Id);
            }

            return false;
        }

        public bool Equals(ObjectId obj)
        {
            return this.Id.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override string ToString()
        {
            return this.Id.ToString();
        }

        public static ObjectIdentifier Parse(string id)
        {
            return new ObjectIdentifier(id);
        }

        public static bool TryParse(string str, out ObjectIdentifier outId)
        {
            if (ObjectId.TryParse(str, out var id))
            {
                outId = new ObjectIdentifier(id);
                return true;
            }

            outId = ObjectIdentifier.Empty;
            return false;
        }

        public static implicit operator ObjectId(ObjectIdentifier id)
        {
            return id.Id;
        }

        public static implicit operator ObjectIdentifier(ObjectId id)
        {
            return new ObjectIdentifier(id);
        }

        public static bool operator ==(ObjectIdentifier a, ObjectIdentifier b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(ObjectIdentifier a, ObjectIdentifier b)
        {
            return !(a == b);
        }

        public static ObjectIdentifier GenerateNewId()
        {
            return ObjectId.GenerateNewId();
        }
    }
}
