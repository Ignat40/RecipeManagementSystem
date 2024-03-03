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

                if (string.IsNullOrWhiteSpace(json))
                {
                    Console.WriteLine("Error -> kurets.");
                    return new List<Recipe>();
                }

                List<Recipe>? recipes = JsonSerializer.Deserialize<List<Recipe>>(json);

                return recipes ?? new List<Recipe>(); // Return an empty list if recipes is null
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
                string serialized = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(@"recipes.json", serialized);
                Console.WriteLine("Data Saved To Json!");


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error -> {ex.Message}");
            }


        }
    }
}