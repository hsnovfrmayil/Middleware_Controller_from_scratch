using System;
using System.Net;
using System.Reflection;
using Lesson_2_Middleware.Middlewares.Abstracts;
namespace Example_Middleware.Controller;


public class MVCMiddleware : IMiddleware
{
    public HttpHandler? Next { get; set ; }

    public void Handler(HttpListenerContext context)
    {
        var url = context.Request.Url.AbsolutePath.Split("/",StringSplitOptions.RemoveEmptyEntries);

        var controllerName = $"Example_Middleware.Controller.{url[0]}Controller";


        Assembly assembly = Assembly.GetExecutingAssembly();
        Type? type = assembly.GetType(controllerName);


        if(type is not null)
        {
            var controllerOBJ = Activator.CreateInstance(type) as Controller;

            if(controllerOBJ is not null)
            {
                var actionName = url[1];
                MethodInfo action= type.GetMethod(actionName);

                if(action is not null)
                {
                    controllerOBJ.Context = context;
                    action.Invoke(controllerOBJ, null);
                }
            }
        }
        Next?.Invoke(context);
    }
}

