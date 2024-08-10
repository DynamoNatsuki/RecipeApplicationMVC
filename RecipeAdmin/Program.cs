using Database;
using System.ComponentModel.DataAnnotations.Schema;

Console.WriteLine("Welcome to recipe admin");

Console.WriteLine("Create recipe");

Console.Write("Name: ");
string name = Console.ReadLine();

Console.Write("Summary: ");
string summary = Console.ReadLine();

Console.Write("Description: ");
string description = Console.ReadLine();

Console.Write("Image: ");
string image = Console.ReadLine();

Recipe newRecipe = new Recipe()
{
    Name = name,
    Summary = summary,
    Description = description,
    Image = image
};

Database.Database db = new Database.Database();

await db.SaveRecipe(newRecipe);

var recipes = await db.GetAllRecipes();

foreach (var recipe in recipes)
{
    Console.WriteLine(recipe.Name);
}