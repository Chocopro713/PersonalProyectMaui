using Fusillade;
using ModernHttpClient;
using Refit;
using System.Net.Http.Headers;

namespace ChrisPersonalProject.Services.RestApi;

public class ApiService<T> : IApiService<T>
{
    Func<HttpMessageHandler, T> createClient;
    public ApiService(string apiBaseAddress)
    {
        createClient = messageHandler =>
        {
#if DEBUG
            // Cliente
            // var log = new HttpLoggingHandler(messageHandler);
            HttpClient client = new HttpClient(new HttpLoggingHandler(new HttpClientHandler()));
#else
            HttpClient client = new HttpClient();

#endif
            client.BaseAddress = new Uri(apiBaseAddress);

            // Add Token
            var login = GlobalSetting.GetInstance().Login;
            if (login != null)
            {
                var token = login.Token;
                if (!string.IsNullOrWhiteSpace(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            // Refit JSON Settings 
            var refitSettings = new RefitSettings(new NewtonsoftJsonContentSerializer());
            return RestService.For<T>(client, refitSettings);
        };
    }


    private T Background
    {
        get
        {
            return new Lazy<T>(() => createClient(
                new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.Background))).Value;
        }
    }

    private T UserInitiated
    {
        get
        {
            return new Lazy<T>(() => createClient(
                new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.UserInitiated))).Value;
        }
    }

    private T Speculative
    {
        get
        {
            return new Lazy<T>(() => createClient(
          new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.Speculative))).Value;
        }
    }

    public T GetApi(Priority priority)
    {
        switch (priority)
        {
            case Priority.Background:
                return Background;
            case Priority.UserInitiated:
                return UserInitiated;
            case Priority.Speculative:
                return Speculative;
            default:
                return UserInitiated;
        }
    }
}
