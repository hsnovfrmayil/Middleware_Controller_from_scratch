using System;
using System.Net;
using Example_Middleware.ActionResults;

namespace Example_Middleware.Controller;

public abstract class Controller
{
	public HttpListenerContext Context { get; set; }

	public IActionResult View()
	{
        ViewResult result = new ViewResult();
        result.ExecuteResult(Context);
        return result;
    }
}

