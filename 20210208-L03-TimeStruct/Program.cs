using System;
using System.Collections.Generic;

namespace _20210208_L03_TimeStruct
{
    public struct Time
    {

        public Time(string timeIn)
        {
            try {
              int hours   = Int32.Parse(timeIn.Substring(0, 2));
              int minutes = Int32.Parse(timeIn.Substring(3, 2));
              int seconds = Int32.Parse(timeIn.Substring(6, 2));
              _secondsFromMidnight = ((hours * 60 * 60) + (minutes * 60) + seconds);
            }
            catch (Exception e)
            {
              throw new ArgumentException("Format should be: `HH:MM:SS`");
            }
        }

        public Time(int hours, int minutes, int seconds)
        {
          _secondsFromMidnight = ((hours * 60 * 60) + (minutes * 60) + seconds);
        }

        private int _secondsFromMidnight;
        public int Hours
        {
          get { return _secondsFromMidnight / (60 * 60); }
          set
          {
            int hours = _secondsFromMidnight / 60 * 60;
            _secondsFromMidnight = _secondsFromMidnight - hours + (value * 60 * 60);
          }
        }
        public int Minutes {
          get { return (_secondsFromMidnight % (60 * 60)) / 60; }
        }
        public int Seconds {
          get { return _secondsFromMidnight % 60; }
        }

        public override string ToString()
        {
          return String.Format("{0}:{1}:{2} - {3}", Hours.ToString("00"), Minutes.ToString("00"), Seconds.ToString("00"), _secondsFromMidnight);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
          List<Time> times = new List<Time>() {
            new Time("00:55:32"), new Time(12,04,39), new Time(1,2,3)
          };

          foreach (Time time in times)
          {
              System.Console.WriteLine(time.ToString());
          }
        }
    }
}
