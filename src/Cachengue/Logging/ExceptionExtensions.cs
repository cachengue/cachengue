namespace System
{
    /// <summary>
    /// Exception class extension methods
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// Returns a human readable nicely formatted error message from the exception containing all the inner exceptions.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="useBrInsteadOfNewLine">if set to <c>true</c> [use br instead of new line].</param>
        /// <returns>
        /// The error message
        /// </returns>
        public static string ToErrorMessage(this Exception exception, bool useBrInsteadOfNewLine = false)
        {
            return exception.ToString().Replace("--- End of inner exception stack trace ---", string.Empty).Replace(" ---> ", useBrInsteadOfNewLine ? "<br />" : Environment.NewLine);
        }
    }
}
