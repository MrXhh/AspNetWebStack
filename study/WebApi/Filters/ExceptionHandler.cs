using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Filters
{
    /// <summary> 异常处理管道
    /// </summary>
    public class ExceptionHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage pHttpRequestMessage, CancellationToken pCancellationToken)
        {
            Task<HttpResponseMessage> respMess = null;
            try
            {
                respMess = base.SendAsync(pHttpRequestMessage, pCancellationToken);
            }
            catch (Exception ex)
            {
                respMess = Task.FromResult(NotImplExceptionFilter.ExceptionHandling(ex, respMess == null ? null : respMess.Result, pHttpRequestMessage));
            }

            return respMess;
        }
    }
}