namespace MixERP.Net.WebControls.ScrudFactory.Data
{
    public static class Sanitizer
    {
        /// <summary>
        /// Please do not use this function to fix the quotes against SQL injection attack.
        /// This is not a replacement of parameterized statements.
        /// Use this function only when you need to sanitize "column names" and/or "table names"
        /// which cannot be done using standard practices.
        /// </summary>
        /// <param name="identifier">Column name or table name which needs to be sanitized</param>
        /// <returns>
        /// Only alphabets and underscore are allowed characters in identifier name.
        /// Anything else than that will be removed.
        /// </returns>
        public static string SanitizeIdentifierName(string identifier)
        {
            return DbFactory.Sanitizer.SanitizeIdentifierName(identifier);
        }
    }
}