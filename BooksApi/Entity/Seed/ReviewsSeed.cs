using BooksApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Entity
{
    public static class ReviewsSeed
    {
        public static void SeedReviewsData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().HasData(
                new Review
                {
                    Id = 1,
                    Title = "My favourite book",
                    Content = "I think that is the best book ever written",
                    Rate = 10,
                    UserId = "23e1a0ef-4a8a-462a-8219-1d3a1169f417",
                    BookId = 1
                },
                new Review
                {
                    Id = 2,
                    Title = "Beznadziejna gra",
                    Content = "Gra oparta na tej książce, wygląda jakby w ogóle nie była przemyślana.",
                    Rate = 3,
                    UserId = "593a9e65-5f4d-40b8-91f5-1813f577ce70",
                    BookId = 7
                },
                new Review
                {
                    Id = 3,
                    Title = "Najlepsi bohaterowie",
                    Content = "Bohaterowie tej książki są napisani w perfekcyjny sposób.",
                    Rate = 10,
                    UserId = "7b2e5361-9196-49f7-aa93-9c752fd63f19",
                    BookId = 4
                },
                new Review
                {
                    Id = 4,
                    Title = "Ulubiony bohater.",
                    Content = "Ulubiony bohater.",
                    Rate = 10,
                    UserId = "7493442e-646b-41d4-8aa8-8b764c12eb2c",
                    BookId = 13
                },
                new Review
                {
                    Id = 5,
                    Title = "Niezbyt dobra opinia",
                    Content = "Książka jest nudna i nieciekawa dla czytelnika",
                    Rate = 1,
                    UserId = "e6f1d790-fa08-4db8-8958-4d8d171193d2",
                    BookId = 11
                },
                new Review
                {
                    Id = 6,
                    Title = "Magiczne miejsce.",
                    Content = "W tej książce można rzenieść się w naprawdę magiczne miejsca i poznać prawdziwych bohaterów.",
                    Rate = 9,
                    UserId = "a6592ad5-0033-4d24-b5c7-b5ab43d81836",
                    BookId = 8
                },
                new Review
                {
                    Id = 7,
                    Title = "Cięte riosty.",
                    Content = "Z tej książki można naprawdę wiele się nauczyć.",
                    Rate = 8,
                    UserId = "c907b3e5-3ebc-4bf0-a733-b01c75ba8d77",
                    BookId = 6
                },
                new Review
                {
                    Id = 8,
                    Title = "Miła niespodzianka",
                    Content = "Nie spodziewałam się, ze książka tej autorki może być tak dobra.",
                    Rate = 8,
                    UserId = "1e1a1a16-3c37-467f-ac77-e83f3061edd3",
                    BookId = 9
                },
                new Review
                {
                    Id = 9,
                    Title = "Zwroty akcji",
                    Content = "Brakuje mi w tej książce prawdziwych zwrotów akcji.",
                    Rate = 5,
                    UserId = "509de9d8-a3d5-47d9-a6b2-82c13c5dd216",
                    BookId = 16
                },
                new Review
                {
                    Id = 10,
                    Title = "Miłośnicy historii.",
                    Content = "W tej książce mogą naprawdę odnaleźć się prawdziwi miłośnicy historii.",
                    Rate = 9,
                    UserId = "0cf44c1c-6a00-4738-b33f-b662cf98cd7e",
                    BookId = 15
                },
                new Review
                {
                    Id = 11,
                    Title = "Możliwości wyobraźni",
                    Content = "Autor miał chyba ograniczoną wyobraźnię pisząć tę książkę.",
                    Rate = 2,
                    UserId = "e32bdbc1-1892-4e41-9c69-6fcf8e40635c",
                    BookId = 10
                },
                new Review
                {
                    Id = 12,
                    Title = "Moc słów.",
                    Content = "Dzięki dokładnym opisą przyrody i otoczenia czytelnik może przenieść do świata powieśći.",
                    Rate = 8,
                    UserId = "e32bdbc1-1892-4e41-9c69-6fcf8e40635c",
                    BookId = 12
                },
                new Review
                {
                    Id = 13,
                    Title = "Tylko tyle?",
                    Content = "Żałuję, że ta książka się już skończyła,bo bardzo się w nią wciągnęłam.",
                    Rate = 9,
                    UserId = "509de9d8-a3d5-47d9-a6b2-82c13c5dd216",
                    BookId = 17
                },
                new Review
                {
                    Id = 14,
                    Title = "Oby to już koniec.",
                    Content = "Ta seria książek trwa już za długo,mam nadzieję,że to ostatnia.",
                    Rate = 3,
                    UserId = "c907b3e5-3ebc-4bf0-a733-b01c75ba8d77",
                    BookId = 5
                },
                new Review
                {
                    Id = 15,
                    Title = "Prawdziwy horror.",
                    Content = "Ta książka potrafi narawdę dobrze przestraszyć.",
                    Rate = 1,
                    UserId = "c907b3e5-3ebc-4bf0-a733-b01c75ba8d77",
                    BookId = 5
                },
                new Review
                {
                    Id = 16,
                    Title = "To niemożliwe.",
                    Content = "Książka, która trzyma tajemnice do samego końca i daje nieoczekiwane zwroty akcji to dobra książka.",
                    Rate = 10,
                    UserId = "e6f1d790-fa08-4db8-8958-4d8d171193d2",
                    BookId = 11
                },
                new Review
                {
                    Id = 17,
                    Title = "To nie to.",
                    Content = "Myślałem, że przyadnie mita ksiązka do gustu, ale jednak się pomyliłem.",
                    Rate = 3,
                    UserId = "7493442e-646b-41d4-8aa8-8b764c12eb2c",
                    BookId = 15
                }
            );
        }
    }
}
