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
                name: "RefreshTokens",
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
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
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
                    { "4b6245b3-7d2d-45ed-8c3b-af692f3363b0", "578c9d97-d610-47a4-8259-1b7da4bd5036", "Default", "DEFAULT" },
                    { "cef7780a-7e43-47ab-810c-c04f0114ec01", "5ab10a3d-040e-4054-8f31-aff48f10dca2", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "36e158e5-3731-4976-a13f-445fe61fdddd", 0, "bbeaf624-7e06-4098-9434-0bc4b785e682", "jk@gmail.com", false, false, null, "JK@GMAIL.COM", "JK", "AQAAAAEAACcQAAAAEN/riufSGKGU2pdc+QgHHn4RIMaB3gZnzH4hf1VAKOEqX8rA3rmr7fI2R9YnDZiEKw==", null, false, "993dada4-3a08-44b3-94a4-347522482000", false, "JK" },
                    { "593a9e65-5f4d-40b8-91f5-1813f577ce70", 0, "b538d2a5-7e17-41d6-bdda-6794a6456698", "martink@gmail.com", false, false, null, "MARTINK@GMAIL.COM", "MARTINX", "AQAAAAEAACcQAAAAEIbHNTScInLCzoPo/sIPgeSvPFNTk/N3g6lWMytqWezvjX08rHU8uIc1+wzgisQNYA==", null, false, "43c5c256-d308-4bd9-b586-834397eacd16", false, "Martinx" },
                    { "509de9d8-a3d5-47d9-a6b2-82c13c5dd216", 0, "02719bdd-70e8-4888-9885-4eea21513f20", "mich@gmail.com", false, false, null, "MICH@GMAIL.COM", "MICHAELLLO", "AQAAAAEAACcQAAAAENsOwHoexrbamG2Eg+jm9vrowRjcb/Hs9N4TSAP3Jgrt2GJ1BH3pBlk8xtZDewUKhg==", null, false, "77462246-3813-45e9-a9cf-71351303dec4", false, "Michaelllo" },
                    { "e6f1d790-fa08-4db8-8958-4d8d171193d2", 0, "b7e74cf8-5ae9-4176-ab9f-7959f939b819", "a.one@gmail.com", false, false, null, "A.ONE@GMAIL.COM", "ANNA", "AQAAAAEAACcQAAAAEAnjlD3KIOY2Xgpq3zKmV6HmKNzBk+f4Cg0SBUqg1jZmH4fcQwOq0QBU1/AqZiLPlA==", null, false, "b347cdea-f8eb-4f43-96ae-69cc410184d2", false, "Anna" },
                    { "7b2e5361-9196-49f7-aa93-9c752fd63f19", 0, "5f7ca58e-615a-4721-b79c-1fb954cd20ee", "sara12@gmail.com", false, false, null, "SARA12@GMAIL.COM", "SARA12", "AQAAAAEAACcQAAAAEB1oCK8TJdhRtUF1/zrUmi0/fyW8JtqbvGKKLyJK10GMPFAJXyQQqkhy+Dn8iLlzng==", null, false, "3d659a3b-a923-4f27-8b57-1faa975dfaf9", false, "Sara12" },
                    { "1e6751b3-ecd8-4835-aee7-29274771601d", 0, "a0dc2f08-9294-44d5-8c68-254e7de85c3c", "t.smith@gmail.com", false, false, null, "T.SMITH@GMAIL.COM", "TIMIX", "AQAAAAEAACcQAAAAENUx8dIbE2A7Fl6aGLhBPyDh5I8Awj3IhOeLrjG4io1vluRKvQKlLS6Tz7mhwV7zOg==", null, false, "fefd15f8-0277-4120-8b96-a4d36d7a2b91", false, "Timix" },
                    { "e32bdbc1-1892-4e41-9c69-6fcf8e40635c", 0, "bd97284c-7e58-4f3f-860b-68c6d53febef", "norbi.m@gamil.com", false, false, null, "NORBI.M@GAMIL.COM", "NORBI", "AQAAAAEAACcQAAAAEDRFrzfIG143H3HVHxguEs9I5l0GaKb+hwfX3/VDIozpfWV7WV3bCEHYsYrWdyd0rg==", null, false, "fb0ee692-d74c-4a47-818a-4ad0fa6f9097", false, "Norbi" },
                    { "7493442e-646b-41d4-8aa8-8b764c12eb2c", 0, "ebac61b2-4fd1-4ecc-ad65-af85aebfdfd1", "ewarak@gmail.com", false, false, null, "EWARAK@GMAIL.COM", "EWAAAA", "AQAAAAEAACcQAAAAEH2P3mYJmZan0OlKW8gxz3YMdhkox2bWHAwQyeskF1ok1k8uOgmB3fiFzZrAo7vMIg==", null, false, "68e1231c-25b7-486d-b101-a203a3503ce4", false, "Ewaaaa" },
                    { "f2bb93f0-3f5b-4918-9462-1d5ba0059ab4", 0, "c0d6b83b-8d8f-4648-ab29-ac6da58b17f1", "znowakowska@gmail.com", false, false, null, "ZNOWAKOWSKA@GMAIL.COM", "ZOSIAA1", "AQAAAAEAACcQAAAAEBbO8b958JESdBC2iH9OWbQPWb190gXUzV2bXrrMzxsNidT42khNjyKc5A+Tesls7w==", null, false, "866767a4-98bb-4d62-b389-0ea437fadcd3", false, "Zosiaa1" },
                    { "4be99f35-6aa1-46b4-b0d0-2c0a6545a9e2", 0, "0d160a1a-685d-4b99-8cef-ce19cfd8cba1", "j.fik@gmail.com", false, false, null, "J.FIK@GMAIL.COM", "JANEK99", "AQAAAAEAACcQAAAAEFgywC9rr5W8PnmrybBItP4z6lZgoRyNFsowX2QihVgKVcF6AOt4pDfoOqu423dBaQ==", null, false, "7d0dd088-da81-498d-8523-970bfef49ddf", false, "Janek99" },
                    { "c907b3e5-3ebc-4bf0-a733-b01c75ba8d77", 0, "58fc7909-e412-4805-9d68-a2d3746fc110", "wiktoria@gmail.com", false, false, null, "WIKTORIA@GMAIL.COM", "WIKA", "AQAAAAEAACcQAAAAECSWiSOxnH69A+p4SW7FhKR/Hn35IxmgaXULJ3X403Djjfy+8ZAhX90Fu8F3ZEFm5A==", null, false, "5892ec31-6b2b-4e9d-bb14-922b26e57456", false, "Wika" },
                    { "0cf44c1c-6a00-4738-b33f-b662cf98cd7e", 0, "8c3b1fb3-0c9d-4c0a-a70b-ca61768848ae", "rzeka.magda@gmail.com", false, false, null, "RZEKA.MAGDA@GMAIL.COM", "MADZIX", "AQAAAAEAACcQAAAAEGbFlqlPkedpfCjKtg+uB75EhcGtws5iCALJN9EeNHWPetdoPGVsQr22j0gR1HXaaA==", null, false, "8ae0ce89-2f0e-4c57-883f-f2bb661ec749", false, "Madzix" },
                    { "1e1a1a16-3c37-467f-ac77-e83f3061edd3", 0, "ed42356a-eaf0-486a-adf5-51b4f193b5e0", "w.wrak@gmail.com", false, false, null, "W.WRAK@GMAIL.COM", "WERCIA", "AQAAAAEAACcQAAAAEJjdAD6xl+Sjymg3yzA4t6QFbdYVKqWPJlvIpxCCpeR/SXJUznPsQGFMmJv69K+IEw==", null, false, "c6eb5631-e0ef-4d5e-82c6-17a2d336b958", false, "Wercia" },
                    { "1fe1d8b9-40b4-4d21-9ec3-747b25fe0316", 0, "2d8ca985-dd0a-4752-84fc-5c64629523e1", "marcinp@gmail.com", false, false, null, "MARCINP@GMAIL.COM", "PANMARCIN", "AQAAAAEAACcQAAAAEJzclUnYri1R0JvSw9UjzzzycRKvGfDQnGOz8vxzNseogTUFcqUOSDkj1t+aU3Ug9A==", null, false, "7d17961b-d9a1-45fa-a533-b9ccab3d0e82", false, "PanMarcin" },
                    { "fb5fad4f-130e-439a-a74d-e75432c8a5d7", 0, "ccd4b8de-2ff8-4035-b9eb-03b8c633e7a5", "znawca@gamil.com", false, false, null, "ZNAWCA@GAMIL.COM", "ZNAWCA", "AQAAAAEAACcQAAAAEDjGY5fnWiv1HkUxQOATx7rjSBbKk1cwAtF4v8qomaFitU2AgNMqpqfQJwOEmqjd8g==", null, false, "4d395ac7-262b-4571-b8a4-6ddbd1453a4c", false, "Znawca" },
                    { "bdf0715a-053f-4d3a-85e5-8013f853107e", 0, "261b85c1-7ae6-492d-9c20-d9f31dd01f73", "mirkow@gmail.com", false, false, null, "MIRKOW@GMAIL.COM", "MIREK123", "AQAAAAEAACcQAAAAEIKkA8U7M/E8s/1j3+uWdLdLRqXCWCdEYmRB9pndMQPaBitFWt/rBODorX8iaZGQUg==", null, false, "49e2273f-70f5-495a-b5f6-5ebcba348add", false, "mirek123" },
                    { "9c3d4bdf-a2eb-42f5-9b67-07facff0653d", 0, "b72a7c64-e1a6-4d26-9f8f-5e9a84deeef3", "enowak@gmail.com", false, false, null, "ENOWAK@GMAIL.COM", "EMILKA", "AQAAAAEAACcQAAAAEJR5okU5QfjEWbRxXogTi9+3A9tv+1Y6aFwJ9WoZnOeFd5ko+E4vFhcTZggecfhflg==", null, false, "b1aca2df-2d4f-4fb0-9408-0c558ae93cfb", false, "Emilka" },
                    { "23e1a0ef-4a8a-462a-8219-1d3a1169f417", 0, "3f8c1f8d-ea3c-455c-8865-9a19cd32569a", "stafano@gmail.com", false, false, null, "STAFANO@GMAIL.COM", "STEFFFANO1", "AQAAAAEAACcQAAAAEAHFYHGeTTlZ4xTbt8KltK1pAvIWf+CmJ2jA1BucMApcnwKbC7kiJJZM+MNhYx9Log==", null, false, "4f9f964a-88e8-45db-800a-57642d900501", false, "Stefffano1" },
                    { "a6592ad5-0033-4d24-b5c7-b5ab43d81836", 0, "c7fd178d-735d-4c0d-932d-e2cef56c6e89", "ewelina99@gmail.com", false, false, null, "EWELINA99@GMAIL.COM", "EWELCIA", "AQAAAAEAACcQAAAAEAORKT4C8Oap19PpHE+Zzsz3wCo6ZsDnALUdTCMBMLMfCbNS8dr2+NF7r71DSdvcQA==", null, false, "1e77824b-3d15-4cf3-af36-f6420a0667cf", false, "Ewelcia" }
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
                    { "cef7780a-7e43-47ab-810c-c04f0114ec01", "23e1a0ef-4a8a-462a-8219-1d3a1169f417" },
                    { "4b6245b3-7d2d-45ed-8c3b-af692f3363b0", "e6f1d790-fa08-4db8-8958-4d8d171193d2" },
                    { "4b6245b3-7d2d-45ed-8c3b-af692f3363b0", "7b2e5361-9196-49f7-aa93-9c752fd63f19" },
                    { "4b6245b3-7d2d-45ed-8c3b-af692f3363b0", "1e6751b3-ecd8-4835-aee7-29274771601d" },
                    { "4b6245b3-7d2d-45ed-8c3b-af692f3363b0", "e32bdbc1-1892-4e41-9c69-6fcf8e40635c" },
                    { "4b6245b3-7d2d-45ed-8c3b-af692f3363b0", "7493442e-646b-41d4-8aa8-8b764c12eb2c" },
                    { "4b6245b3-7d2d-45ed-8c3b-af692f3363b0", "4be99f35-6aa1-46b4-b0d0-2c0a6545a9e2" },
                    { "4b6245b3-7d2d-45ed-8c3b-af692f3363b0", "509de9d8-a3d5-47d9-a6b2-82c13c5dd216" },
                    { "4b6245b3-7d2d-45ed-8c3b-af692f3363b0", "a6592ad5-0033-4d24-b5c7-b5ab43d81836" },
                    { "4b6245b3-7d2d-45ed-8c3b-af692f3363b0", "0cf44c1c-6a00-4738-b33f-b662cf98cd7e" },
                    { "4b6245b3-7d2d-45ed-8c3b-af692f3363b0", "1e1a1a16-3c37-467f-ac77-e83f3061edd3" },
                    { "4b6245b3-7d2d-45ed-8c3b-af692f3363b0", "1fe1d8b9-40b4-4d21-9ec3-747b25fe0316" },
                    { "4b6245b3-7d2d-45ed-8c3b-af692f3363b0", "fb5fad4f-130e-439a-a74d-e75432c8a5d7" },
                    { "4b6245b3-7d2d-45ed-8c3b-af692f3363b0", "bdf0715a-053f-4d3a-85e5-8013f853107e" },
                    { "4b6245b3-7d2d-45ed-8c3b-af692f3363b0", "9c3d4bdf-a2eb-42f5-9b67-07facff0653d" },
                    { "4b6245b3-7d2d-45ed-8c3b-af692f3363b0", "c907b3e5-3ebc-4bf0-a733-b01c75ba8d77" },
                    { "4b6245b3-7d2d-45ed-8c3b-af692f3363b0", "593a9e65-5f4d-40b8-91f5-1813f577ce70" },
                    { "4b6245b3-7d2d-45ed-8c3b-af692f3363b0", "f2bb93f0-3f5b-4918-9462-1d5ba0059ab4" },
                    { "4b6245b3-7d2d-45ed-8c3b-af692f3363b0", "36e158e5-3731-4976-a13f-445fe61fdddd" }
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
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
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
                name: "RefreshTokens");

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
