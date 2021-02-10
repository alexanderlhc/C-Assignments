using System;

namespace Ex3 {

  public class Mechanic : Person
  {
    public readonly int GraduationYear; // deviated from assignment
    public uint HourlyWage { get; set; }
    public double WorkHours { get; set; }

    public Mechanic(string name, string address, int graduationYear, uint hourlyWage) : base(name, address)
    {
      GraduationYear = graduationYear;
      HourlyWage = hourlyWage;
      WorkHours = 32;
    }

    public virtual double getSalary()
    {
      return HourlyWage * WorkHours;
    }

  }

}
