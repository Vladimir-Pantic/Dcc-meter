using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euronet.Audit.Helpers
{
    public class StatusCodeHelper
    {
        public static int GetStatusCode(IActionResult actionResult)
        {
            if (actionResult is ObjectResult objectResult)
            {
                // ObjectResult allows setting the status code
                return objectResult.StatusCode ?? 200; // Default to 200 if not set
            }
            else if (actionResult is StatusCodeResult statusCodeResult)
            {
                // StatusCodeResult directly exposes the status code
                return statusCodeResult.StatusCode;
            }
            else if (actionResult is JsonResult jsonResult)
            {
                // JsonResult has a StatusCode property
                return jsonResult.StatusCode ?? 200; // Default to 200 if not set
            }
            else if (actionResult is RedirectResult redirectResult)
            {
                // RedirectResult uses 3xx status codes for redirects
                return redirectResult.GetStatusCode();// .StatusCode;
            }
            else if (actionResult is NotFoundResult)
            {
                return 404;
            }
            else if (actionResult is OkResult)
            {
                return 200;
            }
            else if (actionResult is CreatedResult)
            {
                return 201;
            }
            // Add checks for other action result types as needed
            else
            {
                return 200; // Default to 200 OK if no match is found
            }
        }
    }
}
