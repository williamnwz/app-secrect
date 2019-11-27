namespace AppSecrect.DataAccess.Mapping
{
    using AppSecrect.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.OwnsOne(x => x.Email, email =>
            {
                email.Property(e => e.Value).HasColumnName("email");
            });

            builder.OwnsOne(x => x.Login, login =>
            {
                login.Property(e => e.Value).HasColumnName("login");
            });

            builder.OwnsOne(x => x.Password, password =>
            {
                password.Property(e => e.Value).HasColumnName("password");
            });

            builder
                .HasMany(x => x.Posts)
                .WithOne(x=>x.Responsable)
                .HasForeignKey(x=>x.ResponsableId);

            builder.Property(x => x.FacebookId).HasColumnName("facebookId");
        }
    }
}
