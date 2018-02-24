namespace Task.Common
{
	public class PermanentEmployee : BaseEmployee
	{
		public int MonthlySalary { get; set; }

		public override int GetAnnualSalary()
		{
			return this.MonthlySalary * 12;
		}
	}
}
