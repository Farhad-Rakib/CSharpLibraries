using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RefitExample.Interfaces;
using RefitExample.Models;

namespace Refit;
public class Program
{
    static async Task Main(string[] args)
    {
        using IHost host = Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
        {
            services
                .AddRefitClient<IUsersClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/"));
        }).Build();

        var usersClient = host.Services.GetRequiredService<IUsersClient>();

        //Get All user
        var users = await usersClient.GetAll();
        foreach (var usr in users)
        {
            Console.WriteLine(usr);
        }

        // create api end point test
        var user = new Users
        {
            Name = "John Doe",
            Email = "john.doe@test.com"
        };
        
        var userId = (await usersClient.CreateUser(user)).Id;
        Console.WriteLine($"User with Id: {userId} created");

        // Get a single User
        Console.WriteLine("User with Id  10 is : " +await usersClient.GetUser(10) );
    }
}
