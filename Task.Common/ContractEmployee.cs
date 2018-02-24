namespace Task.Common
{
	public class ContractEmployee : BaseEmployee
	{
		public int HourlySalary { get; set; }

		public override int GetAnnualSalary()
		{
			return this.HourlySalary * 120 * 12;
		}
	}
}
