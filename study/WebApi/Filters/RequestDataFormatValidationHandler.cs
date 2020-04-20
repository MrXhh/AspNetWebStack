using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Filters
{
    /// <summary> 请求数据格式校验
    /// </summary>
    public class RequestDataFormatValidationHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage pHttpRequestMessage, CancellationToken pCancellationToken)
        {
            var requestStringContent = pHttpRequestMessage.Content.ReadAsStringAsync().Result;

            return base.SendAsync(pHttpRequestMessage, pCancellationToken);
        }

    }
}