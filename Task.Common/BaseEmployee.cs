using System;

namespace Task.Common
{
	public class BaseEmployee
	{
		public int ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public int AnnualSalary { get; set; }

		public string GetFullName()
		{
			return this.FirstName + " " + LastName;
		}

		public virtual int GetAnnualSalary()
		{
			throw new NotImplementedException();
		}
	}
}
