using Catalog.API.Entities;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> ProductCollection)
        {
            bool exitProduct = ProductCollection.Find(p => true).Any();

            if (!exitProduct)
            {
                ProductCollection.InsertManyAsync(GetPreConfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreConfiguredProducts()
        {
            throw new NotImplementedException();
        }
    }
}
