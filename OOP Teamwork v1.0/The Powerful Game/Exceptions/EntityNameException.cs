using System;

namespace Exceptions
{
    /// <summary>
    /// Entity name exception with some constructors.
    /// </summary>
    public class EntityNameException : ApplicationException
    {
        /// <summary>
        /// Constructor with default message. Message is: "Your name is null or empty."
        /// </summary>
        public EntityNameException()
        {
            throw new ApplicationException("Your name is null or empty.");
        }

        /// <summary>
        /// Constructor for your choice message.
        /// </summary>
        /// <param name="msg">Enter your message here</param>
        public EntityNameException(string msg)
            : base(msg)
        {
        }

        /// <summary>
        /// Constructor with your choice message and property/ies errors.
        /// </summary>
        /// <param name="msg">Enter your message.</param>
        /// <param name="prop">Enter your property/ies like string with ','</param>
        public EntityNameException(string msg, string prop)
            : base(msg + "\nProperty: " + prop)
        {
        }

        /// <summary>
        /// Constructor with your choice message and inner exception.
        /// </summary>
        /// <param name="msg">Your message</param>
        /// <param name="innerException">What is the inner exception?</param>
        public EntityNameException(string msg, Exception innerException)
            : base(msg, innerException)
        {
        }
    }
}
