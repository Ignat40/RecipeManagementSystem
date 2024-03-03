namespace RecipeMS;

using static System.Console;

public class RecipeManager : IRecipe
{
    List<Recipe> Recipes = new();

    public void AddRecipe()
    {
        WriteLine("Input recipee name: ");
        string? name = ReadLine();

        WriteLine("Input ingredients for the recipe separated by a comma: ");
        string? ingredientsInput = ReadLine();
        List<string> ingredients = ingredientsInput.Split(",").ToList();

        WriteLine("Input instructions: ");
        string? instructions = ReadLine();

        Recipe.FoodCategory category = GetFoodCategory();

        Recipe recipe = new Recipe(name, ingredients, instructions, category);
        Recipes.Add(recipe);
        Console.WriteLine("Recipe added");
        WriteLine(recipe.ToString());
    }

    public void ViewRecipe()
    {
        WriteLine("Which recipee do you want to see? ");

        ListRecipes();

        bool validInput = false;

        while (!validInput)
        {
            validInput = int.TryParse(Console.ReadLine(), out int recipeNum);

            if (validInput == false || recipeNum > Recipes.Count || recipeNum < 0)
            {
                WriteLine("Inavlid input, try again");
            }

            if (validInput == true)
            {
                recipeNum = recipeNum - 1;
                WriteLine(Recipes[recipeNum].ToString());
            }
        }
    }

    public void UpdateRecipe()
    {
        WriteLine("Which recipee do you want to update?");

        ListRecipes();

    }
    public void CategorizeRecipe()
    {

    }

    private Recipe.FoodCategory GetFoodCategory()
    {
        int i = 1;
        WriteLine("Choose a category from the following");
        foreach (string s in Enum.GetNames(typeof(Recipe.FoodCategory)))
        {
            WriteLine("{0}: {1}", i, s);
            i++;
        }

        if (int.TryParse(Console.ReadLine(), out int categoryNum))
        {
            categoryNum = categoryNum - 1;
            if (Enum.IsDefined(typeof(Recipe.FoodCategory), categoryNum))
            {
                Recipe.FoodCategory myCategory = (Recipe.FoodCategory)categoryNum;
                return myCategory;
            }
        }
        return Recipe.FoodCategory.Blank;
    }

    private void ListRecipes()
    {
        int i = 1;

        foreach (var recipe in Recipes)
        {
            WriteLine(i + ": " + recipe.Title);
        }

    }
}
