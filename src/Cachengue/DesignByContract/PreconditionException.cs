using System;

namespace Cachengue.DesignByContract
{
    /// <summary>
    /// Exception raised when an invariant fails.
    /// </summary>
    public class PreconditionException : CodeContractException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PreconditionException" /> class.
        /// </summary>
        public PreconditionException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PreconditionException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public PreconditionException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PreconditionException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public PreconditionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
