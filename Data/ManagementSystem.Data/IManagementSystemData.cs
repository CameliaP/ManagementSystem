using ManagementSystem.Data.Common.Repository;
using ManagementSystem.Data.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace ManagementSystem.Data
{
    public interface IManagementSystemData
    {
        DbContext Context { get; }

        IRepository<User> Users { get; }

        IRepository<Task> Tasks { get; }

        IRepository<Comment> Comments { get; }
        
        void Dispose();

        int SaveChanges();
    }
}
