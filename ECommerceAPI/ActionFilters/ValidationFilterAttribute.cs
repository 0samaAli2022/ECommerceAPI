using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerceAPI.ActionFilters;

public class ValidationFilterAttribute : IActionFilter
{
    public ValidationFilterAttribute()
    { }
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var action = context.RouteData.Values["action"];
        var controller = context.RouteData.Values["controller"];
        var param = context.ActionArguments.SingleOrDefault(x => x.Value.ToString().Contains("Dto")).Value;
        if (param is null)
        {
            context.Result = new BadRequestObjectResult($"Object is null. Controller:{controller}, action: {action}");
            return;
        }
        if (!context.ModelState.IsValid)
        {
            var messages = context.ModelState
              .SelectMany(modelState => modelState.Value.Errors)
              .Select(err => err.ErrorMessage)
              .ToList();
            context.Result = new UnprocessableEntityObjectResult(messages);
        }
    }
    public void OnActionExecuted(ActionExecutedContext context) { }
}
