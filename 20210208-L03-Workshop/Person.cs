using System;

namespace Ex3 {

  public class Person
  {
    public string Name { get; set; }
    public string Address { get; set; }


    public Person(string name, string address)
    {
      Name = name;
      Address = address;
    }

    public override String ToString()
    {
      return String.Format("<{0}, {1}>", Name, Address);
    }
  }



}
