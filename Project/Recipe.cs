using System.Globalization;

namespace RecipeMS
{
    public class Recipe
    {
        public Guid RecipeID { get; set; }
        public string? Title { get; set; }
        public List<string>? Ingredients { get; set; }
        public string? Instructions { get; set; }
        public FoodCategory? Category { get; set; }

        public Recipe(string title, List<string> ingredients, string instructions, FoodCategory category)
        {
            RecipeID = Guid.NewGuid();
            Title = title;
            Ingredients = ingredients;
            Instructions = instructions;
            Category = category;
        }

        public Recipe()
        {
            RecipeID = Guid.NewGuid();
        }

        public override string ToString()
        {
            string s = $"{Title}, {Category}";
            return s;
        }

        public enum FoodCategory
        {
            Vegan,
            Italian,
            Chinese,
            High_Protein,
            Low_Fat,
            Low_Carb,
            Mediterranean,
            Gluten_Free,
            Polish,
            Thai,
            Pork,
            Chicken,
            Eggs,
            Cake,
            Salad,
            Bread,
            Dessert
        }
    }
}
