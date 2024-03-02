namespace RecipeMS
{
    interface IRecipe
    {
        public void AddRecipe(string title, List<string> ingredients, string instructions, Recipe.FoodCategory category);
        public void ViewRecipe();
        public void UpdateRecipe();
        public void CategorizeRecipe();
    }
}