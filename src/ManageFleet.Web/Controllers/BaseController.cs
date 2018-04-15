using ManageFleet.Infra.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ManageFleet.Web.Controllers
{
    public class BaseController : Controller
    {
        protected StatusCodeResult HttpStatusCodeResult(HttpStatusCode statusCode)
        {
            return new StatusCodeResult((int)statusCode);
        }

        protected void AddTempData(string key, object value)
        {
            if (key.IsNull())
                return;

            TempData[key] = value;
        }

        protected T GetTempData<T>(string key)
        {
            if (key.IsNull())
                return default(T);

            if (!TempData[key].IsNull())
                return default(T);

            return (T)TempData[key];
        }
        
        protected void AddViewData(string key, object value)
        {
            if (key.IsNull())
                return;

            ViewData[key] = value;
        }
        
        protected T GetViewData<T>(string key)
        {
            if (key.IsNull())
                return default(T);

            if (!TempData[key].IsNull())
                return default(T);

            return (T)ViewData[key];
        }
    }
}