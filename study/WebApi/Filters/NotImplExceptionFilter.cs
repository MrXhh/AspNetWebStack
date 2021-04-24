using System;
using System.Net.Http;
using System.Web.Http.Filters;

namespace WebApi.Filters
{
    public class NotImplExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext filterContext)
        {
            base.OnException(filterContext);

            filterContext.Response = ExceptionHandling(filterContext.Exception, filterContext.Response, filterContext.Request);
        }

        public static HttpResponseMessage ExceptionHandling(Exception exception, HttpResponseMessage httpResponseMessage, HttpRequestMessage httpRequestMessage)
        {
            if (httpResponseMessage == null)
            {
                httpResponseMessage = new HttpResponseMessage();
            }

            httpResponseMessage.Content = new StringContent(exception.Message);

            return httpResponseMessage;
        }

    }
}