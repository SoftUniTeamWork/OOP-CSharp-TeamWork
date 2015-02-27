namespace The_Powerful_Game.Exceptions
{
    using System;

    public class ItemNameException : ApplicationException
    {
        public ItemNameException()
        {
            throw new ApplicationException("Item name is null or empty or invalid.");
        }

        public ItemNameException(string msg)
            : base(msg)
        {
        }

        public ItemNameException(string msg, string prop)
            : base(msg + "\nProperty: " + prop)
        {
        }

        public ItemNameException(string msg, Exception e) : base(msg, e)
        {
        }
    }
}
