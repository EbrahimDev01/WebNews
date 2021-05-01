using Microsoft.EntityFrameworkCore.Migrations;

namespace WebNews.Migrations
{
    public partial class nullGroupIdAgain2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Groups_GroupId",
                table: "News");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "News",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_News_Groups_GroupId",
                table: "News",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_Groups_GroupId",
                table: "News");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Groups_GroupId",
                table: "News",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "GroupId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
