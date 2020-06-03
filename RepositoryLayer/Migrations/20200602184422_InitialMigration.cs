using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuantityComparisions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    firstValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    firstValueQuantityUnit = table.Column<string>(nullable: false),
                    SecondValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SecondValueQuantityUnit = table.Column<string>(nullable: false),
                    Result = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantityComparisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuantityMeasure",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Operation = table.Column<string>(nullable: false),
                    Result = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuantityMeasure", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuantityComparisions");

            migrationBuilder.DropTable(
                name: "QuantityMeasure");
        }
    }
}
