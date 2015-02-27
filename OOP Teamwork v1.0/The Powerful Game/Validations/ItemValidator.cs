namespace The_Powerful_Game.Validations
{
    using System;
    using System.Text.RegularExpressions;
    using The_Powerful_Game.Exceptions;

    public static class ItemValidator
    {
        internal static string ItemNameValidating(string value)
        {
            string pattern = @"[\!\@\#\$\%\^\&\*\+\=\/\\]+";
            Regex r = new Regex(pattern);
            if (value.Equals(string.Empty) || value.Equals(null) || (value.Length < 1 && value.Equals(" ")))
            {
                throw new ItemNameException("Item name must  non-null and non-whitespaces and non-empty.", "Item name");
            }
            else if (r.IsMatch(value))
            {
                throw new ItemNameException("Item name contains invalid symbols. Invalid symbols are[!@#$%^&*+=/\\]", "ItemName");
            }

            return value;
        }

        internal static string ItemTypeValidating(string value)
        {
            value = value.Trim().ToLower();
            bool isNullOrEmpty = value.Equals(null) || value.Equals(string.Empty);
            bool isValidType = value.Equals("one-handed") || value.Equals("two-handed") || value.Equals("off-hand") || value.Equals("ranged") || value.Equals("shield");
            if (isNullOrEmpty)
            {
                throw new ItemTypeException("Item type cannot be empty or null.", "ItemType");
            }
            else if (!isValidType)
            {
                throw new ItemTypeException("Item type does not exist.", "ItemType");
            }

            value = value[0].ToString().ToUpper() + value.Substring(1, value.Length - 1);
            return value;
        }

        internal static int PriceValidating(int value)
        {
            if (value < 0)
            {
                throw new IndexOutOfRangeException("Price must be greater than 0.");
            }

            return value;
        }

        internal static int LevelRequired(int value)
        {
            if (value < 0)
            {
                throw new IndexOutOfRangeException("Level required must be greater than 0.");
            }

            return value;
        }
    }
}
