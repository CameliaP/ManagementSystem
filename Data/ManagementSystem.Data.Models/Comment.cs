using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ManagementSystem.Data.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public CommentType Type { get; set; }

        public DateTime ReminderDate { get; set; }

        public int TaskId { get; set; }

        public virtual Task Task { get; set; }
    }
}
