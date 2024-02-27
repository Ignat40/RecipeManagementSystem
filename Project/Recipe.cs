using System.Globalization;

namespace RecipeMS
{
    public class Recipe
    {
        public Guid RecipeID {get; set;} = Guid.NewGuid();
        public string? Title {get; set;}
        public List<string>? Ingredients {get; set;}
        public string? Instructions {get; set;}
        public string? Category {get; set;}

        public Recipe(string title, List<string> ingredients, string instructions, string category)
        {
            this.Title = title;
            this.Ingredients = ingredients;
            this.Instructions = instructions;
            this.Category = category;
        }

    }
}