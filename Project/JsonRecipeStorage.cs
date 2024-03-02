using System.Text.Json;

namespace RecipeMS
{
    public class JsonRecipeStorage : IRecipeStorage
    {
        public List<Recipe> Load()
        {
            try
            {
                string json = File.ReadAllText(@"recipes.json");
                List<Recipe>? recipes = JsonSerializer.Deserialize<List<Recipe>>(json);
                return recipes;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error -> {ex.Message}");
                return new List<Recipe>();
            }
        }

        public void Save(List<Recipe> list)
        {
            try
            {
                string serialized = JsonSerializer.Serialize(list, new JsonSerializerOptions {WriteIndented = true});
                File.WriteAllText(@"recipes.json", serialized);
                Console.WriteLine("Data Saved To Json!");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error -> {ex.Message}");
            }
            

        }
    }
}