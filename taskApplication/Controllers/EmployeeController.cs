using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using Task.Common;

namespace taskApplication.Controllers
{
	public class EmployeeController : Controller
	{

		string baseURL = "http://localhost:51435/";
		[HttpGet]
		public async Task<ActionResult> Index()
		{
			List<Employees> list = new List<Employees>();
			var employees = new Employees();
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(baseURL);
				client.DefaultRequestHeaders.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				HttpResponseMessage Res = await client.GetAsync("api/Employee/EmployeeList");

				if (Res.IsSuccessStatusCode)
				{
					var EmpResponse = Res.Content.ReadAsStringAsync().Result;
					employees = JsonConvert.DeserializeObject<Employees>(EmpResponse);
				}
			}
			Session["Employees"] = employees;
			return View(employees);
		}

		public ActionResult populateGrid(int? employeeID)
		{
			List<BaseEmployee> EMPinfo = new List<BaseEmployee>();
			if (employeeID.HasValue)
			{
				var employees = (Employees)Session["Employees"];
				BaseEmployee filteredEmployee = employees.employeeList.Find(emp => emp.ID == employeeID);
				if (filteredEmployee != null)
					EMPinfo.Add(filteredEmployee);
				return PartialView("_EmployeeList", EMPinfo);
			}
			else
			{
				var employees = (Employees)Session["Employees"];
				EMPinfo = employees.employeeList;
				return PartialView("_EmployeeList", EMPinfo);
			}
		}
	}
}