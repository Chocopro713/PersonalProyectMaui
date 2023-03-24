using Acr.UserDialogs;
using ChrisPersonalProject.Services.RestApi;
using Newtonsoft.Json;
using System;

namespace ChrisPersonalProject.ViewModels;

public class BaseViewModel : BindableBase
{
    #region Attributes
    IApiService<IEndPoints> obtenerAPI = new ApiService<IEndPoints>(GlobalSetting.Servidor);
    public IApiManager ApiManager;
    private bool _isBusy;
    private bool _isRefreshing;
    #endregion Attributes

    #region Properties
    public bool IsBusy { get => _isBusy; set { SetProperty(ref _isBusy, value); } }
    public bool IsRefreshing { get => _isRefreshing; set { SetProperty(ref _isRefreshing, value); } }
    public Command RefreshCommand { get; set; }
    #endregion Properties

    #region Constructor
    public BaseViewModel()
    {
        this.ApiManager = new ApiManager(obtenerAPI);
    }
    #endregion Constructor

    #region Methods
    public async Task<List<T>> ConvertListData<T>(HttpResponseMessage api)
    {
        try
        {
            var jsonNameResponse = await api.Content.ReadAsStringAsync();
            var apiResponse = await Task.Run(() => JsonConvert.DeserializeObject<List<T>>(jsonNameResponse));
            return apiResponse;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return new List<T>();
        }
    }

    public async Task<T> ConvertObjectData<T>(HttpResponseMessage api)
    {
        try
        {
            var jsonNameResponse = await api.Content.ReadAsStringAsync();
            var apiResponse = await Task.Run(() => JsonConvert.DeserializeObject<T>(jsonNameResponse));
            return apiResponse;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return default(T);
        }
    }

    public async Task<HttpResponseMessage> CallApi(HttpResponseMessage endPoint)
    {
        App.UserDialog.ShowLoading("Obteniendo información");
        HttpResponseMessage api = endPoint;
        App.UserDialog.HideLoading();

        return api;
    }

    public async void NoSuccessApi(string message)
    {
        await App.UserDialog.AlertAsync(message, "Error", "Aceptar");
    }
    #endregion Methods

    #region Commands
    #endregion Commands
}
