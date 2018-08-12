using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Net.Core.Repositories.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Secret = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ApplicationType = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    RefreshTokenLifeTime = table.Column<int>(type: "int", nullable: false),
                    AllowedOrigin = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryCode = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailQueues",
                columns: table => new
                {
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<long>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    FromEmailId = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    ToEmailId = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    EmailSubject = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    MessageBody = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    AttachedFiles = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    IsSucceedEmailSent = table.Column<bool>(type: "bit", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailQueues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeyGroups",
                columns: table => new
                {
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KeyGroup = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    LocalizationKeys = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocalizationKeys",
                columns: table => new
                {
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocalizationKey = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    EnglishValue = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    IrishValue = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalizationKeys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PdfQueues",
                columns: table => new
                {
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CriminalId = table.Column<long>(type: "bigint", nullable: false),
                    GeneratedHtml = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    ReGenerationRequired = table.Column<bool>(type: "bit", nullable: false),
                    IsPdfGenerationSucceed = table.Column<bool>(type: "bit", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PdfQueues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestQueues",
                columns: table => new
                {
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SearchParameters = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    IsRequestSucceed = table.Column<bool>(type: "bit", nullable: false),
                    ErrorMessage = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestQueues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "nvarchar(256)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    AboutInfo = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TokenId = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(100)", maxLength: 50, nullable: false),
                    ClientId = table.Column<string>(type: "nvarchar(200)", maxLength: 50, nullable: false),
                    IssuedUtc = table.Column<DateTime>(type: "DateTime", nullable: false),
                    ExpiresUtc = table.Column<DateTime>(type: "DateTime", nullable: false),
                    ProtectedTicket = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<long>(nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    ClaimId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.ClaimId);
                    table.ForeignKey(
                        name: "FK_Claims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExternalLogins",
                columns: table => new
                {
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalLogins", x => new { x.LoginProvider, x.ProviderKey, x.UserId });
                    table.ForeignKey(
                        name: "FK_ExternalLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_UserId",
                table: "Claims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalLogins_UserId",
                table: "ExternalLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_ClientId",
                table: "RefreshTokens",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropTable(
                name: "EmailQueues");

            migrationBuilder.DropTable(
                name: "ExternalLogins");

            migrationBuilder.DropTable(
                name: "KeyGroups");

            migrationBuilder.DropTable(
                name: "LocalizationKeys");

            migrationBuilder.DropTable(
                name: "PdfQueues");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "RequestQueues");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
