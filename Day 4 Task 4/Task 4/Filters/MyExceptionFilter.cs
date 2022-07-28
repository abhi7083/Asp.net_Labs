using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using log4net;
namespace WebApplication6.filter
{
    public class MyExceptionFilter : IExceptionFilter
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(MyExceptionFilter));
        public void OnException(ExceptionContext context)
        {
            string ctrlName = context.RouteData.Values["Controller"].ToString();
            string actName = context.RouteData.Values["Action"].ToString();

            _logger.Error("Exception Occured in controller :" + ctrlName + ",Action :" +actName);
            _logger.Error("Message :" + context.Exception.Message);

            context.ExceptionHandled = true;

            context.Result = new ViewResult() { ViewName = "CustomError" };
        }
    }
}
