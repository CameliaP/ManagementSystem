using ManagementSystem.Data.Common.Repository;
using ManagementSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Data
{
    public interface IManagementSystemData
    {
        DbContext Context { get; }

        IRepository<User> Users { get; }
        
        void Dispose();

        int SaveChanges();
    }
}
