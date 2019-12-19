namespace AppSecrect.DataAccess.Mapping
{
    using AppSecrect.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("comments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(x => x.Alias).HasColumnName("alias");
            builder.Property(x => x.ColorProfileUsed).HasColumnName("colorProfileUsed");

            builder.Property(x => x.Create).HasColumnName("create");




            builder.OwnsOne(x => x.Description, description =>
            {
                description.Property(d => d.Value).HasColumnName("description");
            });
        }
    }
}
