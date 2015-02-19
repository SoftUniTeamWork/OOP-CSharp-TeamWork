using The_Powerful_Game.Exceptions;

namespace The_Powerful_Game.Validations
{
    /// <summary>
    /// Entity validations are doing here. Validations for Name and Damage.
    /// </summary>
    public static class EntityValidator
    {
        /// <summary>
        /// This method validates entity name.
        /// </summary>
        /// <param name="str">Here is value from property that will be validated.</param>
        /// <returns>If value is valid it will be returned.</returns>
        /// <exception cref="EntityNameException">
        /// If value is invalid it will be throw an exception with message "Entity name cannot be null or empty." with incorrect property value.
        /// </exception>
        internal static string NameValidating(string str)
        {
            str = str.Trim();
            bool isInvalid = str.Equals(null) || str.Equals("");
            if (isInvalid)
            {
                throw new EntityNameException("Entity Name cannot be null or empty.", "EntityName");
            }
            return str;
        }

        /// <summary>
        /// Validates damage. Checks that damage to be non-negative.
        /// </summary>
        /// <param name="value">Value from the property in parental constructor.</param>
        /// <returns>Returns value if its valid.</returns>
        /// <exception cref="EntityDamageException">
        /// Throws exception if value is negative with following message: "Entity cannot make negative damage." and property "damage"
        /// </exception>
        internal static int DamageValidating(int value)
        {
            if (value < 0)
            {
                throw new EntityDamageException("Entity cannot make negative damage.", "damage");
            }
            return value;
        }
    }
}
