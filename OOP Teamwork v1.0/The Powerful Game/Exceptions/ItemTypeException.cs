namespace The_Powerful_Game.Exceptions
{
    using System;

    public class ItemTypeException : Exception
    {
        public ItemTypeException()
        {
            throw new ApplicationException("Item type does not exist.");
        }

        public ItemTypeException(string msg)
            : base(msg)
        {
        }

        public ItemTypeException(string msg, string prop)
            : base(msg + "\nProperty: " + prop)
        {
        }

        public ItemTypeException(string msg, Exception inner)
            : base(msg, inner)
        {
        }
    }
}
