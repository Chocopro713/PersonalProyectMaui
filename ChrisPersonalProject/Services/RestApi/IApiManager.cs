using ChrisPersonalProject.Models;
using ChrisPersonalProject.Models.Request;

namespace ChrisPersonalProject.Services.RestApi;

public interface IApiManager
{
    Task<HttpResponseMessage> ListUsers();
}
