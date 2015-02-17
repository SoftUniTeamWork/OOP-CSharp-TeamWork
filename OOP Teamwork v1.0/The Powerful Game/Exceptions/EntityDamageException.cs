using System;

namespace Exceptions
{
    /// <summary>
    /// Entity damage exception thrower messenger.
    /// </summary>
    class EntityDamageException : ApplicationException
    {
        /// <summary>
        /// Default message is Damage is under 0.
        /// </summary>
        public EntityDamageException()
        {
            throw new ApplicationException("Damage is under 0.");
        }

        /// <summary>
        /// Your choice message.
        /// </summary>
        /// <param name="msg">Enter your message</param>
        public EntityDamageException(string msg)
            : base(msg)
        {
        }

        /// <summary>
        /// Constructor with your choice message and property/ies.
        /// </summary>
        /// <param name="msg">Your message here.</param>
        /// <param name="prop">Invalid property/ies here.</param>
        public EntityDamageException(string msg, string prop)
            : base(msg + "\nProperty: " + prop)
        {
        }

        /// <summary>
        /// Constructor with your choice message and inner exception.
        /// </summary>
        /// <param name="msg">Enter message</param>
        /// <param name="inner">Enter inner exception.</param>
        public EntityDamageException(string msg, Exception inner)
            : base(msg, inner)
        {
        }
    }
}
