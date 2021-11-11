using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.API
{
    public class EntityBase : IEntityBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
