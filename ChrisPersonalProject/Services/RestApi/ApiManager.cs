using Fusillade;
using Polly;
using Refit;
using System.Net;
using NetworkAccess = Microsoft.Maui.Networking.NetworkAccess;

namespace ChrisPersonalProject.Services.RestApi;

public class ApiManager : IApiManager
{
    // IConnectivity _connectivity = CrossConnectivity.Current;
    // IUserDialogs _userDialogs = UserDialogs.Instance;
    NetworkAccess accessType = Connectivity.Current.NetworkAccess;

    IApiService<IEndPoints> endPointsApi;
    public bool IsConnected { get; set; }
    Dictionary<int, CancellationTokenSource> runningTasks = new Dictionary<int, CancellationTokenSource>();
    Dictionary<string, Task<HttpResponseMessage>> taskContainer = new Dictionary<string, Task<HttpResponseMessage>>();

    public ApiManager(IApiService<IEndPoints> endPoints)
    {
        endPointsApi = endPoints;
        // Connection to internet is available
        if (accessType != NetworkAccess.Internet)
            ClearAllRunningTask();
    }

    // private void OnConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    // {
    //     IsConnected = e.IsConnected;
    //     if (!e.IsConnected)
    //         ClearAllRunningTask();
    // }

    // Cancel All Running Task
    private void ClearAllRunningTask()
    {
        var items = runningTasks.ToList();
        foreach (var item in items)
        {
            item.Value.Cancel();
            runningTasks.Remove(item.Key);
        }
    }

    /*
     * CONSUMO REST API
     */

    /// SECURITY
    // public async Task<HttpResponseMessage> Login(LoginModelQuery login)
    // {
    //     var cts = new CancellationTokenSource();
    //     var task = RemoteRequestAsync<HttpResponseMessage>(endPointsApi.GetApi(Priority.UserInitiated).Login(login));
    //     runningTasks.Add(task.Id, cts);
    // 
    //     return await task;
    // }

    public async Task<HttpResponseMessage> ListUsers()
    {
        var cts = new CancellationTokenSource();
        var task = RemoteRequestAsync<HttpResponseMessage>(endPointsApi.GetApi(Priority.UserInitiated).ListUsers());
        runningTasks.Add(task.Id, cts);
    
        return await task;
    }

    /*
     * CONSUMO REST API
     */

    protected async Task<TData> RemoteRequestAsync<TData>(Task<TData> task)
        where TData : HttpResponseMessage,
        new()
    {
        TData data = new TData();

        if (accessType != NetworkAccess.Internet)
        {
            var strngResponse = "No hay una conexión de red";
            data.StatusCode = HttpStatusCode.BadRequest;
            data.Content = new StringContent(strngResponse);

            // _userDialogs.Toast(strngResponse, TimeSpan.FromSeconds(3));
            return data;
        }

        data = await Policy
            .Handle<WebException>()
            .Or<ApiException>()
            .Or<TaskCanceledException>()
            .WaitAndRetryAsync
            (
                retryCount: 1,
                sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
            )
            .ExecuteAsync(async () =>
            {
                var result = await task;

                //Logout the user
                if (result.StatusCode == HttpStatusCode.Unauthorized)
                {
                    ClearAllRunningTask();
                    // await _userDialogs.AlertAsync("No se pudo validar su sesión. Por favor, vuelva a ingresar sus credenciales de acceso.");
                    // MessagingCenter.Send<ApiManager>(this, MessagingKeys.ExpiredSession);
                }
                runningTasks.Remove(task.Id);

                return result;
            });

        return data;
    }
}
