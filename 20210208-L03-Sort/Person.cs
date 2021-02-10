
namespace _20210208_L03_Sort
{
    class Person
    {
        public string Name { get; }
        public int Age { get; }

        public Person(string name, int age)
        {
          Name = name;
          Age = age;
        }

        public override string ToString()
        {
          return string.Format("({0},{1})", Name, Age);
        }

        public static int CompareByAge(Person p1,Person p2)
        {
          return p1.Age.CompareTo(p2.Age);
        }
    }
}
