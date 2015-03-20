using System;
using System.Linq;
using System.Web.Mvc;
using ManagementSystem.Data;
using AutoMapper.QueryableExtensions;
using ManagementSystem.Data.Models;
using ManagementSystem.Web.ViewModels;
using AutoMapper;

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
            var allTasks = this.Data.Tasks
                .All()
                .Project()
                .To<TaskViewModel>();

            return View(allTasks);
        }

        //GET: Create task
        public ActionResult Create()
        {
            var complexModel = new ComplexViewModel();
            //TODO Write as SQL query
            complexModel.AllUsers = this.Data.Users
                .All()
                .Project()
                .To<UserViewModel>()
                .ToList();

            complexModel.TaskViewModel = new TaskViewModel();

            return View(complexModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ComplexViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var newTask = Mapper.Map<Task>(model.TaskViewModel);

                newTask.CreatedOnDate = DateTime.Now;

                foreach (var selectedUserId in model.SelectedUsersId)
                {
                    var user = this.Data.Users
                        .All()
                        .FirstOrDefault(u => u.Id == selectedUserId);

                    if (user != null)
                    {
                        newTask.AssignedToUsers.Add(user);
                    }
                }

                this.Data.Tasks.Add(newTask);
                this.Data.SaveChanges();
                TempData["Success"] = "A new task was created";
                return RedirectToAction("Index","Tasks");
            }

            return View(model);
        }
    }
}