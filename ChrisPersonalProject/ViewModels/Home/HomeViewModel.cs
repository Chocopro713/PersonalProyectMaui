using Acr.UserDialogs;
using ChrisPersonalProject.Models;

namespace ChrisPersonalProject.ViewModels.Home;

public class HomeViewModel : BaseViewModel
{
    #region Attributes
    #endregion Attributes

    #region Properties
    #endregion Properties

    #region Constructor
    public HomeViewModel()
    {
        this.RefreshCommand = new Command(GetData);
        // GetData();
    }
    #endregion Constructor

    #region Methods
    /// <summary>
    /// Call the test API and get the data
    /// </summary>
    private async void GetData()
    {
        this.IsRefreshing = false;
        try
        {
            if (this.IsBusy)
                return;
            this.IsBusy = true;

            HttpResponseMessage getUsers = await CallApi(await ApiManager.ListUsers());
            if (!getUsers.IsSuccessStatusCode)
            {
                NoSuccessApi("No se pudo obtener los datos");
                return;
            }
    
            var test = new List<UserModel>(await ConvertListData<UserModel>(getUsers));
    
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally 
        { 
            this.IsBusy = false;
        }
    }
    #endregion Methods

    #region Commands
    #endregion Commands
}
