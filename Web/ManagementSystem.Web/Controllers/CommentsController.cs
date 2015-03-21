using AutoMapper;
using ManagementSystem.Data;
using ManagementSystem.Data.Models;
using ManagementSystem.Web.Infrastructure.Sanitizer;
using ManagementSystem.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementSystem.Web.Controllers
{
    public class CommentsController : BaseController
    {
        private readonly ISanitizer sanitizer;

        public CommentsController(ManagementSystemData data, ISanitizer sanitizer)
            : base(data)
        {
            this.sanitizer = sanitizer;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Add(int taskId, CommentViewModel comment)
        {
            if (comment != null && ModelState.IsValid)
            {
                if (this.sanitizer.Sanitize(comment.Content) != comment.Content)
                {
                    return this.JsonError("Your comment contains potentially dangerous code. Edit it.");
                }

                var newComment = new Comment();

                newComment.DateAdded = DateTime.Now;
                newComment.Type = CommentType.Note;
                newComment.Author = this.UserProfile;
                newComment.TaskId = taskId;
                newComment.Content = comment.Content;

                this.Data.Comments.Add(newComment);
                this.Data.SaveChanges();

                comment.AuthorName = this.UserProfile.UserName;
                comment.DateAdded = DateTime.Now;

                return PartialView("_CommentPartialView", comment);
            }

            return this.JsonError("Unexpexted error");
        }
    }
}