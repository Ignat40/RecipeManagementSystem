using System.Data.SqlTypes;

namespace RecipeMS
{
    public class RecipeManager : IRecipe
    {
        private List<Recipe> recipes;
        private IRecipeStorage recipeStorage;

        public RecipeManager(IRecipeStorage storage)
        {
            recipes = new List<Recipe>();
            recipeStorage = storage;
        }

        public void AddRecipe(string title, List<string> ingredients, string instructions, Recipe.FoodCategory category)
        {
            Recipe newRecipe = new(title, ingredients, instructions, category);
            recipes.Add(newRecipe);

            recipeStorage.Save(recipes);
        }
        public void ViewRecipe()
        {

            if (recipes.Count == 0)
            {
                Console.WriteLine("No Recipes!");
                return;
            }
            else
            {
                recipes = recipeStorage.Load();
                Console.WriteLine("=============");
                Console.WriteLine("=  Recipes  =");
                Console.WriteLine("=============");

                foreach (var r in recipes)
                {
                    Console.WriteLine("---------------------------");
                    Console.WriteLine($"Title: {r.Title}");
                    Console.WriteLine($"Ingredients:");
                    foreach (var i in r.Ingredients)
                    {
                        Console.WriteLine($"- {i}");
                    }
                    Console.WriteLine($"Category: {r.Category}");
                    Console.WriteLine($"Instructions: {r.Instructions}");
                    Console.WriteLine("---------------------------");

                }
            }




        }
        public void UpdateRecipe()
        {

        }
        public void CategorizeRecipe()
        {

        }
    }
}