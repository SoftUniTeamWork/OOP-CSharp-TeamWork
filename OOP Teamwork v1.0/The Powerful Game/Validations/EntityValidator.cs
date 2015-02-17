using Exceptions;

namespace Validations
{
    public static class EntityValidator
    {
        internal static string NameValidating(string str)
        {
            str = str.Trim();
            bool isInvalid = str.Equals(null) || str.Equals("");
            if (isInvalid)
            {
                throw new EntityNameException("Entity Name cannot be null.", "EntityName");
            }
            return str;
        }

        internal static int DamageValidating(int value)
        {
            if (value < 0)
            {
                throw new EntityDamageException("Entity cannot make negative damage.", "EntityDamage");
            }
            return value;
        }
    }
}
