using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Teamwork.Models.CharacterClasses
{
    public struct AttributePair
    {
        //Fields and properties

        int currentValue;
        int maximumValue;

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
        
        //Constructors

        public AttributePair(ushort maxValue)
        {
            this.currentValue = maxValue;
            this.maximumValue = maxValue;
        }

        //Methods

        public void Heal (ushort value)   // value is ushort type, so that negative values can't be passed
        {
            currentValue += value;
            if(currentValue > maximumValue){
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
