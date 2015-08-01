using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Overlapping_Time_Slot
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList fromSlot = new ArrayList();
            ArrayList toSlot = new ArrayList();

            Console.WriteLine("How many time slots you want to merege");
            int numOfTimeSlots = Convert.ToInt32(Console.ReadLine());
            string sDate = Convert.ToString(System.DateTime.Now.Date.ToShortDateString());
            for (int count = 1; count <= numOfTimeSlots; count++)
            {
                Console.WriteLine("Enter FROM Time slot in 24 Hrs value as HH:MM");
                string sFromDt = Convert.ToString(Console.ReadLine());
                sFromDt = sDate + " " + sFromDt + ":00.000";
                fromSlot.Add(sFromDt);
                Console.WriteLine("Enter TO Time slot in 24 Hrs value as HH:MM");
                string sToDt = Convert.ToString(Console.ReadLine());
                sToDt = sDate + " " + sToDt + ":00.000";
                toSlot.Add(sToDt);
            }

            DateTime tt = DateTime.Parse(fromSlot[0].ToString());
            Console.WriteLine(tt);
            DateTime ts = DateTime.Parse(toSlot[0].ToString());
            Console.WriteLine(ts);
            int i2 = TimeSpan.Compare(tt.TimeOfDay, ts.TimeOfDay);
            Console.WriteLine(i2);
           
 

            //////////////////////////////////////////
            //finding minimum date value from al
            DateTime minDate = DateTime.MaxValue;
            DateTime maxDate = DateTime.MinValue;
            foreach (var dateString in fromSlot)
            {
                DateTime date = DateTime.Parse(dateString.ToString());
                if (date < minDate)
                    minDate = date;
                if (date > maxDate)
                    maxDate = date;
            }
            Console.WriteLine("Min Date"+minDate.ToString());
            Console.WriteLine("Max Date" + maxDate.ToString());
            Console.ReadLine();
           //int i2= TimeSpan.Compare(t1.TimeOfDay, t2.TimeOfDay);
           //Console.Write(i2.ToString());
           //Console.Read();

           // for (DateTime x = t1; x <= t6; x = x.AddDays(1))
           // {
               
           // }

        }
    }
}
