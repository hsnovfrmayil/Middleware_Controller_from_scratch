using System;
using System.Net;

namespace Example_Middleware.ActionResults;

public class ViewResult : IActionResult
{
    public void ExecuteResult(HttpListenerContext context)
    {
        var section = context.Request.Url?.AbsolutePath.Split("/", StringSplitOptions.RemoveEmptyEntries);

        var folderName = section[0];
        var fileName = section[1];

        var path = $"/Users/fermayilhesenov/Projects/Example_Middleware/Example_Middleware/Views/{folderName}/{fileName}.html";

        if (File.Exists(path))
        {
            context.Response.ContentType = "text/html";
            var bytes = File.ReadAllBytes(path);
            context.Response.OutputStream.Write(bytes,0,bytes.Length);
        }
    }
}

