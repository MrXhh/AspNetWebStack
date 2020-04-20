using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using WebApi.Filters;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            #region 管道

            config.MessageHandlers.Add(new ExceptionHandler());
            config.MessageHandlers.Add(new RequestDataFormatValidationHandler());

            #endregion

            #region 过滤器

            // 异常处理
            config.Filters.Add(new NotImplExceptionFilter());

            // 身份验证
            config.Filters.Add(new ApiAuthenticationFilter());

            #endregion

            // 跨域配置
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            #region Web API 路由

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            #endregion 

            #region 配置返回格式

            // 禁止返回xml，所以只返回json
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });   // 处理 DateTime 格式

            #endregion

        }
    }
}
