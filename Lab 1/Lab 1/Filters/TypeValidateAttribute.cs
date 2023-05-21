using Lab_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab_1.Filters;

public class TypeValidateAttribute: ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        Car _car = context.ActionArguments["NewCar"] as Car;  // normal casting is not safe
        var allowedType = new string[]
        {
            "Electric",
            "Gas",
            "Diesel",
            "Hybrid"
        };
        if (_car == null || !allowedType.Contains(_car.Type))
        {
            // short circle and send bad request
            context.Result = new BadRequestObjectResult(new GeneralResponse("Location is not covered!"));
        }
    }
}
