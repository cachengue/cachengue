using System;

namespace Cachengue.DesignByContract
{
    /// <summary>
    /// Exception raised when an invariant fails.
    /// </summary>
    public class PostconditionException : CodeContractException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostconditionException" /> class.
        /// </summary>
        public PostconditionException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostconditionException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public PostconditionException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostconditionException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public PostconditionException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
