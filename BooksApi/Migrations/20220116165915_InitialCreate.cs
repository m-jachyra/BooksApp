using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BooksApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthorName = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeathDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Biography = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GenreName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Token = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    ExpiryOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatedByIp = table.Column<string>(type: "text", nullable: true),
                    RevokedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RevokedByIp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    AuthorId = table.Column<long>(type: "bigint", nullable: false),
                    GenreId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Rate = table.Column<int>(type: "integer", nullable: false),
                    BookId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opinions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Rate = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    ReviewId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opinions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opinions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Opinions_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d9187272-b557-41b4-a976-04ad0cb5cf5f", "f290d7f7-a0a4-4f81-bb39-fa556cb5cef4", "Default", "DEFAULT" },
                    { "059e5df3-8035-4d0d-8a78-ad043ab5d5ba", "aa244d2f-ab96-4d10-89cc-853660ce5f10", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "36e158e5-3731-4976-a13f-445fe61fdddd", 0, "c3402916-90ae-4518-a27a-d96a3a16b261", "jk@gmail.com", false, false, null, "JK@GMAIL.COM", "JK", "AQAAAAEAACcQAAAAEDvHtSG33pC9UyUDs24JB1HqD1vvuYPmUkLSTrGa/ZUMWjqmNo7azkW+iabf9maZqA==", null, false, "30d51cd9-8b15-4849-84ef-2d115767938c", false, "JK" },
                    { "593a9e65-5f4d-40b8-91f5-1813f577ce70", 0, "187b7d47-5ad1-40ef-83df-6e3cc6d3756f", "martink@gmail.com", false, false, null, "MARTINK@GMAIL.COM", "MARTINX", "AQAAAAEAACcQAAAAEO5I9ooRw4GMKWEjVL7WZFxoGEintpC6N7GqiwIuRj8ay/rt6N8E0of7oDCAXGVrLA==", null, false, "481e6d0d-93a3-4f83-95d7-d71fe6e54393", false, "Martinx" },
                    { "509de9d8-a3d5-47d9-a6b2-82c13c5dd216", 0, "2d1488c0-fb07-45db-9b7c-979eff79283f", "mich@gmail.com", false, false, null, "MICH@GMAIL.COM", "MICHAELLLO", "AQAAAAEAACcQAAAAECDzE8qTpmY1UlTZ9nqwDFBIAune2ARalJNl2cSLm5Vs+xoQOD9Er7kkDjUeM0hWLA==", null, false, "1f18f157-3ab4-4c5f-911a-1ca2757f7f21", false, "Michaelllo" },
                    { "e6f1d790-fa08-4db8-8958-4d8d171193d2", 0, "2ebc79bc-6c15-4d40-98d2-88432434ce5c", "a.one@gmail.com", false, false, null, "A.ONE@GMAIL.COM", "ANNA", "AQAAAAEAACcQAAAAEHsaxYOAHlh/2fpRPEtOeOp8EIjrhfWEf4vZCbjjXIT4hVXvpAT85o0Ifv70oxC7Tg==", null, false, "97bcefba-051c-4f5b-a032-c1242878c359", false, "Anna" },
                    { "7b2e5361-9196-49f7-aa93-9c752fd63f19", 0, "c74a0f6e-a88e-40a5-929a-7060637bf7ac", "sara12@gmail.com", false, false, null, "SARA12@GMAIL.COM", "SARA12", "AQAAAAEAACcQAAAAENXAvfhyyQ1aVvtNYCcxGXkoMeb0K2IwMQV3n9miqs0NvBRmMwji1VimRuM1S57MBA==", null, false, "832957f3-acbc-4e11-8ebb-07a9fb01597e", false, "Sara12" },
                    { "1e6751b3-ecd8-4835-aee7-29274771601d", 0, "18fec5da-8909-4e36-aa85-1bd159a4bdde", "t.smith@gmail.com", false, false, null, "T.SMITH@GMAIL.COM", "TIMIX", "AQAAAAEAACcQAAAAEL0fBl61Q9iWalIkdflBZZkRLwDyyitPYfr9Ua3KdGbxegav9esZ7g8jZYg1+CFwFg==", null, false, "b793a728-3b75-4f95-a12e-c79e2c3f3aa4", false, "Timix" },
                    { "e32bdbc1-1892-4e41-9c69-6fcf8e40635c", 0, "0d5a4e93-edae-4ae4-8354-ec11dde60cef", "norbi.m@gamil.com", false, false, null, "NORBI.M@GAMIL.COM", "NORBI", "AQAAAAEAACcQAAAAEH9MbBi+C9UuUAldpW8kiiEpGrRWUuSOQ3CKF7bH2SDK1f/REQttgFyrXCiQVOhiwQ==", null, false, "cc41d885-c98d-44fe-bb26-feb7fb61a88f", false, "Norbi" },
                    { "7493442e-646b-41d4-8aa8-8b764c12eb2c", 0, "a83d8f0f-a107-457c-84be-c29ba6a996d0", "ewarak@gmail.com", false, false, null, "EWARAK@GMAIL.COM", "EWAAAA", "AQAAAAEAACcQAAAAEBOC05aEVERaB5oGeaLf+z71TJpI5t8BTmt1VOEiKyURYF/ySRu1UJZUC1Rs5TZw9w==", null, false, "1064cb8e-14ac-403d-81f5-8fe30faf09c3", false, "Ewaaaa" },
                    { "f2bb93f0-3f5b-4918-9462-1d5ba0059ab4", 0, "7ba808bf-8095-426f-88e5-4cdd45037483", "znowakowska@gmail.com", false, false, null, "ZNOWAKOWSKA@GMAIL.COM", "ZOSIAA1", "AQAAAAEAACcQAAAAEAIpD6j7UwcWLBoD7iJMEtrAjXQWSivyyQmbqGR3CC9n2ebZ58Y32Xeqpemzh0+nAw==", null, false, "85f911f9-dae6-498e-ac3d-478d6a2c69fe", false, "Zosiaa1" },
                    { "4be99f35-6aa1-46b4-b0d0-2c0a6545a9e2", 0, "3a339b40-8502-4fa9-89f7-35dd5e2ac4a3", "j.fik@gmail.com", false, false, null, "J.FIK@GMAIL.COM", "JANEK99", "AQAAAAEAACcQAAAAEJSRx+VvuXZsloUbS5Xs/w1pQv6IICnoigeaEINkElIpq1k9UycfsqoNRVG60AmSlw==", null, false, "9cf69988-39b2-4aff-ab7d-fec1978b4d0d", false, "Janek99" },
                    { "c907b3e5-3ebc-4bf0-a733-b01c75ba8d77", 0, "f5561a97-c2f1-48ff-9fbb-3eaf7ac61b27", "wiktoria@gmail.com", false, false, null, "WIKTORIA@GMAIL.COM", "WIKA", "AQAAAAEAACcQAAAAEA7dNq9dYmfYlO9fwarBM96RfrlM6FUtdhnpdAHZDuB/oF0TtHxm9C1GXaAotd9V2g==", null, false, "f4592ff4-8517-4b37-9e57-b64b48753b40", false, "Wika" },
                    { "0cf44c1c-6a00-4738-b33f-b662cf98cd7e", 0, "cabfa7af-7923-4576-b7ed-15238c355f47", "rzeka.magda@gmail.com", false, false, null, "RZEKA.MAGDA@GMAIL.COM", "MADZIX", "AQAAAAEAACcQAAAAEG5L2jFN2ieMFq1vz5+ViOZzMjBBmKN9oqD+tSgzo+Gs3h4BI8EQf6PAJqz4hddzmw==", null, false, "e7453046-def5-403b-b02b-bd98e0bb1cfc", false, "Madzix" },
                    { "1e1a1a16-3c37-467f-ac77-e83f3061edd3", 0, "159b17f7-5225-4624-8a09-970038ba4cf5", "w.wrak@gmail.com", false, false, null, "W.WRAK@GMAIL.COM", "WERCIA", "AQAAAAEAACcQAAAAELufaCMXl3gaku2lGOZUpGejOY3C/Af7hX2rF2G04lLVG88OIOWWQWiCLDFz0wtC5A==", null, false, "c2d86e9b-56c3-4a29-a5d9-5aebaf1fa98c", false, "Wercia" },
                    { "1fe1d8b9-40b4-4d21-9ec3-747b25fe0316", 0, "be6063ca-a880-4060-9aa3-fcd577d0bea2", "marcinp@gmail.com", false, false, null, "MARCINP@GMAIL.COM", "PANMARCIN", "AQAAAAEAACcQAAAAENG61JlbqYVlpkdEJjRVNFjC1mFE+1lKmtLB/vL/8SwI7CGWlxLTi3p2NjkmSjBqvA==", null, false, "ea3e965b-428e-4bcf-90c0-e043a3cbfc40", false, "PanMarcin" },
                    { "fb5fad4f-130e-439a-a74d-e75432c8a5d7", 0, "11fc7411-f535-4313-a845-dc4e5be601c2", "znawca@gamil.com", false, false, null, "ZNAWCA@GAMIL.COM", "ZNAWCA", "AQAAAAEAACcQAAAAEBxYusOEQYOcOu0Xq7ILIYju8iOzYKIIoFG7GmeGaOsrwc02ILfzYONYUKG9bjsBDA==", null, false, "a6723cf4-440d-49bf-87db-39097eb5ae24", false, "Znawca" },
                    { "bdf0715a-053f-4d3a-85e5-8013f853107e", 0, "93493796-3256-4ed5-b0b4-d23def9501c3", "mirkow@gmail.com", false, false, null, "MIRKOW@GMAIL.COM", "MIREK123", "AQAAAAEAACcQAAAAEL0TD1w0LSHAiOSDCEZONNUPsbA2oPgj0vl6Ek5pvqe2K//IPIClfh9zh8wcqunBow==", null, false, "f3f04872-039b-42e2-aa3d-a63aebff1542", false, "mirek123" },
                    { "9c3d4bdf-a2eb-42f5-9b67-07facff0653d", 0, "13834f7b-21be-49a2-bd5c-e88672d10138", "enowak@gmail.com", false, false, null, "ENOWAK@GMAIL.COM", "EMILKA", "AQAAAAEAACcQAAAAEOhoahz/fsN5IWizlhMhOntZuRLwLNsg84PE2QQWI2dKQNFQqygtxDjX0jy/mSo4LQ==", null, false, "2e0e1d81-8f72-4e85-81d8-8dd91883d023", false, "Emilka" },
                    { "23e1a0ef-4a8a-462a-8219-1d3a1169f417", 0, "1a704323-39db-4943-9e86-eb9ecd0e731a", "stafano@gmail.com", false, false, null, "STAFANO@GMAIL.COM", "STEFFFANO1", "AQAAAAEAACcQAAAAEBNCR+jbb8jigGFQ349zwBu1oN1hBeuArEZJmpuAfgBRfotAqSa5yTQCeTeAT8lFWQ==", null, false, "b382af22-eddf-41bf-819b-83894f8f09d4", false, "Stefffano1" },
                    { "a6592ad5-0033-4d24-b5c7-b5ab43d81836", 0, "6086b367-b92b-4d31-a231-5711478a869d", "ewelina99@gmail.com", false, false, null, "EWELINA99@GMAIL.COM", "EWELCIA", "AQAAAAEAACcQAAAAEFRpExQSnfT9rhkooIMylOfivXUfOSj9q/YPD01D0eoLp5eVk0l5SQ7wVoGotJq5lQ==", null, false, "b3d6950e-be21-4bf3-9931-8494b44cc218", false, "Ewelcia" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "AuthorName", "Biography", "BirthDate", "DeathDate" },
                values: new object[,]
                {
                    { 3L, "J. R. R. Tolkien", "Lorem Ipsum Dolor Sit Amet", new DateTime(1892, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1973, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12L, "Stephan King", "Lorem Ipsum Dolor Sit Amet", new DateTime(1947, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4L, "George R.R. Martin", "Lorem Ipsum Dolor Sit Amet", new DateTime(1948, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5L, "Stephanie Meyer", "Lorem Ipsum Dolor Sit Amet", new DateTime(1973, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 6L, "J.K. Rowling", "Lorem Ipsum Dolor Sit Amet", new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 7L, "Remigiusz Mróz", "Lorem Ipsum Dolor Sit Amet", new DateTime(1987, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 17L, "Olga Tokarczuk", "Lorem Ipsum Dolor Sit Amet", new DateTime(1962, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 16L, "Juliusz Słowacki", "Lorem Ipsum Dolor Sit Amet", new DateTime(1809, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1949, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15L, "William Shakespeare", "Lorem Ipsum Dolor Sit Amet", new DateTime(1564, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1616, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14L, "Alicja Sinicka", "Lorem Ipsum Dolor Sit Amet", new DateTime(1987, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 13L, "E.L. James", "Lorem Ipsum Dolor Sit Amet", new DateTime(1963, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 8L, "Henryk Sienkiewicz", "Lorem Ipsum Dolor Sit Amet", new DateTime(1846, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1916, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11L, "Andrzej Sapkowski", "Lorem Ipsum Dolor Sit Amet", new DateTime(1948, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 10L, "Władysław Reymont", "Lorem Ipsum Dolor Sit Amet", new DateTime(1867, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1925, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9L, "Bolesław Prus", "Lorem Ipsum Dolor Sit Amet", new DateTime(1847, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1912, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "GenreName" },
                values: new object[,]
                {
                    { 5L, "Drama" },
                    { 1L, "Fantasy" },
                    { 2L, "Horror" },
                    { 3L, "Criminal" },
                    { 4L, "Romance" },
                    { 6L, "Historic" },
                    { 7L, "Slice of life" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "059e5df3-8035-4d0d-8a78-ad043ab5d5ba", "23e1a0ef-4a8a-462a-8219-1d3a1169f417" },
                    { "d9187272-b557-41b4-a976-04ad0cb5cf5f", "e6f1d790-fa08-4db8-8958-4d8d171193d2" },
                    { "d9187272-b557-41b4-a976-04ad0cb5cf5f", "7b2e5361-9196-49f7-aa93-9c752fd63f19" },
                    { "d9187272-b557-41b4-a976-04ad0cb5cf5f", "1e6751b3-ecd8-4835-aee7-29274771601d" },
                    { "d9187272-b557-41b4-a976-04ad0cb5cf5f", "e32bdbc1-1892-4e41-9c69-6fcf8e40635c" },
                    { "d9187272-b557-41b4-a976-04ad0cb5cf5f", "7493442e-646b-41d4-8aa8-8b764c12eb2c" },
                    { "d9187272-b557-41b4-a976-04ad0cb5cf5f", "4be99f35-6aa1-46b4-b0d0-2c0a6545a9e2" },
                    { "d9187272-b557-41b4-a976-04ad0cb5cf5f", "509de9d8-a3d5-47d9-a6b2-82c13c5dd216" },
                    { "d9187272-b557-41b4-a976-04ad0cb5cf5f", "a6592ad5-0033-4d24-b5c7-b5ab43d81836" },
                    { "d9187272-b557-41b4-a976-04ad0cb5cf5f", "0cf44c1c-6a00-4738-b33f-b662cf98cd7e" },
                    { "d9187272-b557-41b4-a976-04ad0cb5cf5f", "1e1a1a16-3c37-467f-ac77-e83f3061edd3" },
                    { "d9187272-b557-41b4-a976-04ad0cb5cf5f", "1fe1d8b9-40b4-4d21-9ec3-747b25fe0316" },
                    { "d9187272-b557-41b4-a976-04ad0cb5cf5f", "fb5fad4f-130e-439a-a74d-e75432c8a5d7" },
                    { "d9187272-b557-41b4-a976-04ad0cb5cf5f", "bdf0715a-053f-4d3a-85e5-8013f853107e" },
                    { "d9187272-b557-41b4-a976-04ad0cb5cf5f", "9c3d4bdf-a2eb-42f5-9b67-07facff0653d" },
                    { "d9187272-b557-41b4-a976-04ad0cb5cf5f", "c907b3e5-3ebc-4bf0-a733-b01c75ba8d77" },
                    { "d9187272-b557-41b4-a976-04ad0cb5cf5f", "593a9e65-5f4d-40b8-91f5-1813f577ce70" },
                    { "d9187272-b557-41b4-a976-04ad0cb5cf5f", "f2bb93f0-3f5b-4918-9462-1d5ba0059ab4" },
                    { "d9187272-b557-41b4-a976-04ad0cb5cf5f", "36e158e5-3731-4976-a13f-445fe61fdddd" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Description", "GenreId", "Title" },
                values: new object[,]
                {
                    { 19L, 17L, "Lorem Ipsum Dolor Sit Amet", 7L, "Bieguni" },
                    { 4L, 4L, "Lorem Ipsum Dolor Sit Amet", 1L, "Game of Thrones" },
                    { 5L, 3L, "Lorem Ipsum Dolor Sit Amet", 1L, "Hobbit" },
                    { 6L, 5L, "Lorem Ipsum Dolor Sit Amet", 1L, "Twilight" },
                    { 7L, 6L, "Lorem Ipsum Dolor Sit Amet", 1L, "Harry Potter" },
                    { 24L, 11L, "Lorem Ipsum Dolor Sit Amet", 1L, "Wiedźmin" },
                    { 12L, 12L, "Lorem Ipsum Dolor Sit Amet", 2L, "Smętarz dla zwierzaków" },
                    { 13L, 12L, "Lorem Ipsum Dolor Sit Amet", 2L, "It" },
                    { 14L, 7L, "Lorem Ipsum Dolor Sit Amet", 3L, "Halny" },
                    { 11L, 13L, "Lorem Ipsum Dolor Sit Amet", 4L, "Fifty Shades of Grey" },
                    { 8L, 16L, "Lorem Ipsum Dolor Sit Amet", 5L, "Balladyna" },
                    { 9L, 15L, "Lorem Ipsum Dolor Sit Amet", 5L, "Król Lear" },
                    { 16L, 9L, "Lorem Ipsum Dolor Sit Amet", 5L, "Lalka" },
                    { 15L, 10L, "Lorem Ipsum Dolor Sit Amet", 6L, "Chłopi" },
                    { 17L, 8L, "Lorem Ipsum Dolor Sit Amet", 6L, "Potop" },
                    { 10L, 14L, "Lorem Ipsum Dolor Sit Amet", 4L, "Oczy wilka" },
                    { 1L, 3L, "Best book that was ever written.", 1L, "Lord of the rings" }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "BookId", "Content", "Rate", "Title", "UserId" },
                values: new object[,]
                {
                    { 1L, 1L, "I think that is the best book ever written", 10, "My favourite book", "23e1a0ef-4a8a-462a-8219-1d3a1169f417" },
                    { 10L, 15L, "W tej książce mogą naprawdę odnaleźć się prawdziwi miłośnicy historii.", 9, "Miłośnicy historii.", "0cf44c1c-6a00-4738-b33f-b662cf98cd7e" },
                    { 9L, 16L, "Brakuje mi w tej książce prawdziwych zwrotów akcji.", 5, "Zwroty akcji", "509de9d8-a3d5-47d9-a6b2-82c13c5dd216" },
                    { 8L, 9L, "Nie spodziewałam się, ze książka tej autorki może być tak dobra.", 8, "Miła niespodzianka", "1e1a1a16-3c37-467f-ac77-e83f3061edd3" },
                    { 6L, 8L, "W tej książce można rzenieść się w naprawdę magiczne miejsca i poznać prawdziwych bohaterów.", 9, "Magiczne miejsce.", "a6592ad5-0033-4d24-b5c7-b5ab43d81836" },
                    { 16L, 11L, "Książka, która trzyma tajemnice do samego końca i daje nieoczekiwane zwroty akcji to dobra książka.", 10, "To niemożliwe.", "e6f1d790-fa08-4db8-8958-4d8d171193d2" },
                    { 5L, 11L, "Książka jest nudna i nieciekawa dla czytelnika", 1, "Niezbyt dobra opinia", "e6f1d790-fa08-4db8-8958-4d8d171193d2" },
                    { 17L, 15L, "Myślałem, że przyadnie mita ksiązka do gustu, ale jednak się pomyliłem.", 3, "To nie to.", "7493442e-646b-41d4-8aa8-8b764c12eb2c" },
                    { 11L, 10L, "Autor miał chyba ograniczoną wyobraźnię pisząć tę książkę.", 2, "Możliwości wyobraźni", "e32bdbc1-1892-4e41-9c69-6fcf8e40635c" },
                    { 12L, 12L, "Dzięki dokładnym opisą przyrody i otoczenia czytelnik może przenieść do świata powieśći.", 8, "Moc słów.", "e32bdbc1-1892-4e41-9c69-6fcf8e40635c" },
                    { 2L, 7L, "Gra oparta na tej książce, wygląda jakby w ogóle nie była przemyślana.", 3, "Beznadziejna gra", "593a9e65-5f4d-40b8-91f5-1813f577ce70" },
                    { 7L, 6L, "Z tej książki można naprawdę wiele się nauczyć.", 8, "Cięte riosty.", "c907b3e5-3ebc-4bf0-a733-b01c75ba8d77" },
                    { 15L, 5L, "Ta książka potrafi narawdę dobrze przestraszyć.", 1, "Prawdziwy horror.", "c907b3e5-3ebc-4bf0-a733-b01c75ba8d77" },
                    { 14L, 5L, "Ta seria książek trwa już za długo,mam nadzieję,że to ostatnia.", 3, "Oby to już koniec.", "c907b3e5-3ebc-4bf0-a733-b01c75ba8d77" },
                    { 3L, 4L, "Bohaterowie tej książki są napisani w perfekcyjny sposób.", 10, "Najlepsi bohaterowie", "7b2e5361-9196-49f7-aa93-9c752fd63f19" },
                    { 4L, 13L, "Ulubiony bohater.", 10, "Ulubiony bohater.", "7493442e-646b-41d4-8aa8-8b764c12eb2c" },
                    { 13L, 17L, "Żałuję, że ta książka się już skończyła,bo bardzo się w nią wciągnęłam.", 9, "Tylko tyle?", "509de9d8-a3d5-47d9-a6b2-82c13c5dd216" }
                });

            migrationBuilder.InsertData(
                table: "Opinions",
                columns: new[] { "Id", "Rate", "ReviewId", "UserId" },
                values: new object[,]
                {
                    { 1L, false, 1L, "23e1a0ef-4a8a-462a-8219-1d3a1169f417" },
                    { 9L, false, 9L, "fb5fad4f-130e-439a-a74d-e75432c8a5d7" },
                    { 4L, true, 8L, "e6f1d790-fa08-4db8-8958-4d8d171193d2" },
                    { 7L, false, 5L, "e32bdbc1-1892-4e41-9c69-6fcf8e40635c" },
                    { 3L, false, 5L, "509de9d8-a3d5-47d9-a6b2-82c13c5dd216" },
                    { 11L, false, 11L, "1fe1d8b9-40b4-4d21-9ec3-747b25fe0316" },
                    { 8L, true, 4L, "bdf0715a-053f-4d3a-85e5-8013f853107e" },
                    { 6L, false, 10L, "1e6751b3-ecd8-4835-aee7-29274771601d" },
                    { 5L, true, 4L, "7b2e5361-9196-49f7-aa93-9c752fd63f19" },
                    { 2L, false, 2L, "593a9e65-5f4d-40b8-91f5-1813f577ce70" },
                    { 16L, true, 7L, "c907b3e5-3ebc-4bf0-a733-b01c75ba8d77" },
                    { 12L, true, 7L, "0cf44c1c-6a00-4738-b33f-b662cf98cd7e" },
                    { 17L, false, 3L, "9c3d4bdf-a2eb-42f5-9b67-07facff0653d" },
                    { 15L, true, 3L, "4be99f35-6aa1-46b4-b0d0-2c0a6545a9e2" },
                    { 10L, false, 3L, "1e1a1a16-3c37-467f-ac77-e83f3061edd3" },
                    { 13L, false, 12L, "a6592ad5-0033-4d24-b5c7-b5ab43d81836" },
                    { 14L, false, 13L, "36e158e5-3731-4976-a13f-445fe61fdddd" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenreId",
                table: "Books",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_ReviewId",
                table: "Opinions",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Opinions_UserId",
                table: "Opinions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_BookId",
                table: "Reviews",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Opinions");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
