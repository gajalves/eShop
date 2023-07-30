using eShop.Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace eShop.Catalog.Infra.Data.ContextSeed
{
    public static class TypeContextSeed
    {
        public static void SeedData(IMongoCollection<ProductType> collection)
        {
            var typeAlreadyExists = collection.Find(type => true).Any();
            var path = Path.Combine("Data", "SeedData", "types.json");

            if (!typeAlreadyExists)
            {
                var typesToDeserialize = File.ReadAllText(path);
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesToDeserialize);

                if (types != null)
                    collection.InsertManyAsync(types);
            }
        }
    }
}
