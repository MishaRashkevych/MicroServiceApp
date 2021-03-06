// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaAPIProject.Models;

namespace PizzaAPIProject.Migrations
{
    [DbContext(typeof(PizzaContext))]
    [Migration("20211005081757_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PizzaAPIProject.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Crust")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVeg")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Speciality")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Crust = "Meat",
                            IsVeg = false,
                            Name = "Margherita",
                            Picture = "",
                            Price = 20.0,
                            Speciality = "Plain"
                        },
                        new
                        {
                            Id = 2,
                            Crust = "Standart",
                            IsVeg = true,
                            Name = "Cheese N Corn",
                            Picture = "",
                            Price = 25.0,
                            Speciality = "Cheezy"
                        },
                        new
                        {
                            Id = 3,
                            Crust = "Cheezy",
                            IsVeg = false,
                            Name = "Chicken Pepperoni",
                            Picture = "",
                            Price = 20.0,
                            Speciality = "Spicy"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
