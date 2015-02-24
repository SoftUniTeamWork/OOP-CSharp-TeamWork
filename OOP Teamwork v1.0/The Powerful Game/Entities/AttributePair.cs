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
        public AttributePair(int currentValue, int maxValue)
        {
            this.currentValue = currentValue;
            this.maximumValue = maxValue;
        }

        //Properties
        public int CurrentValue
        {
            get
            {
                return this.currentValue;
            }
        }

        public int MaximumValue
        {
            get
            {
                return this.maximumValue;
            }
        }

        //Methods
        /// <summary>
        /// This method increment heal value and checks value for overflow.
        /// </summary>
        /// <param name="value">add health</param>
        public AttributePair Increase(int value)   // value is ushort type, so that negative values can't be passed
        {
            this.currentValue += value;
            if (this.currentValue > this.maximumValue)
            {
                this.currentValue = this.maximumValue;
            }
            return new AttributePair(this.currentValue, this.maximumValue);
        }

        /// <summary>
        /// This method takes damage. Checks if damage is zero.
        /// </summary>
        /// <param name="value">take damage</param>
        public AttributePair Decrease(int value)
        {
            this.currentValue -= value;
            if (this.currentValue < 0)
            {
                this.currentValue = 0;
            }
            return new AttributePair(this.currentValue, this.maximumValue);
        }

        /// <summary>
        /// This method sets the current value.
        /// </summary>
        /// <param name="value">current value</param>
        public AttributePair SetCurrent(int value)  // used to set the currentValue
        {
            this.currentValue = value;
            if (this.currentValue > this.maximumValue)
            {
                this.currentValue = this.maximumValue;
            }
            return new AttributePair(this.currentValue, this.maximumValue);
        }

        /// <summary>
        /// This method sets the max value
        /// </summary>
        /// <param name="value">max value</param>
        public void SetMaximum(int value) // used to set the maximumValue
        {
            this.maximumValue = value;
            if (this.currentValue > this.maximumValue)
            {
                this.currentValue = this.maximumValue;
            }
        }
    }
}
