using ChrisPersonalProject.Models;
using Refit;

namespace ChrisPersonalProject.Services.RestApi;

public interface IEndPoints
{
    [Get("/todos")]
    Task<HttpResponseMessage> ListUsers();
    // Task<ApiResponse<List<UserModel>>> ListUsers();
}
