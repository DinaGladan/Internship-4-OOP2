using Microsoft.AspNetCore.Mvc;
using CleanArchitectureUsersApp.Domain.Common.Model;

namespace CleanArchitectureUsersApp.Api.Common
{
    public static class ResponseExtension
    {
        public static ActionResult ToActionResult<T>(this Result<T> result, ControllerBase controller)
        {
            if (result.ResultValidation.HasError)
                return controller.BadRequest(result);

            return controller.Ok(result);
        }
    }
}
