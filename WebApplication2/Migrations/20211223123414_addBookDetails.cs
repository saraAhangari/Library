using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class addBookDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookDetails",
                columns: table => new
                {
                    fileId = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryID = table.Column<int>(type: "int", nullable: false),
                    bookID = table.Column<int>(type: "int", nullable: false),
                    publisherID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookDetails", x => x.fileId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookDetails");
        }
    }
}
