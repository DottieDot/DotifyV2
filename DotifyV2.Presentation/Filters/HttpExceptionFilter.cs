using DotifyV2.Presentation.Exceptions;
using DotifyV2.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotifyV2.Presentation.Filters
{
    public class HttpExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(HttpException))
            {
                var result = new ObjectResult(new ErrorResult
                {
                    Error = context.Exception.Message
                });

                context.Result = result;
            }
        }
    }
}
