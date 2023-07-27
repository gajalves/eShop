using MongoDB.Bson.Serialization.Attributes;

namespace eShop.Catalog.Core.Entities
{
    public class ProductType : BaseEntity
    {
        [BsonElement("Name")]
        public string Name { get; set; }
    }
}