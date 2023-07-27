using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace eShop.Catalog.Core.Entities
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public  string Id { get; set; }
    }
}
