using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ProjectEmployeeManagement.Controllers
    {
    public class ErrorController : Controller
        {
        [Route("/Error/{statusCode}")]
        public IActionResult Error( int statusCode )
            {
            switch (statusCode)
                {
                case 404:
                    ViewBag.ErrorMassage = "404 Error NotFound";
                    break;

                }
            return View("Error");
            }
        [AllowAnonymous]
        [Route("/ErrorException")]
        public IActionResult ErrorException()
            {
            //retreive the exception details
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            ViewBag.ExceptionPath = exceptionHandlerPathFeature.Path;
            ViewBag.ExceptionMassage = exceptionHandlerPathFeature.Error.Message;
            ViewBag.ExceptionStackTrace=exceptionHandlerPathFeature.Error.StackTrace;

            return View("ErrorException");
            }
        }
    }
