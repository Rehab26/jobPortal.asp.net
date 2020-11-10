using Elmah;
using JobPortal.App.Models;
using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace JobPortal.App.App_Start
{
    public class UsageLoggingFilterAttribute : ActionFilterAttribute
    {
        Stopwatch stopwatch = new Stopwatch();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (stopwatch.IsRunning)
            {
                stopwatch.Restart();
            }
            else
            {
                stopwatch.Start();
            }
            base.OnActionExecuting(filterContext);
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            stopwatch.Stop();
            var descriptor = filterContext.ActionDescriptor;
            FileLogger.NLog($"{DateTime.Now}, {descriptor.ControllerDescriptor.ControllerName.Replace("Controller", string.Empty) + " Request"}, {descriptor.ActionName}, {filterContext.HttpContext.Request.Url.AbsoluteUri}, {stopwatch.ElapsedMilliseconds / 1000}");

            base.OnActionExecuted(filterContext);
        }
    }

    public class ElmahHandledErrorLoggerFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.ExceptionHandled)
                ErrorSignal.FromCurrentContext().Raise(context.Exception);
        }

    }
}