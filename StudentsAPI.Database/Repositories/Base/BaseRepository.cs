using Microsoft.EntityFrameworkCore;
using StudentsAPI.Database.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentsAPI.Database.Repositories.Base
{
    public abstract class BaseRepository<T> where T : class
    {
        protected abstract DbSet<T> DbSet { get; }
        protected StudentsApiDbContext Context { get; }

        public BaseRepository(StudentsApiDbContext context)
        {
            Context = context;
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
