using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSlotsAssignment
{

	class Program
	{
		
		static void Main(string[] args)
		{
			Dictionary<DateTime, DateTime> interval_List = new Dictionary<DateTime, DateTime>();
            Dictionary<DateTime, DateTime> time_slot = new Dictionary<DateTime, DateTime>();
            Console.WriteLine("Please Enter the Time Intervals (e.g. 8:00 AM to 10:00 AM)");
            DateTime d1 = new DateTime();
            DateTime d2 = new DateTime();
            TimeSpan ts;
            int count = 0, i = 0, j = 0;
            string ch="";
            try
            {
                do
                {
                    Console.WriteLine("Enter Time Slot " + (count+1) + " : ");
                    Console.Write("Start Time : ");
                    d1 = Convert.ToDateTime(Console.ReadLine());
                    Console.Write("End Time : ");
                    d2 = Convert.ToDateTime(Console.ReadLine());
                    ts = d2.Subtract(d1);
                    interval_List.Add(d1, d2);
                    Console.Write("Are you sure to continue (Y/N) : ");
                    ch = Console.ReadLine();
                    count++;
                } while (ch == "Y" || ch == "y");
                var l =interval_List.OrderBy(m=>m.Key);
                interval_List = l.ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value);
                while(i<count)
                {
                    for(j=i;j<count-1;j++)
                    {
                        if((interval_List.ElementAt(j).Key >= interval_List.ElementAt(i).Value && interval_List.ElementAt(i).Value <= interval_List.ElementAt(j).Value))
                        {
                            break;
                        }
                    }
                    time_slot.Add(interval_List.ElementAt(i).Key, interval_List.ElementAt(j).Value);
                    i = ++j;
                }

                Console.WriteLine("Find New Time Slots.");
                foreach (var item in time_slot)
                {
                    Console.WriteLine(item.Key.ToShortTimeString() + " to " + item.Value.ToShortTimeString());
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Invalid Input.");
            }
            
            Console.Read();
        }
	}
}
