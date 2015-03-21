using AutoMapper;
using ManagementSystem.Data.Models;
using System;
using System.Linq;
using ManagementSystem.Web.Infrastructure.Mapping;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Web.ViewModels
{
    public class TaskViewModel : IMapFrom<Task>, IHaveCustomMappings
    {
       
        public int Id { get; set; }

        public DateTime CreatedOnDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime RequiredByDate { get; set; }

        public DateTime? NextActionDate { get; set; }

        [Required]
        public string Description { get; set; }

        public TaskStatus Status { get; set; }

        public TaskType Type { get; set; }

        public ICollection<User> AssignedToUsers { get; set; }

        public IList<CommentViewModel> Comments { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Task, TaskViewModel>()
                .ReverseMap();
        }
    }
}