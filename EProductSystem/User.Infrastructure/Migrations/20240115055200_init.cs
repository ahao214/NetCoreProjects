using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber_RegionNumber = table.Column<int>(type: "int", unicode: false, maxLength: 5, nullable: false),
                    PhoneNumber_PhoneNumberValue = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(255)", unicode: false, maxLength: 255, nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(255)", unicode: false, maxLength: 255, nullable: true),
                    JwtVersion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_UserLoginHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhoneNumber_RegionNumber = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber_PhoneNumberValue = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_UserLoginHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_UserAccessFail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LockEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AccessFailCount = table.Column<int>(type: "int", nullable: false),
                    isLockOut = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_UserAccessFail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_UserAccessFail_T_User_UserId",
                        column: x => x.UserId,
                        principalTable: "T_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_UserAccessFail_UserId",
                table: "T_UserAccessFail",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_UserAccessFail");

            migrationBuilder.DropTable(
                name: "T_UserLoginHistory");

            migrationBuilder.DropTable(
                name: "T_User");
        }
    }
}
