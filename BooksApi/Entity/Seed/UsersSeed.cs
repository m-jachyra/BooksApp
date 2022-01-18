using BooksApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace BooksApi.Entity
{
    public static class UsersSeed
    {
        public static void SeedUsersData(this ModelBuilder modelBuilder)
        {
            var adminUserRoleGuid = Guid.NewGuid().ToString();
            var defaultUserRoleGuid = Guid.NewGuid().ToString();
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = adminUserRoleGuid, Name =  "Admin", NormalizedName = "ADMIN" });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Id = defaultUserRoleGuid, Name = "Default", NormalizedName = "DEFAULT" });

            var hasher = new PasswordHasher<User>();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = "23e1a0ef-4a8a-462a-8219-1d3a1169f417",
                    UserName = "Stefffano1",
                    NormalizedUserName = "Stefffano1".ToUpper(),
                    Email = "stafano@gmail.com",
                    NormalizedEmail = "stafano@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "password")
                },
                new User
                {
                    Id = "593a9e65-5f4d-40b8-91f5-1813f577ce70",
                    UserName = "Martinx",
                    NormalizedUserName = "Martinx".ToUpper(),
                    Email = "martink@gmail.com",
                    NormalizedEmail = "martink@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "password")
                },
                new User
                {
                    Id = "509de9d8-a3d5-47d9-a6b2-82c13c5dd216",
                    UserName = "Michaelllo",
                    NormalizedUserName = "Michaelllo".ToUpper(),
                    Email = "mich@gmail.com",
                    NormalizedEmail = "mich@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "password")
                },
                new User
                {
                    Id = "e6f1d790-fa08-4db8-8958-4d8d171193d2",
                    UserName = "Anna",
                    NormalizedUserName = "Anna".ToUpper(),
                    Email = "a.one@gmail.com",
                    NormalizedEmail = "a.one@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "password")
                },
                new User
                {
                    Id = "7b2e5361-9196-49f7-aa93-9c752fd63f19",
                    UserName = "Sara12",
                    NormalizedUserName = "Sara12".ToUpper(),
                    Email = "sara12@gmail.com",
                    NormalizedEmail = "sara12@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "password")
                },
                new User
                {
                    Id = "1e6751b3-ecd8-4835-aee7-29274771601d",
                    UserName = "Timix",
                    NormalizedUserName = "Timix".ToUpper(),
                    Email = "t.smith@gmail.com",
                    NormalizedEmail = "t.smith@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "password")
                },
                new User
                {
                    Id = "e32bdbc1-1892-4e41-9c69-6fcf8e40635c",
                    UserName = "Norbi",
                    NormalizedUserName = "Norbi".ToUpper(),
                    Email = "norbi.m@gamil.com",
                    NormalizedEmail = "norbi.m@gamil.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "password")
                },
                new User
                {
                    Id = "7493442e-646b-41d4-8aa8-8b764c12eb2c",
                    UserName = "Ewaaaa",
                    NormalizedUserName = "Ewaaaa".ToUpper(),
                    Email = "ewarak@gmail.com",
                    NormalizedEmail = "ewarak@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "password")
                },
                new User
                {
                    Id = "4be99f35-6aa1-46b4-b0d0-2c0a6545a9e2",
                    UserName = "Janek99",
                    NormalizedUserName = "Janek99".ToUpper(),
                    Email = "j.fik@gmail.com",
                    NormalizedEmail = "j.fik@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "password")
                },
                new User
                {
                    Id = "a6592ad5-0033-4d24-b5c7-b5ab43d81836",
                    UserName = "Ewelcia",
                    NormalizedUserName = "Ewelcia".ToUpper(),
                    Email = "ewelina99@gmail.com",
                    NormalizedEmail = "ewelina99@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "password")
                },
                new User
                {
                    Id = "c907b3e5-3ebc-4bf0-a733-b01c75ba8d77",
                    UserName = "Wika",
                    NormalizedUserName = "Wika".ToUpper(),
                    Email = "wiktoria@gmail.com",
                    NormalizedEmail = "wiktoria@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "password")
                },
                new User
                {
                    Id = "0cf44c1c-6a00-4738-b33f-b662cf98cd7e",
                    UserName = "Madzix",
                    NormalizedUserName = "Madzix".ToUpper(),
                    Email = "rzeka.magda@gmail.com",
                    NormalizedEmail = "rzeka.magda@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "password")
                },
                new User
                {
                    Id = "1e1a1a16-3c37-467f-ac77-e83f3061edd3",
                    UserName = "Wercia",
                    NormalizedUserName = "Wercia".ToUpper(),
                    Email = "w.wrak@gmail.com",
                    NormalizedEmail = "w.wrak@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "password")
                },
                new User
                {
                    Id = "1fe1d8b9-40b4-4d21-9ec3-747b25fe0316",
                    UserName = "PanMarcin",
                    NormalizedUserName = "PanMarcin".ToUpper(),
                    Email = "marcinp@gmail.com",
                    NormalizedEmail = "marcinp@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "password")
                },
                new User
                {
                    Id = "fb5fad4f-130e-439a-a74d-e75432c8a5d7",
                    UserName = "Znawca",
                    NormalizedUserName = "Znawca".ToUpper(),
                    Email = "znawca@gamil.com",
                    NormalizedEmail = "znawca@gamil.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "password")
                },
                new User
                {
                    Id = "bdf0715a-053f-4d3a-85e5-8013f853107e",
                    UserName = "mirek123",
                    NormalizedUserName = "mirek123".ToUpper(),
                    Email = "mirkow@gmail.com",
                    NormalizedEmail = "mirkow@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "password")
                },
                new User
                {
                    Id = "9c3d4bdf-a2eb-42f5-9b67-07facff0653d",
                    UserName = "Emilka",
                    NormalizedUserName = "Emilka".ToUpper(),
                    Email = "enowak@gmail.com",
                    NormalizedEmail = "enowak@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "password")
                },
                new User
                {
                    Id = "36e158e5-3731-4976-a13f-445fe61fdddd",
                    UserName = "JK",
                    NormalizedUserName = "JK".ToUpper(),
                    Email = "jk@gmail.com",
                    NormalizedEmail = "jk@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "password")
                },
                new User
                {
                    Id = "f2bb93f0-3f5b-4918-9462-1d5ba0059ab4",
                    UserName = "Zosiaa1",
                    NormalizedUserName = "Zosiaa1".ToUpper(),
                    Email = "znowakowska@gmail.com",
                    NormalizedEmail = "znowakowska@gmail.com".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "password")
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = adminUserRoleGuid,
                    UserId = "23e1a0ef-4a8a-462a-8219-1d3a1169f417"
                },
                new IdentityUserRole<string>
                {
                    RoleId = defaultUserRoleGuid,
                    UserId = "593a9e65-5f4d-40b8-91f5-1813f577ce70"
                },
                new IdentityUserRole<string>
                {
                    RoleId = defaultUserRoleGuid,
                    UserId = "509de9d8-a3d5-47d9-a6b2-82c13c5dd216"
                },
                new IdentityUserRole<string>
                {
                    RoleId = defaultUserRoleGuid,
                    UserId = "e6f1d790-fa08-4db8-8958-4d8d171193d2"
                },
                new IdentityUserRole<string>
                {
                    RoleId = defaultUserRoleGuid,
                    UserId = "7b2e5361-9196-49f7-aa93-9c752fd63f19"
                },
                new IdentityUserRole<string>
                {
                    RoleId = defaultUserRoleGuid,
                    UserId = "1e6751b3-ecd8-4835-aee7-29274771601d"
                },
                new IdentityUserRole<string>
                {
                    RoleId = defaultUserRoleGuid,
                    UserId = "e32bdbc1-1892-4e41-9c69-6fcf8e40635c"
                },
                new IdentityUserRole<string>
                {
                    RoleId = defaultUserRoleGuid,
                    UserId = "7493442e-646b-41d4-8aa8-8b764c12eb2c"
                },
                new IdentityUserRole<string>
                {
                    RoleId = defaultUserRoleGuid,
                    UserId = "4be99f35-6aa1-46b4-b0d0-2c0a6545a9e2"
                },
                new IdentityUserRole<string>
                {
                    RoleId = defaultUserRoleGuid,
                    UserId = "a6592ad5-0033-4d24-b5c7-b5ab43d81836"
                },
                new IdentityUserRole<string>
                {
                    RoleId = defaultUserRoleGuid,
                    UserId = "c907b3e5-3ebc-4bf0-a733-b01c75ba8d77"
                },
                new IdentityUserRole<string>
                {
                    RoleId = defaultUserRoleGuid,
                    UserId = "0cf44c1c-6a00-4738-b33f-b662cf98cd7e"
                },
                new IdentityUserRole<string>
                {
                    RoleId = defaultUserRoleGuid,
                    UserId = "1e1a1a16-3c37-467f-ac77-e83f3061edd3"
                },
                new IdentityUserRole<string>
                {
                    RoleId = defaultUserRoleGuid,
                    UserId = "1fe1d8b9-40b4-4d21-9ec3-747b25fe0316"
                },
                new IdentityUserRole<string>
                {
                    RoleId = defaultUserRoleGuid,
                    UserId = "fb5fad4f-130e-439a-a74d-e75432c8a5d7"
                },
                new IdentityUserRole<string>
                {
                    RoleId = defaultUserRoleGuid,
                    UserId = "bdf0715a-053f-4d3a-85e5-8013f853107e"
                },
                new IdentityUserRole<string>
                {
                    RoleId = defaultUserRoleGuid,
                    UserId = "9c3d4bdf-a2eb-42f5-9b67-07facff0653d"
                },
                new IdentityUserRole<string>
                {
                    RoleId = defaultUserRoleGuid,
                    UserId = "36e158e5-3731-4976-a13f-445fe61fdddd"
                },
                new IdentityUserRole<string>
                {
                    RoleId = defaultUserRoleGuid,
                    UserId = "f2bb93f0-3f5b-4918-9462-1d5ba0059ab4"
                }
            );
        }
    }
}
