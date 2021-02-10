using System;
using System.Collections.Generic;

namespace _20210208_L03_TimeStruct
{
    public struct Time
    {

        public Time(string timeIn)
        {
            try {
              Hours   = Int32.Parse(timeIn.Substring(0, 2));
              Minutes = Int32.Parse(timeIn.Substring(3, 2));
              Seconds = Int32.Parse(timeIn.Substring(6, 2));
            }
            catch (Exception e)
            {
              throw new ArgumentException("Format should be: `HH:MM:SS`");
            }
        }

        public Time(int hours, int minutes, int seconds)
        {
            Hours   = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public override string ToString()
        {
          return String.Format("{0}:{1}:{2}", Hours.ToString("00"), Minutes.ToString("00"), Seconds.ToString("00"));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
          List<Time> times = new List<Time>() {
            new Time("00:88:32"), new Time(12,04,39), new Time(1,2,3)
          };

          foreach (Time time in times)
          {
              System.Console.WriteLine(time.ToString());
          }
        }
    }
}
