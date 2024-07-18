using entities;
using Microsoft.EntityFrameworkCore;

namespace data
{
    public class Data : DbContext
    {
        public Data(DbContextOptions<Data> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserEntity>()
                .HasMany(user => user.Tasks)
                .WithOne(tasks => tasks.User)
                .HasForeignKey(task => task.UserId);
        }
    }
}
