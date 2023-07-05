using Microsoft.AspNetCore.Mvc.Filters;

namespace HMSUserAPI.Utility
{
    public class ResultFIlter : Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var headerName = "APIName";
            var headerValue = new string[] { "HMSUserAPI" };
            context.HttpContext.Response.Headers.Add(headerName, headerValue);
        }
    }
}
