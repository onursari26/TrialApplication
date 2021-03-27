using Microsoft.AspNetCore.Http;
using Serilog.Core;
using System;
using System.Diagnostics;
using System.Linq;

namespace Application.Logging.Middleware
{
    public class HttpContextEnricher : ILogEventEnricher
    {
        public void Enrich(Serilog.Events.LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (AppServiceLocator.Instance != null)
            {
                IHttpContextAccessor _httpContext = (IHttpContextAccessor)AppServiceLocator.Instance.GetService(typeof(IHttpContextAccessor));
                if (_httpContext != null)
                {
                    logEvent.AddPropertyIfAbsent(
                        propertyFactory.CreateProperty("LocalIdentifier", Guid.NewGuid(), false));

                    if (_httpContext.HttpContext != null)
                    {
                        logEvent.AddPropertyIfAbsent(
                            propertyFactory.CreateProperty("TraceIdentifier", _httpContext.HttpContext.TraceIdentifier, false));

                        logEvent.AddPropertyIfAbsent(
                            propertyFactory.CreateProperty("RemoteIpAddress", _httpContext.HttpContext.Connection.RemoteIpAddress, false));

                        logEvent.AddPropertyIfAbsent(
                            propertyFactory.CreateProperty("Method", _httpContext.HttpContext.Request.Method, false));

                        logEvent.AddPropertyIfAbsent(
                            propertyFactory.CreateProperty("Path", _httpContext.HttpContext.Request.Path, false));
                    }

                    logEvent.AddPropertyIfAbsent(
                        propertyFactory.CreateProperty("MachineName", System.Net.Dns.GetHostName(), false));

                    if (logEvent.Exception != null)
                    {
                        StackTrace stackTrace = new StackTrace(logEvent.Exception, true);

                        if (stackTrace != null)
                        {
                            StackFrame stackFrame = stackTrace.GetFrames().FirstOrDefault();

                            logEvent.AddPropertyIfAbsent(
                                    propertyFactory.CreateProperty("FileLineNumber", stackFrame.GetFileLineNumber(), false));

                            logEvent.AddPropertyIfAbsent(
                                propertyFactory.CreateProperty("FileColumnNumber", stackFrame.GetFileColumnNumber(), false));

                            logEvent.AddPropertyIfAbsent(
                                propertyFactory.CreateProperty("FileName", stackFrame.GetFileName(), false));
                        }
                    }
                }
            }
        }
    }
}
