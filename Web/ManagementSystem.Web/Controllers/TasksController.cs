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
                .To<TaskViewModel>()
                .ToList();

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

        //GET: Edit task
        public ActionResult Edit(int id)
        {
            var existingTaskModel = this.Data.Tasks
                .All()
                .Where(t => t.Id == id)
                .Project()
                .To<TaskViewModel>()
                .FirstOrDefault();

            if (existingTaskModel == null)
            {
                return new HttpNotFoundResult("Task not found");
            }

            //TODO If allowed to add additional properties

            //if (existingTaskModel.Author != this.UserProfile.UserName)
            //{
            //    return new HttpNotFoundResult("You are not the author of this task!");
            //}

            return View(existingTaskModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TaskViewModel taskModel)
        {
            if (taskModel != null && ModelState.IsValid)
            {
                var existingTask = this.Data
                   .Tasks
                   .GetById(taskModel.Id);

                existingTask.Description = taskModel.Description;
                existingTask.NextActionDate = taskModel.NextActionDate;
                existingTask.Type = taskModel.Type;
                existingTask.Status = taskModel.Status;

                //existingTask.Comments = this.Data.Comments
                //    .All()
                //    .Where(r => r.TaskId == existingTask.Id)
                //    .ToList();

                this.Data.Tasks.Update(existingTask);
                this.Data.SaveChanges();
                TempData["Success"] = "The task was changed successfuly";
                return RedirectToAction("Index", "Tasks");
            }

            return View(taskModel);
        }


        //GET: Delete task
        public ActionResult Delete(int id)
        {
            var existingTaskModel = this.Data.Tasks
                .All()
                .Where(t => t.Id == id)
                .Project()
                .To<TaskViewModel>()
                .FirstOrDefault();

            if (existingTaskModel == null)
            {
                return new HttpNotFoundResult("Task not found");
            }

            //TODO If allowed to add additional properties

            //if (existingTaskModel.Author != this.UserProfile.UserName)
            //{
            //    return new HttpNotFoundResult("You are not the author of this task!");
            //}

            return View(existingTaskModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TaskViewModel taskModel)
        {
            if (taskModel != null && ModelState.IsValid)
            {
                var existingTask = this.Data
                   .Tasks
                   .GetById(taskModel.Id);

                //existingTask.Comments = this.Data.Comments
                //    .All()
                //    .Where(r => r.TaskId == existingTask.Id)
                //    .ToList();

                this.Data.Tasks.Delete(existingTask);
                this.Data.SaveChanges();
                TempData["Success"] = "The task was deleted successfuly";
                return RedirectToAction("Index", "Tasks");
            }

            return View(taskModel);
        }

        //GET: Edit task
        public ActionResult Details(int id)
        {
            var existingTaskModel = this.Data.Tasks
                .All()
                .Where(t => t.Id == id)
                .Project()
                .To<TaskViewModel>()
                .FirstOrDefault();

            if (existingTaskModel == null)
            {
                return new HttpNotFoundResult("Task not found");
            }

            //TODO If allowed to add additional properties

            //if (existingTaskModel.Author != this.UserProfile.UserName)
            //{
            //    return new HttpNotFoundResult("You are not the author of this task!");
            //}

            return View(existingTaskModel);
        }
    }
}