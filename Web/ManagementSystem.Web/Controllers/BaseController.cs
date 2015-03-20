using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManagementSystem.Data;
using ManagementSystem.Data.Models;
using System.Web.Routing;

namespace ManagementSystem.Web.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(ManagementSystemData data)
        {
            this.Data = data;
        }

        protected ManagementSystemData Data { get; private set; }

        protected User UserProfile { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            
            this.UserProfile = this.Data.Users.All().Where(u => u.UserName == requestContext.HttpContext.User.Identity.Name).FirstOrDefault();

            return base.BeginExecute(requestContext, callback, state);
        }

    }
}