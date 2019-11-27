namespace AppSecrect.DataAccess
{
    using AppSecrect.CrossCutting.Settings;
    using AppSecrect.DataAccess.Mapping;
    using AppSecrect.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// DbContext
    /// </summary>
    public class AppSecrectContext : DbContext
    {
        private readonly AppSettings appSettings;

        public AppSecrectContext(DbContextOptions opt, AppSettings appSettings)
            : base(opt)
        {
            this.appSettings = appSettings;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Friend> Relations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(this.appSettings.Connection);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new RelationMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
