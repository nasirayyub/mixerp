namespace MixERP.Net.WebControls.ScrudFactory.Helpers
{
    internal static class ScrudLocalizationHelper
    {
        internal static string GetResourceString(string resourceClassName, string key)
        {
            return i18n.ResourceManager.GetString(resourceClassName, key);
        }
    }
}