using System;
using System.Collections.Generic;
using System.Text;
using Domain.Context;
using Domain.Interfaces;

namespace Domain.Repository
{
    public class BaseRepository
    {
        protected readonly RepositoryContext Context;
        public BaseRepository(string connectionString, IRepositoryContextFactory contextFactory)
        {
            Context = (contextFactory as RepositoryContextFactory)?.CreateDbContext(connectionString);
        }
    }
}
