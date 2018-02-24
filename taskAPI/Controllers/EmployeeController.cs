using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using Task.Common;

namespace taskAPI.Controllers
{
	public class EmployeeController : ApiController
	{
		List<BaseEmployee> _empList = new List<BaseEmployee>();

		[HttpGet]
		public Employees EmployeeList()
		{
			if (_empList != null)
			{
				PermanentEmployee _pe = new PermanentEmployee()
				{
					ID = 1,
					FirstName = "David",
					LastName = "Shaw",
					MonthlySalary = 500,
				};
				_pe.AnnualSalary = _pe.GetAnnualSalary();
				_empList.Add(_pe);

				PermanentEmployee _pe2 = new PermanentEmployee()
				{
					ID = 2,
					FirstName = "Paul",
					LastName = "Fisher",
					MonthlySalary = 600
				};
				_pe2.AnnualSalary = _pe.GetAnnualSalary();
				_empList.Add(_pe2);

				ContractEmployee _ce = new ContractEmployee()
				{
					ID = 3,
					FirstName = "Naveen",
					LastName = "Donepudi",
					HourlySalary = 8
				};
				_ce.AnnualSalary = _ce.GetAnnualSalary();
				_empList.Add(_ce);

				ContractEmployee _ce2 = new ContractEmployee()
				{
					ID = 4,
					FirstName = "Viswanath",
					LastName = "Mannam",
					HourlySalary = 10
				};
				_ce2.AnnualSalary = _ce2.GetAnnualSalary();
				_empList.Add(_ce2);

			}
			//return JsonConvert.SerializeObject(_empList);
			Employees employees = new Employees();
			employees.employeeList = _empList;
			return employees;
		}
	}
}
