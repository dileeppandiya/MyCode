using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace MyCode.Helper
{
    /// <summary>
    /// DataLake Exception Handler.
    /// </summary>
    public class DataLakeExceptionHandler : ExceptionHandler
    {
        private class ErrorInformation
        {
            public string Message { get; set; }
            public DateTime ErrorDate { get; set; }
        }

        /// <summary>
        /// Handles unexpected exception.
        /// </summary>
        /// <param name="context">ExceptionHandlerContext</param>
        public override void Handle(ExceptionHandlerContext context)
        {
            //Return a DTO representing what happened
            context.Result = new ResponseMessageResult(context.Request.CreateResponse(HttpStatusCode.InternalServerError,
            new ErrorInformation { Message = "We apologize but an unexpected error occured. Please try again later.", ErrorDate = DateTime.UtcNow }));
        }
    }
}