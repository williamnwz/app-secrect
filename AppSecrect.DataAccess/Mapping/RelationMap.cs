namespace AppSecrect.DataAccess.Mapping
{
    using AppSecrect.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class RelationMap : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.ToTable("friends");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(x => x.FriendId).HasColumnName("friend");

            builder
                .HasOne(f => f.Me)
                .WithMany(mu => mu.MainUserFriends)
                .HasForeignKey(f => f.MeId).OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(f => f.FriendUser)
                .WithMany(mu => mu.Friends)
                .HasForeignKey(f => f.FriendId);



        }
    }
}
