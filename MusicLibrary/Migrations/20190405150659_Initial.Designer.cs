﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MusicLibrary.Models;
using System;

namespace MusicLibrary.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190405150659_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MusicLibrary.Models.Login", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("id");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("MusicLibrary.Models.Song", b =>
                {
                    b.Property<int>("SongID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Album");

                    b.Property<string>("Artist");

                    b.Property<string>("Genre");

                    b.Property<string>("Title");

                    b.HasKey("SongID");

                    b.ToTable("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}
