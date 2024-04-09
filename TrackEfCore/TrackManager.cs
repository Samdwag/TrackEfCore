using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;

namespace TrackEfCore
{
    public static class TrackManager
    {
        public static async Task Run()
        {
            using (var context = new DbContext())
            {
                await context.Database.EnsureCreatedAsync();

                bool exit = false;
                while (!exit)
                {
                    Console.WriteLine("************************************************");
                    Console.WriteLine("TRACK AND FIELD RESULTS DATABASE");
                    Console.WriteLine("************************************************");
                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("1. Add a result");
                    Console.WriteLine("2. List results");
                    Console.WriteLine("3. Update a result");
                    Console.WriteLine("4. Remove a result");
                    Console.WriteLine("5. Remove all results");
                    Console.WriteLine("6. Exit");
                    Console.Write("Enter the number of your choice: ");

                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                await AddResult(context);
                                break;
                            case 2:
                                await ListResults(context);
                                break;
                            case 3:
                                await UpdateResult(context);
                                break;
                            case 4:
                                await RemoveResult(context);
                                break;
                            case 5:
                                await RemoveAllResults(context);
                                break;
                            case 6:
                                exit = true;
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Please enter a number from 1 to 6.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                }
            }
        }

        static async Task AddResult(DbContext context)
        {
            Console.WriteLine("Enter the event name:");
            string eventName = Console.ReadLine();

            Console.WriteLine("Enter the participant's name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the participant's gender:");
            string gender = Console.ReadLine();

            Console.WriteLine("Enter the result:");
            decimal result = Convert.ToDecimal(Console.ReadLine());

            var newResult = new TrackResult
            {
                Event = eventName,
                Name = name,
                Gender = gender,
                Result = result
            };

            context.TrackResults.Add(newResult);
            await context.SaveChangesAsync();
            Console.WriteLine("Result added successfully!");
        }

        static async Task ListResults(DbContext context)
        {
            var results = await context.TrackResults.ToListAsync();
            Console.WriteLine("ID\tEvent\t\t\tName\t\tGender\tResult");
            foreach (var result in results)
            {
                Console.WriteLine($"{result.Id}\t{result.Event}\t\t{result.Name}\t\t{result.Gender}\t{result.Result}");
            }
        }

        static async Task UpdateResult(DbContext context)
        {
            Console.WriteLine("Enter the ID of the result you want to update:");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var resultToUpdate = await context.TrackResults.FindAsync(id);
                if (resultToUpdate != null)
                {
                    Console.WriteLine("Enter the new event name:");
                    resultToUpdate.Event = Console.ReadLine();

                    Console.WriteLine("Enter the new participant's name:");
                    resultToUpdate.Name = Console.ReadLine();

                    Console.WriteLine("Enter the new participant's gender:");
                    resultToUpdate.Gender = Console.ReadLine();

                    Console.WriteLine("Enter the new result:");
                    resultToUpdate.Result = Convert.ToDecimal(Console.ReadLine());

                    await context.SaveChangesAsync();
                    Console.WriteLine("Result updated successfully!");
                }
                else
                {
                    Console.WriteLine("Result not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        static async Task RemoveResult(DbContext context)
        {
            Console.WriteLine("Enter the ID of the result you want to remove:");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var resultToRemove = await context.TrackResults.FindAsync(id);
                if (resultToRemove != null)
                {
                    context.TrackResults.Remove(resultToRemove);
                    await context.SaveChangesAsync();
                    Console.WriteLine("Result removed successfully!");
                }
                else
                {
                    Console.WriteLine("Result not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        static async Task RemoveAllResults(DbContext context)
        {
            context.TrackResults.RemoveRange(context.TrackResults);
            await context.SaveChangesAsync();
            Console.WriteLine("All results removed successfully!");
        }
    }
}
