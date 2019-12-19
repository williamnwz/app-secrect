namespace AppSecrect.DataAccess.Mapping
{
    using AppSecrect.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PostMap : IEntityTypeConfiguration<Post>
    {


        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("posts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(x => x.Alias).HasColumnName("alias");
            builder.Property(x => x.ColorProfileUsed).HasColumnName("colorProfileUsed");

            builder.OwnsOne(x => x.Description, description =>
            {
                description.Property(d => d.Value).HasColumnName("description");
            });

            builder.Property(x => x.Create).HasColumnName("create");
            builder.Property(x => x.ResponsableId).HasColumnName("responsableId");



            builder
                .HasMany(x => x.Comments)
                .WithOne(x => x.Post)
                .HasForeignKey(x => x.PostId);




        }
    }
}
