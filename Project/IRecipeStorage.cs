namespace RecipeMS
{
    interface IRecipeStorage
    {
        List<Recipe> Load();
        void Save(List<Recipe> list);
    }

}