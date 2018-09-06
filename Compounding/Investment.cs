using System;
namespace Compounding
{
    public class Investment
    {
        private float value;
        private int daysUntilExpiry;
        public bool hasExpired
        {
            get
            {
                return daysUntilExpiry <= 0;
            }
        }

        public Investment(float _value)
        {
            value = _value;
            daysUntilExpiry = 99;
        }
        public Investment(float _value, int daysLeft)
        {
            value = _value;
            daysUntilExpiry = daysLeft;
        }

        public float GetInvestment(float rate)
        {
            if(daysUntilExpiry >= 0)
            {
                daysUntilExpiry--;
                return value * rate;
            }
            return 0;
        }

        public float GetValue()
        {
            return value;
        }

    }
}
