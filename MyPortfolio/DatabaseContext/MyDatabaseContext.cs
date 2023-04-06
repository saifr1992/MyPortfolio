using System;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Entities;

namespace MyPortfolio.DatabaseContext
{
	public class MyDatabaseContext : DbContext
	{
		public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options) : base(options)
		{}

		public DbSet<AboutEntity> Abouts { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
    }
}

