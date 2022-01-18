using BooksApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Entity
{
    public static class OpinionsSeed
    {
        public static void SeedOpinionsData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Opinion>().HasData(
                new Opinion
                {
                    Id = 1,
                    Rate = false,
                    ReviewId = 1,
                    UserId = "23e1a0ef-4a8a-462a-8219-1d3a1169f417"
                },
                new Opinion
                {
                    Id = 2,
                    Rate = false,
                    ReviewId = 2,
                    UserId = "593a9e65-5f4d-40b8-91f5-1813f577ce70"
                },
                new Opinion
                {
                    Id = 3,
                    Rate = false,
                    ReviewId = 5,
                    UserId = "509de9d8-a3d5-47d9-a6b2-82c13c5dd216"
                },
                new Opinion
                {
                    Id = 4,
                    Rate = true,
                    ReviewId = 8,
                    UserId = "e6f1d790-fa08-4db8-8958-4d8d171193d2"
                },
                new Opinion
                {
                    Id = 5,
                    Rate = true,
                    ReviewId = 4,
                    UserId = "7b2e5361-9196-49f7-aa93-9c752fd63f19"
                },
                new Opinion
                {
                    Id = 6,
                    Rate = false,
                    ReviewId = 10,
                    UserId = "1e6751b3-ecd8-4835-aee7-29274771601d"
                },
                new Opinion
                {
                    Id = 7,
                    Rate = false,
                    ReviewId = 5,
                    UserId = "e32bdbc1-1892-4e41-9c69-6fcf8e40635c"
                },
                new Opinion
                {
                    Id = 8,
                    Rate = true,
                    ReviewId = 4,
                    UserId = "bdf0715a-053f-4d3a-85e5-8013f853107e"
                },
                new Opinion
                {
                    Id = 9,
                    Rate = false,
                    ReviewId = 9,
                    UserId = "fb5fad4f-130e-439a-a74d-e75432c8a5d7"
                },
                new Opinion
                {
                    Id = 10,
                    Rate = false,
                    ReviewId = 3,
                    UserId = "1e1a1a16-3c37-467f-ac77-e83f3061edd3"
                },
                new Opinion
                {
                    Id = 11,
                    Rate = false,
                    ReviewId = 11,
                    UserId = "1fe1d8b9-40b4-4d21-9ec3-747b25fe0316"
                },
                new Opinion
                {
                    Id = 12,
                    Rate = true,
                    ReviewId = 7,
                    UserId = "0cf44c1c-6a00-4738-b33f-b662cf98cd7e"
                },
                new Opinion
                {
                    Id = 13,
                    Rate = false,
                    ReviewId = 12,
                    UserId = "a6592ad5-0033-4d24-b5c7-b5ab43d81836"
                },
                new Opinion
                {
                    Id = 14,
                    Rate = false,
                    ReviewId = 13,
                    UserId = "36e158e5-3731-4976-a13f-445fe61fdddd"
                },
                new Opinion
                {
                    Id = 15,
                    Rate = true,
                    ReviewId = 3,
                    UserId = "4be99f35-6aa1-46b4-b0d0-2c0a6545a9e2"
                },
                new Opinion
                {
                    Id = 16,
                    Rate = true,
                    ReviewId = 7,
                    UserId = "c907b3e5-3ebc-4bf0-a733-b01c75ba8d77"
                },
                new Opinion
                {
                    Id = 17,
                    Rate = false,
                    ReviewId = 3,
                    UserId = "9c3d4bdf-a2eb-42f5-9b67-07facff0653d"
                }
            );
        }
    }
}
