using System;
using System.Collections.Generic;
using System.Linq;
namespace Compounding
{
    class MainClass
    {
        public static List<Investment> investments = new List<Investment>();
        public static void Main(string[] args)
        {
            Console.WriteLine("Input current invested amount :");
            float init = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Input compound rate (for 1.4%, input 1.4):");
            float rate = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Input amount of days to compound:");
            int days = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input 1 withdrawal every X days:");
            int withdrawInt = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= 100; i++)
            {
                investments.Add(new Investment(init / (float)100, i));
            }
            float num = GetReturnInvestment(rate, days, withdrawInt);
            //Console.WriteLine("Initial investment : {0}LTC ; base earning rate : {1}% ; interval of reinvestment : {2} days", init, rate, interval);
            Console.WriteLine("Total active investments : " + num.ToString());
            Console.ReadLine();
        }

        public static float GetReturnInvestment(float rate, int days, int withdrawInt)
        {
            rate /= 100;
            float totalInvestment = 0;
            float dayEarnings = 0;
            float profits = 0;
            for (int i = 0; i < days; i++)
            {
                
                foreach (Investment investment in investments)
                {
                    dayEarnings += investment.GetInvestment(rate);
                }
                if (dayEarnings > 0.03f)
                {
                    if (withdrawInt == 0 || i % withdrawInt != 0)
                    {
                        investments.Add(new Investment(dayEarnings));
                        dayEarnings = 0;
                    }
                    else
                    {
                        profits += dayEarnings;
                        dayEarnings = 0;
                    }
                }
                RemoveExpiredInvestments();
            }
            foreach (Investment investment in investments)
            {
                totalInvestment += investment.GetValue();
            }
            Console.WriteLine("Total withdrawed amount : " + profits.ToString());
            return totalInvestment;
        }

        public static void RemoveExpiredInvestments()
        {
            List<Investment> expiredList = new List<Investment>();
            foreach (Investment investment in investments)
            {
                if (investment.hasExpired) expiredList.Add(investment);
            }
            investments = investments.Except(expiredList).ToList();
        }
    }
}
