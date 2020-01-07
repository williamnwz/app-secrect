﻿// <auto-generated />
using System;
using AppSecrect.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AppSecrect.DataAccess.Migrations
{
    [DbContext(typeof(AppSecrectContext))]
    [Migration("20191219153655_secretm")]
    partial class secretm
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("AppSecrect.Domain.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("Alias")
                        .HasColumnName("alias")
                        .HasColumnType("text");

                    b.Property<string>("ColorProfileUsed")
                        .HasColumnName("colorProfileUsed")
                        .HasColumnType("text");

                    b.Property<DateTime>("Create")
                        .HasColumnName("create")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ResponsableId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("ResponsableId");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("AppSecrect.Domain.Entities.Friend", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("FriendId")
                        .HasColumnName("friend")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("FriendId");

                    b.HasIndex("MeId");

                    b.ToTable("friends");
                });

            modelBuilder.Entity("AppSecrect.Domain.Entities.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("Alias")
                        .HasColumnName("alias")
                        .HasColumnType("text");

                    b.Property<string>("ColorProfileUsed")
                        .HasColumnName("colorProfileUsed")
                        .HasColumnType("text");

                    b.Property<DateTime>("Create")
                        .HasColumnName("create")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("ResponsableId")
                        .HasColumnName("responsableId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ResponsableId");

                    b.ToTable("posts");
                });

            modelBuilder.Entity("AppSecrect.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("uuid");

                    b.Property<string>("FacebookId")
                        .HasColumnName("facebookId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("AppSecrect.Domain.Entities.Comment", b =>
                {
                    b.HasOne("AppSecrect.Domain.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppSecrect.Domain.Entities.User", "Responsable")
                        .WithMany()
                        .HasForeignKey("ResponsableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("AppSecrect.Domain.ValueObjects.Description", "Description", b1 =>
                        {
                            b1.Property<Guid>("CommentId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .HasColumnName("description")
                                .HasColumnType("text");

                            b1.HasKey("CommentId");

                            b1.ToTable("comments");

                            b1.WithOwner()
                                .HasForeignKey("CommentId");
                        });
                });

            modelBuilder.Entity("AppSecrect.Domain.Entities.Friend", b =>
                {
                    b.HasOne("AppSecrect.Domain.Entities.User", "FriendUser")
                        .WithMany("Friends")
                        .HasForeignKey("FriendId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppSecrect.Domain.Entities.User", "Me")
                        .WithMany("MainUserFriends")
                        .HasForeignKey("MeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("AppSecrect.Domain.Entities.Post", b =>
                {
                    b.HasOne("AppSecrect.Domain.Entities.User", "Responsable")
                        .WithMany("Posts")
                        .HasForeignKey("ResponsableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("AppSecrect.Domain.ValueObjects.Description", "Description", b1 =>
                        {
                            b1.Property<Guid>("PostId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .HasColumnName("description")
                                .HasColumnType("text");

                            b1.HasKey("PostId");

                            b1.ToTable("posts");

                            b1.WithOwner()
                                .HasForeignKey("PostId");
                        });
                });

            modelBuilder.Entity("AppSecrect.Domain.Entities.User", b =>
                {
                    b.OwnsOne("AppSecrect.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .HasColumnName("email")
                                .HasColumnType("text");

                            b1.HasKey("UserId");

                            b1.ToTable("users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("AppSecrect.Domain.ValueObjects.Login", "Login", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .HasColumnName("login")
                                .HasColumnType("text");

                            b1.HasKey("UserId");

                            b1.ToTable("users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("AppSecrect.Domain.ValueObjects.Password", "Password", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .HasColumnName("password")
                                .HasColumnType("text");

                            b1.HasKey("UserId");

                            b1.ToTable("users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}