namespace RecipeMS;

using System.Collections;
using System.Collections.Generic;
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
        WriteLine("Which recipe do you want to update?");

        ListRecipes();

        bool validInput = false;

        while (!validInput)
        {
            validInput = int.TryParse(Console.ReadLine(), out int recipeNum);

            if (validInput == false || recipeNum > Recipes.Count || recipeNum < 0)
            {
                WriteLine("Inavlid input, try again");
            }
            else
            {
                recipeNum = recipeNum - 1;
                Recipes[recipeNum].ToString();
                Recipes.RemoveAt(recipeNum);
            }
        }

        AddRecipe();
    }

    public void CategorizeRecipe()
    {
        WriteLine("Which Recipes of which category do you want to see?");
        ShowCategories();
        Recipe.FoodCategory filterCategory = GetFoodCategory();

        ListRecipes(GetRecipesByCategory(filterCategory));
    }

    private Recipe.FoodCategory GetFoodCategory()
    {

        ShowCategories();

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

    private void ListRecipes(List<Recipe> Recipes)
    {
        int i = 1;

        foreach (var recipe in Recipes)
        {
            WriteLine(i + ": " + recipe.Title);
        }
    }

    private void ShowCategories()
    {
        int i = 1;
        WriteLine("Choose a category from the following");
        foreach (string s in Enum.GetNames(typeof(Recipe.FoodCategory)))
        {
            WriteLine("{0}: {1}", i, s);
            i++;
        }
    }

    private List<Recipe> GetRecipesByCategory(Recipe.FoodCategory categoryR)
    {
        List<Recipe> recipesFiltered = new List<Recipe>();

        foreach (Recipe recipe in Recipes)
        {
            if (recipe.Category == categoryR)
            {
                recipesFiltered.Add(recipe);
            }
        }

        return recipesFiltered;
    }
}
