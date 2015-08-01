using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace developerTest2
{
    class Time
    {
        public int flag { get; set; }
        public int startHours { get; set; }
        public int startMinute { get; set; }
        public int endHours { get; set; }
        public int endMinute { get; set; }
    }
    class Program
    {
        public IEnumerable<Time> overLap(List<Time> listOfSlot)
        {
            var tempList = listOfSlot;
            var newTimeSlot = new List<Time>();
            foreach (var currentListTime in listOfSlot)
            {
                var flag = 0;
                Time t = new Time();
                if (currentListTime.flag == 0)
                {
                    foreach (var tempListTime in tempList)
                    {
                        var currentIndex = listOfSlot.IndexOf(currentListTime);
                        var tempIndex = tempList.IndexOf(tempListTime);
                        if (currentIndex < tempIndex)
                        {
                            if (currentListTime.endHours >= tempListTime.startHours)
                            {
                                listOfSlot.ElementAt(tempIndex).flag = 1;
                                t.startHours = currentListTime.startHours;
                                t.startMinute = currentListTime.startMinute;
                                t.endHours = tempListTime.endHours;
                                t.endMinute = tempListTime.endMinute;
                                newTimeSlot.Add(t);
                                flag = 1;
                                break;
                            }
                        }
                    }
                    if (flag == 0)
                    {
                        newTimeSlot.Add(currentListTime);
                    }
                }
            }

            return newTimeSlot;
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("Please enter no. of time slot");
            var noOfTimeSlot = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter hour and minute in 24hrs time format :");
            var givenTimeSlot = new List<Time>();
            for (var countOfSlot = 0; countOfSlot < noOfTimeSlot; countOfSlot++)
            {
                Time t = new Time();

                Console.WriteLine("Please enter starting hours  in {0} timeslot:", countOfSlot);
                t.startHours = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter starting minutes in {0} timeslot:", countOfSlot);
                t.startMinute = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter ending hours  in {0} timeslot:", countOfSlot);
                t.endHours = int.Parse(Console.ReadLine());
                Console.WriteLine("Please enter ending minutes in {0} timeslot:", countOfSlot);
                t.endMinute = int.Parse(Console.ReadLine());
                t.flag = 0;
                givenTimeSlot.Add(t);
            }
            Console.WriteLine("Entered time slots are :");
            Console.WriteLine("\n");
            Console.WriteLine("Start Time\t\t End Time");
            foreach (var time in givenTimeSlot)
            {
                Console.Write(time.startHours + ":" + time.startMinute);
                Console.WriteLine("\t\t\t" + time.endHours + ":" + time.endMinute);
            }

            var result = p.overLap(givenTimeSlot);
            Console.WriteLine("Result time slots are :");
            Console.WriteLine("\n");
            Console.WriteLine("Start Time\t\t End Time");
            foreach (var time in result)
            {
                Console.Write(time.startHours + ":" + time.startMinute);
                Console.WriteLine("\t\t\t" + time.endHours + ":" + time.endMinute);
            }

        }
    }
}
