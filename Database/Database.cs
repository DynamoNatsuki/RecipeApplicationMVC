using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Database
    {
        private IMongoDatabase GetDB()
        {
            MongoClient client = new MongoClient();
            var db = client.GetDatabase("RecipesDB");
            return db;
        }

        public async Task SaveRecipe(Recipe recipe)
        {
            await GetDB().GetCollection<Recipe>("Recipes")
                .InsertOneAsync(recipe);
        }

        public async Task<List<Recipe>> GetAllRecipes()
        {
            var recipes = await GetDB().GetCollection<Recipe>("Recipes")
                .Find(r => true)
                .ToListAsync();

            return recipes;
        }

        public async Task<Recipe> GetRecipeById(string id)
        {
            ObjectId _id = new ObjectId(id);

            var recipe = await GetDB().GetCollection<Recipe>("Recipes")
                .Find(r => r.Id == _id)
                .SingleOrDefaultAsync();

            return recipe;
        }
    }
}
