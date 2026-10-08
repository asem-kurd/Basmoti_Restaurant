using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basmoti_Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class fixSystemSettingColmns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SystemSettingSocialMediaIcon",
                table: "SystemSettings");

            migrationBuilder.DropColumn(
                name: "SystemSettingSocialMediaIconUrl",
                table: "SystemSettings");

            migrationBuilder.AlterColumn<string>(
                name: "MasterWhatPeopleSayImageUrl",
                table: "MasterWhatPeopleSay",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SystemSettingSocialMediaIcon",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SystemSettingSocialMediaIconUrl",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "MasterWhatPeopleSayImageUrl",
                table: "MasterWhatPeopleSay",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
