// <auto-generated />
using System;
using CatalogApiProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CatalogApiProject.Migrations
{
    [DbContext(typeof(RecordsContext))]
    [Migration("20220706131754_builder-2")]
    partial class builder2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CatalogApiProject.Models.Artist", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("CatalogApiProject.Models.ArtistRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("ArtistId")
                        .HasColumnType("bigint");

                    b.Property<long?>("RecordId")
                        .HasColumnType("bigint");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<long?>("TrackId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.HasIndex("RecordId");

                    b.HasIndex("RoleId");

                    b.HasIndex("TrackId");

                    b.ToTable("ArtistRoles");
                });

            modelBuilder.Entity("CatalogApiProject.Models.Record", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Additional")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PublishedYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("CatalogApiProject.Models.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CatalogApiProject.Models.Track", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<TimeSpan?>("Duration")
                        .HasColumnType("time");

                    b.Property<long?>("RecordId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RecordId");

                    b.ToTable("Tracks");
                });

            modelBuilder.Entity("CatalogApiProject.Models.ArtistRole", b =>
                {
                    b.HasOne("CatalogApiProject.Models.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CatalogApiProject.Models.Record", null)
                        .WithMany("Artists")
                        .HasForeignKey("RecordId");

                    b.HasOne("CatalogApiProject.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CatalogApiProject.Models.Track", null)
                        .WithMany("Artists")
                        .HasForeignKey("TrackId");

                    b.Navigation("Artist");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CatalogApiProject.Models.Track", b =>
                {
                    b.HasOne("CatalogApiProject.Models.Record", null)
                        .WithMany("Tracks")
                        .HasForeignKey("RecordId");
                });

            modelBuilder.Entity("CatalogApiProject.Models.Record", b =>
                {
                    b.Navigation("Artists");

                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("CatalogApiProject.Models.Track", b =>
                {
                    b.Navigation("Artists");
                });
#pragma warning restore 612, 618
        }
    }
}
