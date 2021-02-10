
namespace Ex3
{
    class Inspector : Mechanic
    {
      public int Inspections { get; set; }
      private static int pricePerInspection = 290;

      public Inspector(string name, string address, int graduationYear, uint hourlyWage) : base(name, address, graduationYear, hourlyWage)
      {
        Inspections = 0;
      }


      public override double getSalary()
      {
        return base.getSalary() + Inspections * pricePerInspection;
      }
    }
}
