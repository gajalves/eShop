using eShop.Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace eShop.Catalog.Infra.Data.ContextSeed
{
    public static class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> collection)
        {
            var productAlreadyExists = collection.Find(type => true).Any();
            var path = Path.Combine("Data", "SeedData", "products.json");

            if (!productAlreadyExists)
            {
                var productToDeserialize = File.ReadAllText(path);
                var products = JsonSerializer.Deserialize<List<Product>>(productToDeserialize);

                if (products != null)
                    collection.InsertManyAsync(products);
            }
        }
    }
}
