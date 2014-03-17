using System;
using System.Diagnostics;

namespace Cachengue.DesignByContract
{
    /// <summary>
    ///    Design by Contract checks developed by http://www.codeproject.com/KB/cs/designbycontract.aspx.
    ///    Each method generates an exception or
    ///    a trace assertion statement if the contract is broken.
    /// </summary>
    /// <remarks>
    ///    This example shows how to call the Require method.
    ///    Assume DBC_CHECK_PRECONDITION is defined.
    ///    <code>
    ///        public void Test(int x)
    ///        {
    ///        try
    ///        {
    ///        Check.Require(x > 1, "x must be > 1");
    ///        }
    ///        catch (System.Exception ex)
    ///        {
    ///        Console.WriteLine(ex.ToString());
    ///        }
    ///        }
    ///    </code>
    ///    If you wish to use trace assertion statements, intended for Debug scenarios,
    ///    rather than exception handling then set 
    ///    <code>Check.UseAssertions = true</code>
    ///    You can specify this in your application entry point and maybe make it
    ///    dependent on conditional compilation flags or configuration file settings, e.g.,
    ///    <code>
    ///        #if DBC_USE_ASSERTIONS
    ///        Check.UseAssertions = true;
    ///        #endif
    ///    </code>
    ///    You can direct output to a Trace listener. For example, you could insert
    ///    <code>
    ///        Trace.Listeners.Clear();
    ///        Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
    ///    </code>
    ///    or direct output to a file or the Event Log.
    ///    (Note: For ASP.NET clients use the Listeners collection
    ///    of the Debug, not the Trace, object and, for a Release build, only exception-handling
    ///    is possible.)
    /// </remarks>
    public static class Check
    {
        /// <summary>
        ///     Gets or sets a value indicating whether you wish to use Trace Assert statements 
        ///     instead of exception handling. 
        ///     (The Check class uses exception handling by default.)
        /// </summary>
        public static bool UseAssertions { get; set; }

        /// <summary>
        /// Gets a value indicating whether exception handling is being used
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use exceptions]; otherwise, <c>false</c>.
        /// </value>
        private static bool UseExceptions
        {
            get
            {
                return !UseAssertions;
            }
        }

        /// <summary>
        /// Assertion check.
        /// </summary>
        /// <param name="assertion">if set to <c>true</c> [assertion].</param>
        /// <param name="message">The message.</param>
        /// <exception cref="AssertionException">When the assertion is not valid</exception>
        public static void Assert(bool assertion, string message)
        {
            if (UseExceptions)
            {
                if (!assertion)
                {
                    throw new AssertionException(message);
                }
            }
            else
            {
                Trace.Assert(assertion, "Assertion: " + message);
            }
        }

        /// <summary>
        /// Assertion check.
        /// </summary>
        /// <param name="assertion">if set to <c>true</c> [assertion].</param>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        /// <exception cref="AssertionException">When the assertion is not valid</exception>
        public static void Assert(bool assertion, string message, Exception inner)
        {
            if (UseExceptions)
            {
                if (!assertion)
                {
                    throw new AssertionException(message, inner);
                }
            }
            else
            {
                Trace.Assert(assertion, "Assertion: " + message);
            }
        }

        /// <summary>
        /// Assertion check.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="assertion">if set to <c>true</c> [assertion].</param>
        /// <param name="message">The message.</param>
        public static void Assert<TException>(bool assertion, string message) where TException : Exception, new()
        {
            Assert(assertion, message, new TException());
        }

        /// <summary>
        /// Assertion check.
        /// </summary>
        /// <param name="assertion">if set to <c>true</c> [assertion].</param>
        /// <exception cref="AssertionException">When the assertion is not valid</exception>
        public static void Assert(bool assertion)
        {
            if (UseExceptions)
            {
                if (!assertion)
                {
                    throw new AssertionException("Assertion failed.");
                }
            }
            else
            {
                Trace.Assert(assertion, "Assertion failed.");
            }
        }

        /// <summary>
        /// Postcondition check.
        /// </summary>
        /// <param name="assertion">if set to <c>true</c> [assertion].</param>
        /// <param name="message">The message.</param>
        public static void Ensure(bool assertion, string message)
        {
            if (UseExceptions)
            {
                if (!assertion)
                {
                    throw new PostconditionException(message);
                }
            }
            else
            {
                Trace.Assert(assertion, "Postcondition: " + message);
            }
        }

        /// <summary>
        /// Postcondition check.
        /// </summary>
        /// <param name="assertion">if set to <c>true</c> [assertion].</param>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public static void Ensure(bool assertion, string message, Exception inner)
        {
            if (UseExceptions)
            {
                if (!assertion)
                {
                    throw new PostconditionException(message, inner);
                }
            }
            else
            {
                Trace.Assert(assertion, "Postcondition: " + message);
            }
        }

        /// <summary>
        /// Postcondition check.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="assertion">if set to <c>true</c> [assertion].</param>
        /// <param name="message">The message.</param>
        public static void Ensure<TException>(bool assertion, string message) where TException : Exception, new()
        {
            Ensure(assertion, message, new TException());
        }

        /// <summary>
        /// Postcondition check.
        /// </summary>
        /// <param name="assertion">if set to <c>true</c> [assertion].</param>
        public static void Ensure(bool assertion)
        {
            if (UseExceptions)
            {
                if (!assertion)
                {
                    throw new PostconditionException("Postcondition failed.");
                }
            }
            else
            {
                Trace.Assert(assertion, "Postcondition failed.");
            }
        }

        /// <summary>
        /// Invariant check.
        /// </summary>
        /// <param name="assertion">if set to <c>true</c> [assertion].</param>
        /// <param name="message">The message.</param>
        /// <exception cref="InvariantException">When the assertion is not valid</exception>
        public static void Invariant(bool assertion, string message)
        {
            if (UseExceptions)
            {
                if (!assertion)
                {
                    throw new InvariantException(message);
                }
            }
            else
            {
                Trace.Assert(assertion, "Invariant: " + message);
            }
        }

        /// <summary>
        /// Invariant check.
        /// </summary>
        /// <param name="assertion">if set to <c>true</c> [assertion].</param>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        /// <exception cref="InvariantException">When the assertion is not valid</exception>
        public static void Invariant(bool assertion, string message, Exception inner)
        {
            if (UseExceptions)
            {
                if (!assertion)
                {
                    throw new InvariantException(message, inner);
                }
            }
            else
            {
                Trace.Assert(assertion, "Invariant: " + message);
            }
        }

        /// <summary>
        /// Invariants the specified assertion.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="assertion">if set to <c>true</c> [assertion].</param>
        /// <param name="message">The message.</param>
        public static void Invariant<TException>(bool assertion, string message) where TException : Exception, new()
        {
            Invariant(assertion, message, new TException());
        }

        /// <summary>
        /// Invariant check.
        /// </summary>
        /// <param name="assertion">if set to <c>true</c> [assertion].</param>
        /// <exception cref="InvariantException">When the assertion is not valid</exception>
        public static void Invariant(bool assertion)
        {
            if (UseExceptions)
            {
                if (!assertion)
                {
                    throw new InvariantException("Invariant failed.");
                }
            }
            else
            {
                Trace.Assert(assertion, "Invariant failed.");
            }
        }

        /// <summary>
        /// Precondition check - should run regardless of preprocessor directives.
        /// </summary>
        /// <param name="assertion">if set to <c>true</c> [assertion].</param>
        /// <param name="message">The message.</param>
        public static void Require(bool assertion, string message)
        {
            if (UseExceptions)
            {
                if (!assertion)
                {
                    throw new PreconditionException(message);
                }
            }
            else
            {
                Trace.Assert(assertion, "Precondition: " + message);
            }
        }

        /// <summary>
        /// Precondition check - should run regardless of preprocessor directives.
        /// </summary>
        /// <param name="assertion">if set to <c>true</c> [assertion].</param>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public static void Require(bool assertion, string message, Exception inner)
        {
            if (UseExceptions)
            {
                if (!assertion)
                {
                    throw new PreconditionException(message, inner);
                }
            }
            else
            {
                Trace.Assert(assertion, "Precondition: " + message);
            }
        }

        /// <summary>
        /// Requires the specified assertion.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="assertion">if set to <c>true</c> [assertion].</param>
        /// <param name="message">The message.</param>
        public static void Require<TException>(bool assertion, string message) where TException : Exception, new()
        {
            Require(assertion, message, new TException());
        }

        /// <summary>
        /// Precondition check - should run regardless of preprocessor directives.
        /// </summary>
        /// <param name="assertion">if set to <c>true</c> [assertion].</param>
        public static void Require(bool assertion)
        {
            if (UseExceptions)
            {
                if (!assertion)
                {
                    throw new PreconditionException("Precondition failed.");
                }
            }
            else
            {
                Trace.Assert(assertion, "Precondition failed.");
            }
        }
    }
}