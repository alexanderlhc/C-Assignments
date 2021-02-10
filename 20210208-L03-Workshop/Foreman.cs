

namespace Ex3
{
    class Foreman : Mechanic
    {
      public readonly int PromotionYear;
      public uint WageBonus { get; set; }

      public Foreman(string name, string address, int graduationYear, uint hourlyWage, int promotionYear, uint wageBonus) : base(name, address, graduationYear, hourlyWage)
      {
        PromotionYear = promotionYear;
        WageBonus = wageBonus;
      }

      public override double getSalary()
      {
        return base.getSalary() + WageBonus;
      }
    }
}
