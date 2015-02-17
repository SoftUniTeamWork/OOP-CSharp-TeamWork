using System;

namespace Exceptions
{
    class EntityDamageException : ApplicationException
    {
        public EntityDamageException()
        {
            throw new ApplicationException("Damage is under 0.");
        }

        public EntityDamageException(string msg)
            : base(msg)
        {
        }

        public EntityDamageException(string msg, string prop)
            : base(msg + "\nProperty: " + prop)
        {
        }

        public EntityDamageException(string msg, Exception inner)
            : base(msg, inner)
        {
        }
    }
}
