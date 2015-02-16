
namespace OOP_Teamwork.Characters
{
    public struct Attribute
    {
        //Fields
        private int currentValue;
        private int maximumValue;

        //Constructors

        public Attribute(ushort maxValue)
        {
            this.currentValue = maxValue;
            this.maximumValue = maxValue;
        }

        //Properties
        public int CurrentValue
        {
            get
            {
                return currentValue;
            }
        }

        public int MaximumValue
        {
            get
            {
                return maximumValue;
            }
        }

        public static Attribute Zero
        {
            get
            {
                return new Attribute();
            }
        }

        

        //Methods

        public void Heal(ushort value)   // value is ushort type, so that negative values can't be passed
        {
            currentValue += value;
            if (currentValue > maximumValue)
            {
                currentValue = maximumValue;
            }
        }

        public void Damage(ushort value)
        {
            currentValue -= value;
            if (currentValue < 0)
            {
                currentValue = 0;
            }
        }

        public void SetCurrent(ushort value)  // used to set the currentValue
        {
            currentValue = value;
            if (currentValue > maximumValue)
            {
                currentValue = maximumValue;
            }
        }
        public void SetMaximum(ushort value) // used to set the maximumValue
        {
            maximumValue = value;
            if (currentValue > maximumValue)
            {
                currentValue = maximumValue;
            }
        }
    }
}
