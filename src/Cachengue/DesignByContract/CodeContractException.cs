using System;

namespace Cachengue.DesignByContract
{
    /// <summary>
    /// Exception raised when a contract is broken.
    /// Catch this exception type if you wish to differentiate between
    /// any DesignByContract exception and other runtime exceptions.
    /// </summary>
    public class CodeContractException: Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CodeContractException" /> class.
        /// </summary>
        protected CodeContractException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeContractException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        protected CodeContractException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeContractException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        protected CodeContractException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
