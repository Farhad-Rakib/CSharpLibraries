using Refit;
using RefitExample.Models;

namespace RefitExample.Interfaces
{
    interface IUsersClient
    {
        [Get("/users")]
        Task<IEnumerable<Users>> GetAll();

        [Get("/users/{id}")]
        Task<Users> GetUser(int id);

        [Post("/users")]
        Task<Users> CreateUser([Body] Users user);

        [Put("/users/{id}")]
        Task<Users> UpdateUser(int id, [Body] Users user);

        [Delete("/users/{id}")]
        Task DeleteUser(int id);
    }
}
