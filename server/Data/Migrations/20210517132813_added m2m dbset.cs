using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Data.Migrations
{
    public partial class addedm2mdbset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCard_AspNetUsers_UserId",
                table: "UserCard");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCard_Cards_CardId",
                table: "UserCard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCard",
                table: "UserCard");

            migrationBuilder.RenameTable(
                name: "UserCard",
                newName: "UserCards");

            migrationBuilder.RenameIndex(
                name: "IX_UserCard_CardId",
                table: "UserCards",
                newName: "IX_UserCards_CardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCards",
                table: "UserCards",
                columns: new[] { "UserId", "CardId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserCards_AspNetUsers_UserId",
                table: "UserCards",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCards_Cards_CardId",
                table: "UserCards",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCards_AspNetUsers_UserId",
                table: "UserCards");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCards_Cards_CardId",
                table: "UserCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCards",
                table: "UserCards");

            migrationBuilder.RenameTable(
                name: "UserCards",
                newName: "UserCard");

            migrationBuilder.RenameIndex(
                name: "IX_UserCards_CardId",
                table: "UserCard",
                newName: "IX_UserCard_CardId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCard",
                table: "UserCard",
                columns: new[] { "UserId", "CardId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserCard_AspNetUsers_UserId",
                table: "UserCard",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCard_Cards_CardId",
                table: "UserCard",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
