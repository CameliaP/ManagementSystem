using System;
using System.Linq;
using System.Web.Mvc;
using ManagementSystem.Data;

namespace ManagementSystem.Web.Controllers
{
    public class TasksController : BaseController
    {
        public TasksController(ManagementSystemData data)
            : base(data)
        {
        }

        // GET: Tasks
        public ActionResult Index()
        {
            return View();
        }
    }
}