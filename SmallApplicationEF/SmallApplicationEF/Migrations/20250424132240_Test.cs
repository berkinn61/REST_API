using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmallApplicationEF.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People");

            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "Persons");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Persons",
                newName: "PLZ");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Persons",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_People_CityId",
                table: "Persons",
                newName: "IX_Persons_CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Cities_CityId",
                table: "Persons",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Cities_CityId",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "People");

            migrationBuilder.RenameColumn(
                name: "PLZ",
                table: "People",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "People",
                newName: "FirstName");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_CityId",
                table: "People",
                newName: "IX_People_CityId");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "People",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Cities_CityId",
                table: "People",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
