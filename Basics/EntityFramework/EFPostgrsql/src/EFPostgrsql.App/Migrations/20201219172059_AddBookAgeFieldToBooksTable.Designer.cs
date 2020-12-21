// <auto-generated />
using EFPostgrsql.App.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace EFPostgrsql.App.Migrations
{
  [DbContext(typeof(ApplicationDbContext))]
  [Migration("20201219172059_AddBookAgeFieldToBooksTable")]
  partial class AddBookAgeFieldToBooksTable
  {
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder
          .UseIdentityByDefaultColumns()
          .HasAnnotation("Relational:MaxIdentifierLength", 63)
          .HasAnnotation("ProductVersion", "5.0.1");

      modelBuilder.Entity("EFPostgrsql.App.Models.Author", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("integer")
                      .UseIdentityByDefaultColumn();

            b.Property<DateTime>("CreatedOn")
                      .HasColumnType("timestamp without time zone");

            b.Property<string>("Name")
                      .IsRequired()
                      .HasMaxLength(50)
                      .HasColumnType("character varying(50)");

            b.Property<DateTime>("UpdatedOn")
                      .HasColumnType("timestamp without time zone");

            b.HasKey("Id");

            b.ToTable("Authors");
          });

      modelBuilder.Entity("EFPostgrsql.App.Models.Book", b =>
          {
            b.Property<int>("Id")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("integer")
                      .UseIdentityByDefaultColumn();

            b.Property<int?>("AuthorId")
                      .HasColumnType("integer");

            b.Property<int>("BookAge")
                      .HasColumnType("integer");

            b.Property<DateTime>("CreatedOn")
                      .HasColumnType("timestamp without time zone");

            b.Property<string>("Description")
                      .IsRequired()
                      .HasMaxLength(50)
                      .HasColumnType("character varying(50)");

            b.Property<double>("FullPrice")
                      .HasColumnType("double precision");

            b.Property<string>("Title")
                      .IsRequired()
                      .HasMaxLength(50)
                      .HasColumnType("character varying(50)");

            b.Property<DateTime>("UpdatedOn")
                      .HasColumnType("timestamp without time zone");

            b.HasKey("Id");

            b.HasIndex("AuthorId");

            b.ToTable("Books");
          });

      modelBuilder.Entity("EFPostgrsql.App.Models.Book", b =>
          {
            b.HasOne("EFPostgrsql.App.Models.Author", "Author")
                      .WithMany("Books")
                      .HasForeignKey("AuthorId");

            b.Navigation("Author");
          });

      modelBuilder.Entity("EFPostgrsql.App.Models.Author", b =>
          {
            b.Navigation("Books");
          });
#pragma warning restore 612, 618
    }
  }
}
