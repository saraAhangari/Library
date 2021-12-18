using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication2.Migrations
{
    public partial class uploading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder) { }
        //    {
        //        migrationBuilder.DropForeignKey(
        //            name: "FK_BookAuthors_Authors_AuthorId1",
        //            table: "BookAuthors");

        //        migrationBuilder.DropForeignKey(
        //            name: "FK_BookAuthors_Books_Bookid",
        //            table: "BookAuthors");

        //        migrationBuilder.DropPrimaryKey(
        //            name: "PK_BookAuthors",
        //            table: "BookAuthors");

        //        migrationBuilder.DropIndex(
        //            name: "IX_BookAuthors_AuthorId1",
        //            table: "BookAuthors");

        //        migrationBuilder.DropIndex(
        //            name: "IX_BookAuthors_Bookid",
        //            table: "BookAuthors");

        //        migrationBuilder.DropColumn(
        //            name: "BookId",
        //            table: "BookAuthors");

        //        migrationBuilder.DropColumn(
        //            name: "AuthorId1",
        //            table: "BookAuthors");

        //        migrationBuilder.RenameColumn(
        //            name: "Bookid",
        //            table: "BookAuthors",
        //            newName: "BookId");

        //        migrationBuilder.AlterColumn<int>(
        //            name: "BookId",
        //            table: "BookAuthors",
        //            type: "int",
        //            nullable: false,
        //            defaultValue: 0,
        //            oldClrType: typeof(int),
        //            oldType: "int",
        //            oldNullable: true);

        //        migrationBuilder.AlterColumn<int>(
        //            name: "AuthorId",
        //            table: "BookAuthors",
        //            type: "int",
        //            nullable: false,
        //            defaultValue: 0,
        //            oldClrType: typeof(string),
        //            oldType: "nvarchar(max)",
        //            oldNullable: true);

        //        migrationBuilder.AddPrimaryKey(
        //            name: "PK_BookAuthors",
        //            table: "BookAuthors",
        //            columns: new[] { "BookId", "AuthorId" });

        //        migrationBuilder.CreateIndex(
        //            name: "IX_BookAuthors_AuthorId",
        //            table: "BookAuthors",
        //            column: "AuthorId");

        //        migrationBuilder.AddForeignKey(
        //            name: "FK_BookAuthors_Authors_AuthorId",
        //            table: "BookAuthors",
        //            column: "AuthorId",
        //            principalTable: "Authors",
        //            principalColumn: "Id",
        //            onDelete: ReferentialAction.Cascade);

        //        migrationBuilder.AddForeignKey(
        //            name: "FK_BookAuthors_Books_BookId",
        //            table: "BookAuthors",
        //            column: "BookId",
        //            principalTable: "Books",
        //            principalColumn: "id",
        //            onDelete: ReferentialAction.Cascade);
        //    }

        //    protected override void Down(MigrationBuilder migrationBuilder)
        //    {
        //        migrationBuilder.DropForeignKey(
        //            name: "FK_BookAuthors_Authors_AuthorId",
        //            table: "BookAuthors");

        //        migrationBuilder.DropForeignKey(
        //            name: "FK_BookAuthors_Books_BookId",
        //            table: "BookAuthors");

        //        migrationBuilder.DropPrimaryKey(
        //            name: "PK_BookAuthors",
        //            table: "BookAuthors");

        //        migrationBuilder.DropIndex(
        //            name: "IX_BookAuthors_AuthorId",
        //            table: "BookAuthors");

        //        migrationBuilder.RenameColumn(
        //            name: "BookId",
        //            table: "BookAuthors",
        //            newName: "Bookid");

        //        migrationBuilder.AlterColumn<string>(
        //            name: "AuthorId",
        //            table: "BookAuthors",
        //            type: "nvarchar(max)",
        //            nullable: true,
        //            oldClrType: typeof(int),
        //            oldType: "int");

        //        migrationBuilder.AlterColumn<int>(
        //            name: "Bookid",
        //            table: "BookAuthors",
        //            type: "int",
        //            nullable: true,
        //            oldClrType: typeof(int),
        //            oldType: "int");

        //        migrationBuilder.AddColumn<string>(
        //            name: "BookId",
        //            table: "BookAuthors",
        //            type: "nvarchar(450)",
        //            nullable: false,
        //            defaultValue: "");

        //        migrationBuilder.AddColumn<int>(
        //            name: "AuthorId1",
        //            table: "BookAuthors",
        //            type: "int",
        //            nullable: true);

        //        migrationBuilder.AddPrimaryKey(
        //            name: "PK_BookAuthors",
        //            table: "BookAuthors",
        //            column: "BookId");

        //        migrationBuilder.CreateIndex(
        //            name: "IX_BookAuthors_AuthorId1",
        //            table: "BookAuthors",
        //            column: "AuthorId1");

        //        migrationBuilder.CreateIndex(
        //            name: "IX_BookAuthors_Bookid",
        //            table: "BookAuthors",
        //            column: "Bookid");

        //        migrationBuilder.AddForeignKey(
        //            name: "FK_BookAuthors_Authors_AuthorId1",
        //            table: "BookAuthors",
        //            column: "AuthorId1",
        //            principalTable: "Authors",
        //            principalColumn: "Id",
        //            onDelete: ReferentialAction.Restrict);

        //        migrationBuilder.AddForeignKey(
        //            name: "FK_BookAuthors_Books_Bookid",
        //            table: "BookAuthors",
        //            column: "Bookid",
        //            principalTable: "Books",
        //            principalColumn: "id",
        //            onDelete: ReferentialAction.Restrict);
        //    }
        //}
    }
}
