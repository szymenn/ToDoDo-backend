using System;
using Microsoft.AspNetCore.Http;
using ToDoListApi.Helpers;

namespace ToDoListApi.Exceptions
{
    public class ResourceAlreadyExistsException : Exception
    {
        public int StatusCode { get; }
        public string ReasonPhrase { get;  }
        public ResourceAlreadyExistsException()
        {
            StatusCode = StatusCodes.Status409Conflict;
            ReasonPhrase = Constants.Conflict;
        }

        public ResourceAlreadyExistsException(string message)
            : base(message)
        {
            StatusCode = StatusCodes.Status409Conflict;
            ReasonPhrase = Constants.Conflict;
        }

        public ResourceAlreadyExistsException(string message, Exception inner)
            :base(message, inner)
        {
            StatusCode = StatusCodes.Status409Conflict;
            ReasonPhrase = Constants.Conflict;
        }
    }
}