namespace XOPERO_task.UI_Tests;

public static class DirectoryHelper
{
    public static string Root => Directory.GetParent(AppContext.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
    public static string ConfigurationPath => Root + "\\UI-Tests\\Configuration\\configuration.ui.json";
    public static string ProductsDataPath => Root + "\\UI-Tests\\Data\\products-data.json";
    public static string ClientsDataPath => Root + "\\UI-Tests\\Data\\clients-data.json";
}
