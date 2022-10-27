using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MetaSolution.AppAdmin.Controllers
{
	public class BaseController : Controller
	{
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var sessions = context.HttpContext.Session.GetString("Token");
            if (sessions == null)
            {
                context.Result = new RedirectResult("/dang-nhap");
            }
            base.OnActionExecuting(context);
        }
    }
}
