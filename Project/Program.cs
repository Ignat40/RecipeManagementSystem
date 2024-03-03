using System;

namespace RecipeMS
{
    class Program
    {
        static void Main(string[] args)
        {
            var recipeManager = new RecipeManager(new JsonRecipeStorage());

            recipeManager.AddRecipe();

            recipeManager.Save();

            recipeManager.Load();
            recipeManager.ViewRecipe();
        }
    }
}
