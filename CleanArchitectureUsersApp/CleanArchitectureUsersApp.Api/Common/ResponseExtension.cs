using Microsoft.AspNetCore.Mvc;
using CleanArchitectureUsersApp.Application.Mapping;

namespace CleanArchitectureUsersApp.Api.Common
{
    public static class ResponseExtension
    {
        public static ActionResult ToActionResult<TValue>(this ApplicationResult<TValue> result, ControllerBase controller) where TValue : class
        {
            var response = new Response<TValue>(result);
            if (result.HasError)
                return controller.BadRequest(response);

            return controller.Ok(response);
        }
    }
}
