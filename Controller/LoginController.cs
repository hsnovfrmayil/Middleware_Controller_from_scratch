using System;
using Example_Middleware.ActionResults;

namespace Example_Middleware.Controller;

public class LoginController :Controller
{
	public IActionResult Index()
	{


		return View();
	}
}

