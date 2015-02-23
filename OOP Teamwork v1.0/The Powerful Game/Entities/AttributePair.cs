using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Powerful_Game.Entities
{
    public struct AttributePair
    {
        //Fields
        private int currentValue;
        private int maximumValue;

        //Constructors
        /// <summary>
        /// This constructor set attribute max value.
        /// </summary>
        /// <param name="maxValue">the max value</param>
        public AttributePair(ushort maxValue)
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

        public static AttributePair Zero
        {
            get
            {
                return new AttributePair();
            }
        }

        

        //Methods
        /// <summary>
        /// This method increment heal value and checks value for overflow.
        /// </summary>
        /// <param name="value">add health</param>
        public void Heal(ushort value)   // value is ushort type, so that negative values can't be passed
        {
            currentValue += value;
            if (currentValue > maximumValue)
            {
                currentValue = maximumValue;
            }
        }

        /// <summary>
        /// This method takes damage. Checks if damage is zero.
        /// </summary>
        /// <param name="value">take damage</param>
        public void Damage(ushort value)
        {
            currentValue -= value;
            if (currentValue < 0)
            {
                currentValue = 0;
            }
        }

        /// <summary>
        /// This method sets the current value.
        /// </summary>
        /// <param name="value">current value</param>
        public void SetCurrent(ushort value)  // used to set the currentValue
        {
            currentValue = value;
            if (currentValue > maximumValue)
            {
                currentValue = maximumValue;
            }
        }

        /// <summary>
        /// This method sets the max value
        /// </summary>
        /// <param name="value">max value</param>
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
