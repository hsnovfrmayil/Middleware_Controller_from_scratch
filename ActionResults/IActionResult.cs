using System;
using System.Net;

namespace Example_Middleware.ActionResults;

public interface IActionResult
{
    public void ExecuteResult(HttpListenerContext context);
}

