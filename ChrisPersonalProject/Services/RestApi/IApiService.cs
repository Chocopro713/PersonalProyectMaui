namespace ChrisPersonalProject.Services.RestApi;
using Fusillade;
public interface IApiService<T>
{
    T GetApi(Priority priority);
}
