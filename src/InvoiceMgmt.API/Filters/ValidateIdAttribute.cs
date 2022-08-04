using InvoiceMgmt.API.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InvoiceMgmt.API.Filters
{
    public class ValidateIdAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            int routeId = (int)context.ActionArguments["id"];
            InvoiceChangeRequest model = (InvoiceChangeRequest)context.ActionArguments["input"];

            if (routeId != model.Id)
            {
                context.Result = new BadRequestObjectResult("[filter]Failed to match route parameter with model parameter");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}

