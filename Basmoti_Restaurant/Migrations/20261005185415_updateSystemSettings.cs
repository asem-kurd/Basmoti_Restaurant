using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Basmoti_Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class updateSystemSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SystemSettingLogoImageUrl",
                table: "SystemSettings");

            migrationBuilder.AlterColumn<string>(
                name: "SystemSettingLogoImageUrl2",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "SystemSettingLogoImageUrl1",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SystemSettingLogoImageUrl1",
                table: "SystemSettings");

            migrationBuilder.AlterColumn<string>(
                name: "SystemSettingLogoImageUrl2",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SystemSettingLogoImageUrl",
                table: "SystemSettings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
