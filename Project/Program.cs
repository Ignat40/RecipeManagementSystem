using System;

namespace RecipeMS
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of RecipeManager with JsonRecipeStorage
            var recipeManager = new RecipeManager(new JsonRecipeStorage());

            // Add a test recipe
            recipeManager.AddRecipe();

            // Save recipes to the JSON file
            recipeManager.Save();

            // Load and display recipes
            recipeManager.Load();
            recipeManager.ViewRecipe();
        }
    }
}
