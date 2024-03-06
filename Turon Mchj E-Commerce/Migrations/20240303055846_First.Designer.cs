using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Turon_Mchj_E_Commerce.DataBase;

#nullable disable

namespace Turon_Mchj_E_Commerce.Migrations
{
    [DbContext(typeof(TuronDbContext))]
    [Migration("20240303055846_First")]
    partial class First
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Turon_Mchj_E_Commerce.Entities.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Condition")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("OrderDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid?>("ShoppingListId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ShoppingListId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Turon_Mchj_E_Commerce.Entities.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("ExpirationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal");

                    b.Property<DateTimeOffset>("ProducedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ProducedPlace")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Turon_Mchj_E_Commerce.Entities.Models.ShoppingList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ShoppingLists");
                });

            modelBuilder.Entity("Turon_Mchj_E_Commerce.Entities.Models.Order", b =>
                {
                    b.HasOne("Turon_Mchj_E_Commerce.Entities.Models.ShoppingList", null)
                        .WithMany("OrderList")
                        .HasForeignKey("ShoppingListId");
                });

            modelBuilder.Entity("Turon_Mchj_E_Commerce.Entities.Models.ShoppingList", b =>
                {
                    b.Navigation("OrderList");
                });
#pragma warning restore 612, 618
        }
    }
}
