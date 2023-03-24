using ChrisPersonalProject.Models.Auth;

namespace ChrisPersonalProject;

/// <summary>
/// Clase a nivel global lo cual permite almacenar información de forma temporal.
/// Tag: "Sessión Temporal", hasta que se cierre la aplicación.
/// Esta información se vuelve almacenar cuando habre la sessión 
/// Almacena de forma temporal la información.
/// La infomación se obtiene por medio del "singleton"
/// </summary>
public class GlobalSetting
{
    #region Constructor
    public GlobalSetting()
    {
        instance = this;
    }
    #endregion Constructor

    #region Singleton
    /// <value>Instancia de la clase.</value>
    private static GlobalSetting instance;

    /// <summary>Singleton</summary>
    /// <remarks>Restringir la creación de objetos pertenecientes a una clase o el 
    /// valor de un tipo a un único objeto. Su intención consiste en garantizar que 
    /// una clase solo tenga una instancia y proporcionar un punto de acceso global a ella</remarks>
    /// <returns>Singleton <see cref="ChrisPersonalProject.GlobalSetting" /> </returns>
    public static GlobalSetting GetInstance()
    {
        if (instance == null)
            return new GlobalSetting();

        return instance;
    }
    #endregion Singleton

    #region API
    public static string Version = $"Versión: {VersionTracking.CurrentVersion}";
    public static string ContentTypeJson = "application/json;charset=utf-8";

#if DEBUG
    public static string Servidor = "https://jsonplaceholder.typicode.com";
#else
	// public static string Servidor = "https://jsonplaceholder.typicode.com";

#endif
    #endregion API

    #region Properties
    public LogInModel Login { get; set; }
    #endregion Properties
}