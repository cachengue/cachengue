using System;

namespace Cachengue.DesignByContract
{
    /// <summary>
    /// Exception raised when an invariant fails.
    /// </summary>
    public class InvariantException : CodeContractException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvariantException" /> class.
        /// </summary>
        public InvariantException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvariantException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public InvariantException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvariantException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public InvariantException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
