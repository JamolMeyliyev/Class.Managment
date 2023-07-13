
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore;
using Account.API.Context;

namespace Marketplace.Service.Identity.Migrations
{
	[DbContext(typeof(IdentityDbContext))]
	[Migration("2023_Init")]
	partial class Init
	{
		/// <inheritdoc />
		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("ProductVersion", "7.0.5")
				.HasAnnotation("Relational:MaxIdentifierLength", 63);

			NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

			modelBuilder.Entity("Identity.Core.Entites.User", b =>
			{
				b.Property<Guid>("Id")
					.ValueGeneratedOnAdd()
					.HasColumnType("uuid");

				b.Property<string>("Name")
					.HasColumnType("text");

				b.Property<string>("PasswordHash")
					.IsRequired()
					.HasColumnType("text");

				b.Property<string>("UserName")
					.IsRequired()
					.HasColumnType("text");

				b.HasKey("Id");

				b.ToTable("Users");
			});
#pragma warning restore 612, 618
		}
	}
}