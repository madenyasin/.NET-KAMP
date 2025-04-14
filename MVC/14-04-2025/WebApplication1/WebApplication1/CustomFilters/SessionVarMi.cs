using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.CustomFilters
{
    public class SessionVarMi: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            int? uyeId = context.HttpContext.Session.GetInt32("Id");
            if (uyeId == null)
            {
                context.Result = new RedirectToActionResult("Login", "Galeri", null);
            }
        }
    }
}
