using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BooksApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    security_stamp = table.Column<string>(type: "text", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    author_name = table.Column<string>(type: "text", nullable: true),
                    birth_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    death_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    biography = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_authors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    genre_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_genres", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<string>(type: "text", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_role_claims_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_user_claims_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    provider_key = table.Column<string>(type: "text", nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_asp_net_user_logins_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "text", nullable: false),
                    role_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "text", nullable: false),
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_asp_net_user_tokens_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "refresh_tokens",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    token = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<string>(type: "text", nullable: true),
                    expiry_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    created_by_ip = table.Column<string>(type: "text", nullable: true),
                    revoked_on = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    revoked_by_ip = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_refresh_tokens", x => x.id);
                    table.ForeignKey(
                        name: "fk_refresh_tokens_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    author_id = table.Column<long>(type: "bigint", nullable: false),
                    genre_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_books", x => x.id);
                    table.ForeignKey(
                        name: "fk_books_authors_author_id",
                        column: x => x.author_id,
                        principalTable: "authors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_books_genres_genre_id",
                        column: x => x.genre_id,
                        principalTable: "genres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "text", nullable: true),
                    content = table.Column<string>(type: "text", nullable: true),
                    rate = table.Column<int>(type: "integer", nullable: false),
                    book_id = table.Column<long>(type: "bigint", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_reviews", x => x.id);
                    table.ForeignKey(
                        name: "fk_reviews_books_book_id",
                        column: x => x.book_id,
                        principalTable: "books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reviews_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "opinions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rate = table.Column<bool>(type: "boolean", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: true),
                    review_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_opinions", x => x.id);
                    table.ForeignKey(
                        name: "fk_opinions_reviews_review_id",
                        column: x => x.review_id,
                        principalTable: "reviews",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_opinions_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "fdcebb1b-b431-4f4d-98ba-a986b6a4990d", "e584e22c-f9d7-4176-aeae-4b97f8b95bbe", "Default", "DEFAULT" },
                    { "da6486af-ab27-48f0-9ad5-1a5f047cd292", "3311e92e-bbee-480e-b964-605873c86602", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[,]
                {
                    { "36e158e5-3731-4976-a13f-445fe61fdddd", 0, "3591a375-879e-495c-ac16-d03e8e7bd933", "jk@gmail.com", false, false, null, "JK@GMAIL.COM", "JK", "AQAAAAEAACcQAAAAENMtz/1HJe9mFAFM+LjiGKGM2YFgWGulXt36XvWk1sUR8cdwEEekI3dBi51KBOwuHQ==", null, false, "88125554-9ea9-48c1-b6cb-5e3a84204227", false, "JK" },
                    { "593a9e65-5f4d-40b8-91f5-1813f577ce70", 0, "f32f51cb-457e-43d1-9332-4eb5b63bb011", "martink@gmail.com", false, false, null, "MARTINK@GMAIL.COM", "MARTINX", "AQAAAAEAACcQAAAAEJCdpr6gxYM+5a71VKXL3KkytAellVUBEOb/zKcd51hf+iknkojq98o+3f4vvQzRJQ==", null, false, "6ab0ad70-5130-482a-9614-4e4e139442aa", false, "Martinx" },
                    { "509de9d8-a3d5-47d9-a6b2-82c13c5dd216", 0, "75257521-91e3-4b3d-9baa-9563d63a34ff", "mich@gmail.com", false, false, null, "MICH@GMAIL.COM", "MICHAELLLO", "AQAAAAEAACcQAAAAEDuCbugX2jqGb0mGC19HICtu136TxedTbTrAuzi6APTw6KKzOHSdbFV+qZcolWNDGA==", null, false, "7f0e80ff-c8fc-44b4-af0b-b33ce9635998", false, "Michaelllo" },
                    { "e6f1d790-fa08-4db8-8958-4d8d171193d2", 0, "22e18ba4-4f92-47ac-adc0-12a927b4dfb5", "a.one@gmail.com", false, false, null, "A.ONE@GMAIL.COM", "ANNA", "AQAAAAEAACcQAAAAEHV8KUWC7A4VREnUKJzo9ylHARgTUkVlykOfrnyow3rNkVno5gSIGvt9et9ygbYwrw==", null, false, "069ae22b-9a07-4c51-97e3-75048773de71", false, "Anna" },
                    { "7b2e5361-9196-49f7-aa93-9c752fd63f19", 0, "09dc51ea-410b-438d-bb29-a0bf5ad34053", "sara12@gmail.com", false, false, null, "SARA12@GMAIL.COM", "SARA12", "AQAAAAEAACcQAAAAEHaUwvMC1isLzF72LW3mHv/Cf2mrR2h6+ZZHPu8fAzZNchgiBolu6lnmrB8RiJrDnA==", null, false, "792b914e-6807-4193-a822-2791231d66eb", false, "Sara12" },
                    { "1e6751b3-ecd8-4835-aee7-29274771601d", 0, "def66562-abb7-414f-934b-ed3c2737cdd9", "t.smith@gmail.com", false, false, null, "T.SMITH@GMAIL.COM", "TIMIX", "AQAAAAEAACcQAAAAEHbGGAE3QPUcqqGSFZ9NyJw9CKEWbTUlxbr2Jym3QtXxYpvCKvOd9hySwaqJHCTP0Q==", null, false, "0401aa18-0ac7-4982-ba58-cf437dff6beb", false, "Timix" },
                    { "e32bdbc1-1892-4e41-9c69-6fcf8e40635c", 0, "c0fca701-c08f-4038-acc9-ce5218e606d0", "norbi.m@gamil.com", false, false, null, "NORBI.M@GAMIL.COM", "NORBI", "AQAAAAEAACcQAAAAEMbYo6toxQgijBT7Co8Or6PtPF8HqE2mYBIBAhs6O8XaI3LlvYCMgcVKfifsspcdCA==", null, false, "049e1d8f-b1db-451b-b7c1-471117770d1c", false, "Norbi" },
                    { "7493442e-646b-41d4-8aa8-8b764c12eb2c", 0, "022d5d06-4643-4289-8975-010e1f90dd15", "ewarak@gmail.com", false, false, null, "EWARAK@GMAIL.COM", "EWAAAA", "AQAAAAEAACcQAAAAEISYocpoScEDzRw5bKmvjH7arL8IEwG+AC27t8uuW/My8my41aIYQGGq/8hZR56WoA==", null, false, "cb096deb-7aac-42c8-a368-634ff6b96700", false, "Ewaaaa" },
                    { "f2bb93f0-3f5b-4918-9462-1d5ba0059ab4", 0, "985af9ad-a0df-43a0-969b-93c552355c87", "znowakowska@gmail.com", false, false, null, "ZNOWAKOWSKA@GMAIL.COM", "ZOSIAA1", "AQAAAAEAACcQAAAAEHeoVf+9C2CMnK5rrL+914FaZoF+IvWcO90m8q88nbgnY4vQY8ScAP9BBuv+eod9XA==", null, false, "f3498322-9098-4434-a7ad-52d7fdfdc8dd", false, "Zosiaa1" },
                    { "4be99f35-6aa1-46b4-b0d0-2c0a6545a9e2", 0, "d5abaedc-f8e3-4fd0-a9e3-7ff0977d1285", "j.fik@gmail.com", false, false, null, "J.FIK@GMAIL.COM", "JANEK99", "AQAAAAEAACcQAAAAEPkvkfuimMOIIClkAQ6VG4RZqT8Pg2G45GK/wb/luHmyB73TGg3T2o4K3/YGTTXlpw==", null, false, "02215d43-acba-400b-810e-8f04cdc35eab", false, "Janek99" },
                    { "c907b3e5-3ebc-4bf0-a733-b01c75ba8d77", 0, "6d427e04-ffba-445b-b4c4-ee892535fef0", "wiktoria@gmail.com", false, false, null, "WIKTORIA@GMAIL.COM", "WIKA", "AQAAAAEAACcQAAAAEJsLzEGp56jZj5JQJnfKvRsAr9qz6igL7sUSTMgwegcnv6B07n3uLrYmKEOTqJ7EoA==", null, false, "fc33d9a4-3245-49b6-bb93-aa467fdb340a", false, "Wika" },
                    { "0cf44c1c-6a00-4738-b33f-b662cf98cd7e", 0, "223d8eb4-ff33-43d7-a600-9b937a139f24", "rzeka.magda@gmail.com", false, false, null, "RZEKA.MAGDA@GMAIL.COM", "MADZIX", "AQAAAAEAACcQAAAAEBjCyCLzQ0t3jO+DtygEYc7C9aZSfrn38le2qagOQyAHirFIUrKgk2O1HO8iW4snSw==", null, false, "34f8855b-4418-4fc8-9fa6-8cdad3232004", false, "Madzix" },
                    { "1e1a1a16-3c37-467f-ac77-e83f3061edd3", 0, "fd93bfa3-c230-4611-a97c-66db08cc225b", "w.wrak@gmail.com", false, false, null, "W.WRAK@GMAIL.COM", "WERCIA", "AQAAAAEAACcQAAAAEJ0QTrr3tq3xGFb8CGKPjNfYzgz5IV2IPoPxMv2DmrsFalgEABfjcyuGCED7nVVUnQ==", null, false, "4a76a077-8ead-4489-a5c4-099d8fc08495", false, "Wercia" },
                    { "1fe1d8b9-40b4-4d21-9ec3-747b25fe0316", 0, "70d51279-8a9c-4dff-b8d8-4b9501b6ceff", "marcinp@gmail.com", false, false, null, "MARCINP@GMAIL.COM", "PANMARCIN", "AQAAAAEAACcQAAAAEKXzNCkvltlpuxKRh44zsGL0BhcQSN1YKY91Xr+rReWu1jNL4eR9TNdN/RqOmEpASQ==", null, false, "5aaed874-ddd5-4ca1-9e5f-141888e72582", false, "PanMarcin" },
                    { "fb5fad4f-130e-439a-a74d-e75432c8a5d7", 0, "321d9d02-d042-47b7-9642-6c812f9e502e", "znawca@gamil.com", false, false, null, "ZNAWCA@GAMIL.COM", "ZNAWCA", "AQAAAAEAACcQAAAAEDl5dbRzWQJRxxR9xb+yizUQy2R1snR56uTlfuSynZuepIL59lOcvX+iin17lQU+QA==", null, false, "57dd3824-214f-4d84-be18-6e18ced29983", false, "Znawca" },
                    { "bdf0715a-053f-4d3a-85e5-8013f853107e", 0, "9c883a3a-a9e9-49b9-aff5-3455c87d64be", "mirkow@gmail.com", false, false, null, "MIRKOW@GMAIL.COM", "MIREK123", "AQAAAAEAACcQAAAAEJy1DVTKjXrlq2AszPFr6WHfVXkDESKa33WWP5L54VFKChptEdxzkcTIF+UdNVUg2A==", null, false, "c4d0adb5-35fa-427b-999a-4aead0ebc367", false, "mirek123" },
                    { "9c3d4bdf-a2eb-42f5-9b67-07facff0653d", 0, "82e55b13-47b7-4580-8d22-234ff412d53f", "enowak@gmail.com", false, false, null, "ENOWAK@GMAIL.COM", "EMILKA", "AQAAAAEAACcQAAAAEBFMouagAuWwYuM+WVK2b3TBoI8Ty3JYJCS9j+nG4e4LhZ9YSb5WpCLmhE4cezD0tw==", null, false, "31b45280-8ee9-4250-a39e-8dc3d806603b", false, "Emilka" },
                    { "23e1a0ef-4a8a-462a-8219-1d3a1169f417", 0, "27527afe-597c-4168-b9c2-f4f3647be4bb", "stafano@gmail.com", false, false, null, "STAFANO@GMAIL.COM", "STEFFFANO1", "AQAAAAEAACcQAAAAEFn8DM+2v/OXyw1Q09NQSY2fuob11fORhffAxP494JDwRBSzgn7O2LyCFgnz18aJMQ==", null, false, "eaf4a1da-81c5-4f78-a675-fff0cfe673b0", false, "Stefffano1" },
                    { "a6592ad5-0033-4d24-b5c7-b5ab43d81836", 0, "1e733f4b-a9d9-4daa-b783-cfcca6ed37e8", "ewelina99@gmail.com", false, false, null, "EWELINA99@GMAIL.COM", "EWELCIA", "AQAAAAEAACcQAAAAEJHN3GRxDq8Sv1olTMUrpgFr6Jl8Fq9rMvxAFbNL9oE0GHrnye7uFpaKr3TjNif3Hw==", null, false, "c4bc0b75-62e9-41a2-9623-a08ad9c978c4", false, "Ewelcia" }
                });

            migrationBuilder.InsertData(
                table: "authors",
                columns: new[] { "id", "author_name", "biography", "birth_date", "death_date" },
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
                table: "genres",
                columns: new[] { "id", "genre_name" },
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
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { "da6486af-ab27-48f0-9ad5-1a5f047cd292", "23e1a0ef-4a8a-462a-8219-1d3a1169f417" },
                    { "fdcebb1b-b431-4f4d-98ba-a986b6a4990d", "e6f1d790-fa08-4db8-8958-4d8d171193d2" },
                    { "fdcebb1b-b431-4f4d-98ba-a986b6a4990d", "7b2e5361-9196-49f7-aa93-9c752fd63f19" },
                    { "fdcebb1b-b431-4f4d-98ba-a986b6a4990d", "1e6751b3-ecd8-4835-aee7-29274771601d" },
                    { "fdcebb1b-b431-4f4d-98ba-a986b6a4990d", "e32bdbc1-1892-4e41-9c69-6fcf8e40635c" },
                    { "fdcebb1b-b431-4f4d-98ba-a986b6a4990d", "7493442e-646b-41d4-8aa8-8b764c12eb2c" },
                    { "fdcebb1b-b431-4f4d-98ba-a986b6a4990d", "4be99f35-6aa1-46b4-b0d0-2c0a6545a9e2" },
                    { "fdcebb1b-b431-4f4d-98ba-a986b6a4990d", "509de9d8-a3d5-47d9-a6b2-82c13c5dd216" },
                    { "fdcebb1b-b431-4f4d-98ba-a986b6a4990d", "a6592ad5-0033-4d24-b5c7-b5ab43d81836" },
                    { "fdcebb1b-b431-4f4d-98ba-a986b6a4990d", "0cf44c1c-6a00-4738-b33f-b662cf98cd7e" },
                    { "fdcebb1b-b431-4f4d-98ba-a986b6a4990d", "1e1a1a16-3c37-467f-ac77-e83f3061edd3" },
                    { "fdcebb1b-b431-4f4d-98ba-a986b6a4990d", "1fe1d8b9-40b4-4d21-9ec3-747b25fe0316" },
                    { "fdcebb1b-b431-4f4d-98ba-a986b6a4990d", "fb5fad4f-130e-439a-a74d-e75432c8a5d7" },
                    { "fdcebb1b-b431-4f4d-98ba-a986b6a4990d", "bdf0715a-053f-4d3a-85e5-8013f853107e" },
                    { "fdcebb1b-b431-4f4d-98ba-a986b6a4990d", "9c3d4bdf-a2eb-42f5-9b67-07facff0653d" },
                    { "fdcebb1b-b431-4f4d-98ba-a986b6a4990d", "c907b3e5-3ebc-4bf0-a733-b01c75ba8d77" },
                    { "fdcebb1b-b431-4f4d-98ba-a986b6a4990d", "593a9e65-5f4d-40b8-91f5-1813f577ce70" },
                    { "fdcebb1b-b431-4f4d-98ba-a986b6a4990d", "f2bb93f0-3f5b-4918-9462-1d5ba0059ab4" },
                    { "fdcebb1b-b431-4f4d-98ba-a986b6a4990d", "36e158e5-3731-4976-a13f-445fe61fdddd" }
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "id", "author_id", "description", "genre_id", "title" },
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
                table: "reviews",
                columns: new[] { "id", "book_id", "content", "rate", "title", "user_id" },
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
                table: "opinions",
                columns: new[] { "id", "rate", "review_id", "user_id" },
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
                name: "ix_asp_net_role_claims_role_id",
                table: "AspNetRoleClaims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_claims_user_id",
                table: "AspNetUserClaims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_logins_user_id",
                table: "AspNetUserLogins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_asp_net_user_roles_role_id",
                table: "AspNetUserRoles",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_books_author_id",
                table: "books",
                column: "author_id");

            migrationBuilder.CreateIndex(
                name: "ix_books_genre_id",
                table: "books",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "ix_opinions_review_id",
                table: "opinions",
                column: "review_id");

            migrationBuilder.CreateIndex(
                name: "ix_opinions_user_id",
                table: "opinions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_refresh_tokens_user_id",
                table: "refresh_tokens",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_book_id",
                table: "reviews",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "ix_reviews_user_id",
                table: "reviews",
                column: "user_id");
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
                name: "opinions");

            migrationBuilder.DropTable(
                name: "refresh_tokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "genres");
        }
    }
}
