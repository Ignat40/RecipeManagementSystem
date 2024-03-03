namespace RecipeMS
{
    public class Program
    {
        public static void Main()
        {
            IRecipeStorage recipeStorage = new JsonRecipeStorage();
            RecipeManager recipeManager = new RecipeManager(recipeStorage);

            recipeManager.AddRecipe("musaka", new List<string> { "potetoes", "minced meat", "yogurt", "veggies", "flour" }, "blah blah blah", Recipe.FoodCategory.Mediterranean);

            recipeManager.ViewRecipe();


        }
    }
}