using System;
using System.Threading.Tasks;

namespace RegistrationConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Registration Console App!");
            Console.Write("Please enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Please enter your email address: ");
            string email = Console.ReadLine();

            RegisterUser(name, email);

            Console.WriteLine("Thanks for registering!");
            Console.ReadKey();
        }

        static async void RegisterUser(string name, string email)
        {
            // Synchronous approach
            SendEmail(email);
            AddToMarketingGroup(email);
            AddToCustomerCareGroup(name, email);

            //// Asynchronous approach
            await Task.Run(() => SendEmail(email));
            await Task.Run(() => AddToMarketingGroup(email));
            await Task.Run(() => AddToCustomerCareGroup(name, email));

            //parallel Asynchronous approach

            var sendEmailTask = Task.Run(() => SendEmail(email));
            var addToMarketingGroupTask = Task.Run(() => AddToMarketingGroup(email));
            var addToCustomerCareGroupTask = Task.Run(() => AddToCustomerCareGroup(name, email));

            // Wait for all tasks to complete
            await Task.WhenAll(sendEmailTask, addToMarketingGroupTask, addToCustomerCareGroupTask);
            Console.WriteLine("All Task has been completed!");
        }

        static void SendEmail(string email)
        {
            Console.WriteLine($"Sending email to {email}...");
            Task.Delay(3000).Wait(); // Simulate a delay of 3 seconds
            Console.WriteLine($"Email sent to {email}!");
        }

        static void AddToMarketingGroup(string email)
        {
            Console.WriteLine($"Adding {email} to the marketing group...");
            Task.Delay(2000).Wait(); // Simulate a delay of 2 seconds
            Console.WriteLine($"{email} added to the marketing group!");
        }

        static void AddToCustomerCareGroup(string name, string email)
        {
            Console.WriteLine($"Adding {name} ({email}) to the customer care group...");
            Task.Delay(1000).Wait(); // Simulate a delay of 1 second
            Console.WriteLine($"{name} ({email}) added to the customer care group!");
        }
    }
}
