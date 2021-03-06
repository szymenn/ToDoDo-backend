using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListApi.Exceptions;
using ToDoListApi.Helpers;

namespace ToDoListApi.Extensions
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var problemDetails = new ProblemDetails
            {
                Instance = $"urn:todolistapp:{Guid.NewGuid()}"
            };
            try
            {
                await _next(context);
            }
            catch (ResourceNotFoundException notFoundException)
            {
                problemDetails.Status = notFoundException.StatusCode;
                problemDetails.Title = notFoundException.ReasonPhrase;
                problemDetails.Detail = notFoundException.Message;
                context.Response.StatusCode = problemDetails.Status.Value;
                context.Response.WriteJson(problemDetails);
            }
            catch (ResourceAlreadyExistsException alreadyExistsException)
            {
                problemDetails.Status = alreadyExistsException.StatusCode;
                problemDetails.Title = alreadyExistsException.ReasonPhrase;
                problemDetails.Detail = alreadyExistsException.Message;
                context.Response.StatusCode = problemDetails.Status.Value;
                context.Response.WriteJson(problemDetails);
            }
            catch (LoginException loginException)
            {
                problemDetails.Status = loginException.StatusCode;
                problemDetails.Title = loginException.ReasonPhrase;
                problemDetails.Detail = loginException.Message;
                context.Response.StatusCode = problemDetails.Status.Value;
                context.Response.WriteJson(problemDetails);
            }
            catch (RegistrationException registrationException)
            {
                problemDetails.Status = registrationException.StatusCode;
                problemDetails.Title = registrationException.ReasonPhrase;
                problemDetails.Detail = registrationException.Message;
                context.Response.StatusCode = problemDetails.Status.Value;
                context.Response.WriteJson(problemDetails);
            }
            catch (EmailVerificationException verificationException)
            {
                problemDetails.Status = verificationException.StatusCode;
                problemDetails.Title = verificationException.ReasonPhrase;
                problemDetails.Detail = verificationException.Message;
                context.Response.StatusCode = problemDetails.Status.Value;
                context.Response.WriteJson(problemDetails);
            }
            catch (EmailSenderException senderException)
            {
                problemDetails.Status = senderException.StatusCode;
                problemDetails.Title = senderException.ReasonPhrase;
                problemDetails.Detail = senderException.Message;
                context.Response.StatusCode = problemDetails.Status.Value;
                context.Response.WriteJson(problemDetails);
            }
            catch (Exception)
            {
                problemDetails.Status = StatusCodes.Status500InternalServerError;
                problemDetails.Title = Constants.InternalServerError;
                problemDetails.Detail = Constants.InternalServerErrorDetail;
                context.Response.StatusCode = problemDetails.Status.Value;
                context.Response.WriteJson(problemDetails);
            }
        }
    }
}