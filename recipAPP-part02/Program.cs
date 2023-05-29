using System;
using System.Collections.Generic;

namespace RecipeManager
{
    class Recipe
    {
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public string Instructions { get; set; }

        public Recipe(string name, List<string> ingredients, string instructions)
        {
            Name = name;
            Ingredients = ingredients;
            Instructions = instructions;
        }
    }

    class RecipeManager
    {
        private List<Recipe> recipes;

        public RecipeManager()
        {
            recipes = new List<Recipe>();
        }

        public void AddRecipe()
        {
            Console.WriteLine("Enter recipe name:");
            string name = Console.ReadLine();

            List<string> ingredients = new List<string>();
            Console.WriteLine("Enter ingredients (one per line, leave blank to finish):");
            string ingredient = Console.ReadLine();
            while (!string.IsNullOrEmpty(ingredient))
            {
                ingredients.Add(ingredient);
                ingredient = Console.ReadLine();
            }

            Console.WriteLine("Enter instructions:");
            string instructions = Console.ReadLine();

            Recipe recipe = new Recipe(name, ingredients, instructions);
            recipes.Add(recipe);
            Console.WriteLine("Recipe added successfully!");
        }

        public void ViewRecipe(string name)
        {
            Recipe recipe = recipes.Find(r => r.Name.ToLower() == name.ToLower());
            if (recipe != null)
            {
                Console.WriteLine("Recipe: " + recipe.Name);
                Console.WriteLine("Ingredients:");
                foreach (string ingredient in recipe.Ingredients)
                {
                    Console.WriteLine("- " + ingredient);
                }
                Console.WriteLine("Instructions: " + recipe.Instructions);
            }
            else
            {
                Console.WriteLine("Recipe not found!");
            }
        }

        public void SearchRecipe(string keyword)
        {
            List<Recipe> matchedRecipes = recipes.FindAll(r => r.Name.ToLower().Contains(keyword.ToLower()));
            if (matchedRecipes.Count > 0)
            {
                Console.WriteLine("Matching recipes:");
                foreach (Recipe recipe in matchedRecipes)
                {
                    Console.WriteLine("- " + recipe.Name);
                }
            }
            else
            {
                Console.WriteLine("No matching recipes found!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RecipeManager recipeManager = new RecipeManager();

            while (true)
            {
                Console.WriteLine("==== Recipe Manager ====");
                Console.WriteLine("1. Add Recipe");
                Console.WriteLine("2. View Recipe");
                Console.WriteLine("3. Search Recipe");
                Console.WriteLine("4. Exit");
                Console.WriteLine("========================");
                Console.WriteLine("Enter your choice:");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            recipeManager.AddRecipe();
                            break;
                        case 2:
                            Console.WriteLine("Enter recipe name:");
                            string recipeName = Console.ReadLine();
                            recipeManager.ViewRecipe(recipeName);
                            break;
                        case 3:
                            Console.WriteLine("Enter keyword:");
                            string keyword = Console.ReadLine();
                            recipeManager.SearchRecipe(keyword);
                            break;
                        case 4:
                            Console.WriteLine("Goodbye!");
                            return;
                        default:
                            Console.WriteLine("Invalid choice! Try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice! Try again.");
                }

                Console.WriteLine();
            }
        }
    }
}