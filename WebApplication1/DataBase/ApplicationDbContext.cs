using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using WebApplication1.DataBase.Entities;

namespace WebApplication1.DataBase
{
    public class ApplicationDbContext: DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<FormEntity> Forms { get; set; } = default!;
        public DbSet<UserEntity> Users { get; set; } = default!;
    }
}
