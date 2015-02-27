namespace The_Powerful_Game.Entities
{
    public struct AttributePair
    {
        private int currentValue;
        private int maximumValue;

        public AttributePair(int currentValue, int maxValue)
        {
            this.currentValue = currentValue;
            this.maximumValue = maxValue;
        }

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

        public AttributePair Increase(int value)
        {
            this.currentValue += value;
            if (this.currentValue > this.maximumValue)
            {
                this.currentValue = this.maximumValue;
            }
            return new AttributePair(this.currentValue, this.maximumValue);
        }

        public AttributePair Decrease(int value)
        {
            this.currentValue -= value;
            if (this.currentValue < 0)
            {
                this.currentValue = 0;
            }
            return new AttributePair(this.currentValue, this.maximumValue);
        }

        public AttributePair SetCurrent(int value)
        {
            this.currentValue = value;
            if (this.currentValue > this.maximumValue)
            {
                this.currentValue = this.maximumValue;
            }
            return new AttributePair(this.currentValue, this.maximumValue);
        }

        public void SetMaximum(int value)
        {
            this.maximumValue = value;
            if (this.currentValue > this.maximumValue)
            {
                this.currentValue = this.maximumValue;
            }
        }
    }
}
