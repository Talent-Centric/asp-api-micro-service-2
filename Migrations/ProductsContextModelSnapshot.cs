// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace aspcoreapiapp.Migrations
{
    [DbContext(typeof(ProductsContext))]
    partial class ProductsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("Products", b =>
                {
                    b.Property<int>("PId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("PDescription")
                        .HasColumnType("text");

                    b.Property<string>("PName")
                        .HasColumnType("text");

                    b.Property<decimal>("PPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("PQuantity")
                        .HasColumnType("int");

                    b.Property<string>("PType")
                        .HasColumnType("text");

                    b.HasKey("PId");

                    b.ToTable("products");
                });
#pragma warning restore 612, 618
        }
    }
}
