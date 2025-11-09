namespace XOPERO_task.Common.Helpers;

public abstract class DirectoryHelper
{
    public static string Root => Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;

    // UI Paths
    public static string UIConfigurationPath => Root + "\\UI-Tests\\Configuration\\configuration.ui.json";
    public static string UIProductsDataPath => Root + "\\UI-Tests\\Data\\products-data.json";
    public static string UIClientsDataPath => Root + "\\UI-Tests\\Data\\clients-data.json";

    // API Paths
    public static string APIConfigurationPath => Root + "\\API-Tests\\Configuration\\configuration.api.json";
}
