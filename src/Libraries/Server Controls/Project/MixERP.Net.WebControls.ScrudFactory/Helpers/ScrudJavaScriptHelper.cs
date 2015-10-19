using MixERP.Net.Common;
using MixERP.Net.Common.Helpers;
using System;
using System.Globalization;
using System.Reflection;

namespace MixERP.Net.WebControls.ScrudFactory.Helpers
{
    internal static class ScrudJavascriptHelper
    {
        internal static string GetScript(string catalog, string keyColumn, string customFormUrl, string formGridViewId, string gridPanelId, string userIdHiddenId, string officeCodeHiddenId, string titleLabelId, string formPanelId, string cancelButtonId)
        {
            string resource = JSUtility.GetEmbeddedScript("MixERP.Net.WebControls.ScrudFactory.Scrud.js", Assembly.GetExecutingAssembly());
            string script = string.Empty;

            script += JSUtility.GetVar("gridPanelId", gridPanelId);
            script += JSUtility.GetVar("userIdHiddenId", userIdHiddenId);
            script += JSUtility.GetVar("formGridViewId", formGridViewId);
            script += JSUtility.GetVar("officeCodeHiddenId", officeCodeHiddenId);
            script += JSUtility.GetVar("titleLabelId", titleLabelId);
            script += JSUtility.GetVar("formPanelId", formPanelId);
            script += JSUtility.GetVar("cancelButtonId ", cancelButtonId);

            script += JSUtility.GetVar("keyColumn", keyColumn);
            script += JSUtility.GetVar("customFormUrl", customFormUrl);

            script += resource;
            return script;
        }
    }
}