using System.Globalization;

namespace RecipeMS
{
    public class Recipe
    {
        public Guid RecipeID = Guid.NewGuid();
        public string? Title { get; set; }
        public List<string>? Ingredients { get; set; }
        public string? Instructions { get; set; }
        public FoodCategory? Category { get; set; }

        public Recipe(string title, List<string> ingredients, string instructions, FoodCategory category)
        {
            Title = title;
            Ingredients = ingredients;
            Instructions = instructions;
            Category = category;
        }

        public override string ToString()
        {
            string ingredientsString = string.Join(",", Ingredients);

            string s = $"Titile: {Title}\nIngredients: {ingredientsString}\nInstructions: {Instructions}\nCategory: {Category.ToString()}";
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
            Dessert,
            Blank
        }
    }
}
