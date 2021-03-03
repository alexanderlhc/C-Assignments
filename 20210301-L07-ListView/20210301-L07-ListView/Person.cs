using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20210301_L07_ListView
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public int Score { get; set; }

        public string Print { get { return this.ToString(); } }

        public Person(string name, int age, double weight, int score)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Score = score;
        }

        public override string ToString() => $"{Name} is {Age} old and wieghs {Weight} and scored {Score}";

    }
}
