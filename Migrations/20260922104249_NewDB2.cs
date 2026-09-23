using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class NewDB2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ================= أعمدة جديدة على جداول موجودة أصلاً =================

            // MasterCategoryMenus
            migrationBuilder.AddColumn<bool>(name: "IsDelete", table: "MasterCategoryMenus", type: "bit", nullable: false, defaultValue: false);
            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "MasterCategoryMenus", type: "bit", nullable: false, defaultValue: true);
            migrationBuilder.AddColumn<int>(name: "CreateId", table: "MasterCategoryMenus", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(name: "CreateDate", table: "MasterCategoryMenus", type: "datetime2", nullable: false, defaultValueSql: "GETDATE()");
            migrationBuilder.AddColumn<int>(name: "UpdateId", table: "MasterCategoryMenus", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(name: "UpdateDate", table: "MasterCategoryMenus", type: "datetime2", nullable: false, defaultValueSql: "GETDATE()");

            // MasterMenus
            migrationBuilder.AddColumn<bool>(name: "IsDelete", table: "MasterMenus", type: "bit", nullable: false, defaultValue: false);
            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "MasterMenus", type: "bit", nullable: false, defaultValue: true);
            migrationBuilder.AddColumn<int>(name: "CreateId", table: "MasterMenus", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(name: "CreateDate", table: "MasterMenus", type: "datetime2", nullable: false, defaultValueSql: "GETDATE()");
            migrationBuilder.AddColumn<int>(name: "UpdateId", table: "MasterMenus", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(name: "UpdateDate", table: "MasterMenus", type: "datetime2", nullable: false, defaultValueSql: "GETDATE()");

            // MasterOffers
            migrationBuilder.AddColumn<bool>(name: "IsDelete", table: "MasterOffers", type: "bit", nullable: false, defaultValue: false);
            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "MasterOffers", type: "bit", nullable: false, defaultValue: true);
            migrationBuilder.AddColumn<int>(name: "CreateId", table: "MasterOffers", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(name: "CreateDate", table: "MasterOffers", type: "datetime2", nullable: false, defaultValueSql: "GETDATE()");
            migrationBuilder.AddColumn<int>(name: "UpdateId", table: "MasterOffers", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(name: "UpdateDate", table: "MasterOffers", type: "datetime2", nullable: false, defaultValueSql: "GETDATE()");

            // MasterPartners
            migrationBuilder.AddColumn<bool>(name: "IsDelete", table: "MasterPartners", type: "bit", nullable: false, defaultValue: false);
            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "MasterPartners", type: "bit", nullable: false, defaultValue: true);
            migrationBuilder.AddColumn<int>(name: "CreateId", table: "MasterPartners", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(name: "CreateDate", table: "MasterPartners", type: "datetime2", nullable: false, defaultValueSql: "GETDATE()");
            migrationBuilder.AddColumn<int>(name: "UpdateId", table: "MasterPartners", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(name: "UpdateDate", table: "MasterPartners", type: "datetime2", nullable: false, defaultValueSql: "GETDATE()");

            // MasterServices
            migrationBuilder.AddColumn<bool>(name: "IsDelete", table: "MasterServices", type: "bit", nullable: false, defaultValue: false);
            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "MasterServices", type: "bit", nullable: false, defaultValue: true);
            migrationBuilder.AddColumn<int>(name: "CreateId", table: "MasterServices", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(name: "CreateDate", table: "MasterServices", type: "datetime2", nullable: false, defaultValueSql: "GETDATE()");
            migrationBuilder.AddColumn<int>(name: "UpdateId", table: "MasterServices", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(name: "UpdateDate", table: "MasterServices", type: "datetime2", nullable: false, defaultValueSql: "GETDATE()");

            // MasterSliders
            migrationBuilder.AddColumn<bool>(name: "IsDelete", table: "MasterSliders", type: "bit", nullable: false, defaultValue: false);
            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "MasterSliders", type: "bit", nullable: false, defaultValue: true);
            migrationBuilder.AddColumn<int>(name: "CreateId", table: "MasterSliders", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(name: "CreateDate", table: "MasterSliders", type: "datetime2", nullable: false, defaultValueSql: "GETDATE()");
            migrationBuilder.AddColumn<int>(name: "UpdateId", table: "MasterSliders", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(name: "UpdateDate", table: "MasterSliders", type: "datetime2", nullable: false, defaultValueSql: "GETDATE()");

            // MasterSocialMedia
            migrationBuilder.AddColumn<bool>(name: "IsDelete", table: "MasterSocialMedia", type: "bit", nullable: false, defaultValue: false);
            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "MasterSocialMedia", type: "bit", nullable: false, defaultValue: true);
            migrationBuilder.AddColumn<int>(name: "CreateId", table: "MasterSocialMedia", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(name: "CreateDate", table: "MasterSocialMedia", type: "datetime2", nullable: false, defaultValueSql: "GETDATE()");
            migrationBuilder.AddColumn<int>(name: "UpdateId", table: "MasterSocialMedia", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(name: "UpdateDate", table: "MasterSocialMedia", type: "datetime2", nullable: false, defaultValueSql: "GETDATE()");

            // MasterWorkingHours
            migrationBuilder.AddColumn<bool>(name: "IsDelete", table: "MasterWorkingHours", type: "bit", nullable: false, defaultValue: false);
            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "MasterWorkingHours", type: "bit", nullable: false, defaultValue: true);
            migrationBuilder.AddColumn<int>(name: "CreateId", table: "MasterWorkingHours", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(name: "CreateDate", table: "MasterWorkingHours", type: "datetime2", nullable: false, defaultValueSql: "GETDATE()");
            migrationBuilder.AddColumn<int>(name: "UpdateId", table: "MasterWorkingHours", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(name: "UpdateDate", table: "MasterWorkingHours", type: "datetime2", nullable: false, defaultValueSql: "GETDATE()");

            // SystemSettings
            migrationBuilder.AddColumn<string>(name: "SystemSettingPhone", table: "SystemSettings", type: "nvarchar(max)", nullable: false, defaultValue: "");
            migrationBuilder.AddColumn<string>(name: "SystemSettingEmail", table: "SystemSettings", type: "nvarchar(max)", nullable: false, defaultValue: "");
            migrationBuilder.AddColumn<string>(name: "SystemSettingSocialMediaIcon", table: "SystemSettings", type: "nvarchar(max)", nullable: false, defaultValue: "");
            migrationBuilder.AddColumn<string>(name: "SystemSettingSocialMediaIconUrl", table: "SystemSettings", type: "nvarchar(max)", nullable: false, defaultValue: "");
            migrationBuilder.AddColumn<string>(name: "SystemSettingMapLocationUrl", table: "SystemSettings", type: "nvarchar(max)", nullable: false, defaultValue: "");
            migrationBuilder.AddColumn<bool>(name: "IsDelete", table: "SystemSettings", type: "bit", nullable: false, defaultValue: false);
            migrationBuilder.AddColumn<bool>(name: "IsActive", table: "SystemSettings", type: "bit", nullable: false, defaultValue: true);
            migrationBuilder.AddColumn<int>(name: "CreateId", table: "SystemSettings", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(name: "CreateDate", table: "SystemSettings", type: "datetime2", nullable: false, defaultValueSql: "GETDATE()");
            migrationBuilder.AddColumn<int>(name: "UpdateId", table: "SystemSettings", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(name: "UpdateDate", table: "SystemSettings", type: "datetime2", nullable: false, defaultValueSql: "GETDATE()");

            // TransactionBookTables
            migrationBuilder.AddColumn<int>(name: "CreateId", table: "TransactionBookTables", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(name: "CreateDate", table: "TransactionBookTables", type: "datetime2", nullable: false, defaultValueSql: "GETDATE()");

            // TransactionContactUs
            migrationBuilder.AddColumn<int>(name: "CreateId", table: "TransactionContactUs", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(name: "CreateDate", table: "TransactionContactUs", type: "datetime2", nullable: false, defaultValueSql: "GETDATE()");

            // TransactionNewsletters
            migrationBuilder.AddColumn<int>(name: "CreateId", table: "TransactionNewsletters", type: "int", nullable: false, defaultValue: 0);
            migrationBuilder.AddColumn<DateTime>(name: "CreateDate", table: "TransactionNewsletters", type: "datetime2", nullable: false, defaultValueSql: "GETDATE()");

            // ملاحظة: MasterItemMenus ما فيها أي تغيير - مو محتاجة أي أمر هون إطلاقًا

            // ================= جداول جديدة بالكامل (زي ما هي بدون تعديل) =================

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterWhatPeopleSay",
                columns: table => new
                {
                    MasterWhatPeopleSayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterWhatPeopleSayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasterWhatPeopleSayText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasterWhatPeopleSayImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateId = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterWhatPeopleSay", x => x.MasterWhatPeopleSayId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MasterWorkingDay",
                columns: table => new
                {
                    MasterWorkingDayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterWorkingDayName = table.Column<int>(type: "int", nullable: false),
                    MasterWorkingHoursId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateId = table.Column<int>(type: "int", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterWorkingDay", x => x.MasterWorkingDayId);
                    table.ForeignKey(
                        name: "FK_MasterWorkingDay_MasterWorkingHours_MasterWorkingHoursId",
                        column: x => x.MasterWorkingHoursId,
                        principalTable: "MasterWorkingHours",
                        principalColumn: "MasterWorkingHoursId",
                        onDelete: ReferentialAction.Cascade);
                });

            // ================= الفهارس (Indexes) بس للجداول الجديدة =================

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MasterWorkingDay_MasterWorkingHoursId",
                table: "MasterWorkingDay",
                column: "MasterWorkingHoursId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // حذف الجداول الجديدة بالكامل
            migrationBuilder.DropTable(name: "AspNetRoleClaims");
            migrationBuilder.DropTable(name: "AspNetUserClaims");
            migrationBuilder.DropTable(name: "AspNetUserLogins");
            migrationBuilder.DropTable(name: "AspNetUserRoles");
            migrationBuilder.DropTable(name: "AspNetUserTokens");
            migrationBuilder.DropTable(name: "MasterWhatPeopleSay");
            migrationBuilder.DropTable(name: "MasterWorkingDay");
            migrationBuilder.DropTable(name: "AspNetRoles");
            migrationBuilder.DropTable(name: "AspNetUsers");

            // حذف الأعمدة يلي انضافت على الجداول الموجودة أصلاً
            migrationBuilder.DropColumn(name: "IsDelete", table: "MasterCategoryMenus");
            migrationBuilder.DropColumn(name: "IsActive", table: "MasterCategoryMenus");
            migrationBuilder.DropColumn(name: "CreateId", table: "MasterCategoryMenus");
            migrationBuilder.DropColumn(name: "CreateDate", table: "MasterCategoryMenus");
            migrationBuilder.DropColumn(name: "UpdateId", table: "MasterCategoryMenus");
            migrationBuilder.DropColumn(name: "UpdateDate", table: "MasterCategoryMenus");

            migrationBuilder.DropColumn(name: "IsDelete", table: "MasterMenus");
            migrationBuilder.DropColumn(name: "IsActive", table: "MasterMenus");
            migrationBuilder.DropColumn(name: "CreateId", table: "MasterMenus");
            migrationBuilder.DropColumn(name: "CreateDate", table: "MasterMenus");
            migrationBuilder.DropColumn(name: "UpdateId", table: "MasterMenus");
            migrationBuilder.DropColumn(name: "UpdateDate", table: "MasterMenus");

            migrationBuilder.DropColumn(name: "IsDelete", table: "MasterOffers");
            migrationBuilder.DropColumn(name: "IsActive", table: "MasterOffers");
            migrationBuilder.DropColumn(name: "CreateId", table: "MasterOffers");
            migrationBuilder.DropColumn(name: "CreateDate", table: "MasterOffers");
            migrationBuilder.DropColumn(name: "UpdateId", table: "MasterOffers");
            migrationBuilder.DropColumn(name: "UpdateDate", table: "MasterOffers");

            migrationBuilder.DropColumn(name: "IsDelete", table: "MasterPartners");
            migrationBuilder.DropColumn(name: "IsActive", table: "MasterPartners");
            migrationBuilder.DropColumn(name: "CreateId", table: "MasterPartners");
            migrationBuilder.DropColumn(name: "CreateDate", table: "MasterPartners");
            migrationBuilder.DropColumn(name: "UpdateId", table: "MasterPartners");
            migrationBuilder.DropColumn(name: "UpdateDate", table: "MasterPartners");

            migrationBuilder.DropColumn(name: "IsDelete", table: "MasterServices");
            migrationBuilder.DropColumn(name: "IsActive", table: "MasterServices");
            migrationBuilder.DropColumn(name: "CreateId", table: "MasterServices");
            migrationBuilder.DropColumn(name: "CreateDate", table: "MasterServices");
            migrationBuilder.DropColumn(name: "UpdateId", table: "MasterServices");
            migrationBuilder.DropColumn(name: "UpdateDate", table: "MasterServices");

            migrationBuilder.DropColumn(name: "IsDelete", table: "MasterSliders");
            migrationBuilder.DropColumn(name: "IsActive", table: "MasterSliders");
            migrationBuilder.DropColumn(name: "CreateId", table: "MasterSliders");
            migrationBuilder.DropColumn(name: "CreateDate", table: "MasterSliders");
            migrationBuilder.DropColumn(name: "UpdateId", table: "MasterSliders");
            migrationBuilder.DropColumn(name: "UpdateDate", table: "MasterSliders");

            migrationBuilder.DropColumn(name: "IsDelete", table: "MasterSocialMedia");
            migrationBuilder.DropColumn(name: "IsActive", table: "MasterSocialMedia");
            migrationBuilder.DropColumn(name: "CreateId", table: "MasterSocialMedia");
            migrationBuilder.DropColumn(name: "CreateDate", table: "MasterSocialMedia");
            migrationBuilder.DropColumn(name: "UpdateId", table: "MasterSocialMedia");
            migrationBuilder.DropColumn(name: "UpdateDate", table: "MasterSocialMedia");

            migrationBuilder.DropColumn(name: "IsDelete", table: "MasterWorkingHours");
            migrationBuilder.DropColumn(name: "IsActive", table: "MasterWorkingHours");
            migrationBuilder.DropColumn(name: "CreateId", table: "MasterWorkingHours");
            migrationBuilder.DropColumn(name: "CreateDate", table: "MasterWorkingHours");
            migrationBuilder.DropColumn(name: "UpdateId", table: "MasterWorkingHours");
            migrationBuilder.DropColumn(name: "UpdateDate", table: "MasterWorkingHours");

            migrationBuilder.DropColumn(name: "SystemSettingPhone", table: "SystemSettings");
            migrationBuilder.DropColumn(name: "SystemSettingEmail", table: "SystemSettings");
            migrationBuilder.DropColumn(name: "SystemSettingSocialMediaIcon", table: "SystemSettings");
            migrationBuilder.DropColumn(name: "SystemSettingSocialMediaIconUrl", table: "SystemSettings");
            migrationBuilder.DropColumn(name: "SystemSettingMapLocationUrl", table: "SystemSettings");
            migrationBuilder.DropColumn(name: "IsDelete", table: "SystemSettings");
            migrationBuilder.DropColumn(name: "IsActive", table: "SystemSettings");
            migrationBuilder.DropColumn(name: "CreateId", table: "SystemSettings");
            migrationBuilder.DropColumn(name: "CreateDate", table: "SystemSettings");
            migrationBuilder.DropColumn(name: "UpdateId", table: "SystemSettings");
            migrationBuilder.DropColumn(name: "UpdateDate", table: "SystemSettings");

            migrationBuilder.DropColumn(name: "CreateId", table: "TransactionBookTables");
            migrationBuilder.DropColumn(name: "CreateDate", table: "TransactionBookTables");

            migrationBuilder.DropColumn(name: "CreateId", table: "TransactionContactUs");
            migrationBuilder.DropColumn(name: "CreateDate", table: "TransactionContactUs");

            migrationBuilder.DropColumn(name: "CreateId", table: "TransactionNewsletters");
            migrationBuilder.DropColumn(name: "CreateDate", table: "TransactionNewsletters");
        }
    }
}