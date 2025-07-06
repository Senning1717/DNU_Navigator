using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DnuNavigator.Migrations
{
    /// <inheritdoc />
    public partial class AddImageUrlToSubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Subjects");
        }
    }
}
