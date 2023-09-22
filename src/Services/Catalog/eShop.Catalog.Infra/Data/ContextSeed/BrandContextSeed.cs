using eShop.Catalog.Core.Entities;
using MongoDB.Driver;
using System.Text.Json;

namespace eShop.Catalog.Infra.Data.ContextSeed
{
    public static class BrandContextSeed
    {
        public static void SeedData(IMongoCollection<ProductBrand> collection)
        {
            var brandsAlreadyExists = collection.Find(brand => true).Any();
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "SeedData", "brands.json");            
            if (!brandsAlreadyExists)
            {
                var brandsToDeserialize = File.ReadAllText(path);
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsToDeserialize);
                
                if(brands != null)
                    collection.InsertManyAsync(brands);
            }
        }
    }
}
