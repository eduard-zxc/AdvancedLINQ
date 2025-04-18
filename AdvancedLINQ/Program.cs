namespace AdvancedLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Enumerable.Range(1, 10).ToList();
            List<string> words = new List<string> { "apple", "banana", "cherry", "date", "apple", "banana" };

            Console.WriteLine("=== Filtering ===");
            var evenNumbers = numbers.Where(n => n % 2 == 0);
            Console.WriteLine("Even: " + string.Join(", ", evenNumbers));

            Console.WriteLine("\n=== Projection ===");
            var squares = numbers.Select(n => n * n);
            Console.WriteLine("Squares: " + string.Join(", ", squares));

            Console.WriteLine("\n=== Sorting ===");
            var descending = numbers.OrderByDescending(n => n);
            Console.WriteLine("Descending: " + string.Join(", ", descending));

            Console.WriteLine("\n=== Grouping ===");
            var groupedWords = words.GroupBy(w => w);
            foreach (var group in groupedWords)
            {
                Console.WriteLine($"{group.Key}: {group.Count()} times");
            }

            Console.WriteLine("\n=== Joining ===");
            var people = new[]
            {
                new { Id = 1, Name = "Alice" },
                new { Id = 2, Name = "Bob" },
            };
            var scores = new[]
            {
                new { PersonId = 1, Score = 90 },
                new { PersonId = 2, Score = 85 },
            };
            var joinResult = people.Join(
            scores,
            p => p.Id,
            s => s.PersonId,
            (p, s) => new { p.Name, s.Score });
            foreach (var item in joinResult)
            {
                Console.WriteLine($"{item.Name} scored {item.Score}");
            }

            Console.WriteLine("\n=== Aggregation ===");
            Console.WriteLine("Sum: " + numbers.Sum());
            Console.WriteLine("Average: " + numbers.Average());

            Console.WriteLine("\n=== Quantifiers ===");
            Console.WriteLine("Any > 5? " + numbers.Any(n => n > 5));
            Console.WriteLine("All even? " + numbers.All(n => n % 2 == 0));

            Console.WriteLine("\n=== Element Operators ===");
            Console.WriteLine("First: " + numbers.First());
            Console.WriteLine("Last: " + numbers.Last());
            Console.WriteLine("Element at index 3: " + numbers.ElementAt(3));

            Console.WriteLine("\n=== Generation ===");
            var repeated = Enumerable.Repeat("hello", 3);
            Console.WriteLine("Repeated: " + string.Join(", ", repeated));

            Console.WriteLine("\n=== Set Operators ===");
            var distinctWords = words.Distinct();
            Console.WriteLine("Distinct words: " + string.Join(", ", distinctWords));
            var intersect = new[] { 1, 2, 3 }.Intersect(new[] { 2, 3, 4 });
            Console.WriteLine("Intersection: " + string.Join(", ", intersect));

            Console.WriteLine("\n=== Conversion ===");
            var array = numbers.ToArray();
            Console.WriteLine("ToArray: " + string.Join(", ", array));
            var dictionary = people.ToDictionary(p => p.Id, p => p.Name);
            Console.WriteLine("ToDictionary:");
            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }

            Console.WriteLine("\n=== Concatenation ===");
            var concatenated = numbers.Concat(new[] { 11, 12 });
            Console.WriteLine("Concatenated: " + string.Join(", ", concatenated));

            Console.WriteLine("\n=== Partitioning ===");
            var take5 = numbers.Take(5);
            Console.WriteLine("Take 5: " + string.Join(", ", take5));
            var skip5 = numbers.Skip(5);
            Console.WriteLine("Skip 5: " + string.Join(", ", skip5));
        }
    }
}
