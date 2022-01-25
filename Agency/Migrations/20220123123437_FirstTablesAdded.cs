using Microsoft.EntityFrameworkCore.Migrations;

namespace Agency.Migrations
{
    public partial class FirstTablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Portfolios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 20, nullable: false),
                    SubTitle = table.Column<string>(maxLength: 80, nullable: false),
                    Image = table.Column<string>(nullable: true),
                    ImageTitle = table.Column<string>(maxLength: 20, nullable: false),
                    ImageDesc = table.Column<string>(maxLength: 20, nullable: false),
                    PorfolioName = table.Column<string>(maxLength: 20, nullable: false),
                    PortfolioSubTitle = table.Column<string>(maxLength: 80, nullable: false),
                    PortfolioDesc = table.Column<string>(maxLength: 300, nullable: false),
                    Client = table.Column<string>(maxLength: 20, nullable: false),
                    Category = table.Column<string>(maxLength: 20, nullable: false),
                    BtnText = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Portfolios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(maxLength: 20, nullable: false),
                    SubTitle = table.Column<string>(maxLength: 80, nullable: false),
                    Icon = table.Column<string>(nullable: false),
                    ServiceName = table.Column<string>(maxLength: 20, nullable: false),
                    ServiceDesc = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Portfolios");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
