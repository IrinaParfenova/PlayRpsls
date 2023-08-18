using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PlayRpsls.Exceptions;

namespace PlayRpsls.Filters
{
	public class ExceptionActionFilter : ExceptionFilterAttribute
	{
		public override Task OnExceptionAsync(ExceptionContext context)
		{
			string errorMessage = context.Exception.ToString();
			
			if (context.Exception is RandomizerException)
			{
				context.HttpContext.Response.StatusCode = 503;
				errorMessage = context.Exception.Message;
			}
			else
			{
				context.HttpContext.Response.StatusCode = 500;
			}

			context.Result = new JsonResult(errorMessage);
			return base.OnExceptionAsync(context);
		}
	}
}
