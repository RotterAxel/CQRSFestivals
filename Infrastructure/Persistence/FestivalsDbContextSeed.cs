using System.Linq;
using Application.Common.Interfaces;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    public static class FestivalsDbContextSeed
    {
        public static void EnsureSeedDataForContext(
            this FestivalsDbContext context,
            IDateTime dateTimeService)
        {
            if (context.Festivals.Any())
            {
                context.Festivals.RemoveRange(context.Festivals);
            }

            if (context.Addresses.Any())
            {
                context.Addresses.RemoveRange(context.Addresses);
            }

            context.SaveChanges();
            
            GetPreconfiguredAdresses(context);
            GetPreconfiguredFestivals(context, dateTimeService);
            context.SaveChanges();
            
        }
        

        private static void GetPreconfiguredAdresses(FestivalsDbContext context)
        {
            context.Addresses.AddRange(
                new Address
                {
                    Id = 1,
                    Street = "Test Street",
                    Number = "1",
                    PostalCode = "28303",
                    State = "Bremen",
                    Country = "Germany"
                },
                new Address
                {
                    Id = 2,
                    Street = "Heimerweg",
                    Number = "2",
                    PostalCode = "28304",
                    State = "Bremen",
                    Country = "Germany"
                },
                new Address
                {
                    Id = 3,
                    Street = "Dingerweg",
                    Number = "3",
                    PostalCode = "28305",
                    State = "Bremen",
                    Country = "Germany"
                },
                new Address
                {
                    Id = 4,
                    Street = "Solinyanka",
                    Number = "4",
                    PostalCode = "28306",
                    State = "Bremen",
                    Country = "Germany"
                },
                new Address
                {
                    Id = 5,
                    Street = "Polishka",
                    Number = "5",
                    PostalCode = "28307",
                    State = "Bremen",
                    Country = "Germany"
                },
                new Address
                {
                    Id = 6,
                    Street = "Lotinshka",
                    Number = "6",
                    PostalCode = "28308",
                    State = "Bremen",
                    Country = "Germany"
                },
                new Address
                {
                    Id = 7,
                    Street = "Koliskaya",
                    Number = "7",
                    PostalCode = "28309",
                    State = "Bremen",
                    Country = "Germany"
                },
                new Address
                {
                    Id = 8,
                    Street = "Klasostiya",
                    Number = "8",
                    PostalCode = "28310",
                    State = "Bremen",
                    Country = "Germany"
                },
                new Address
                {
                    Id = 9,
                    Street = "Jinorido",
                    Number = "9",
                    PostalCode = "28311",
                    State = "Bremen",
                    Country = "Germany"
                },
                new Address
                {
                    Id = 10,
                    Street = "Kramelina",
                    Number = "10",
                    PostalCode = "28312",
                    State = "Bremen",
                    Country = "Germany"
                },
                new Address
                {
                    Id = 11,
                    Street = "Koparty",
                    Number = "11",
                    PostalCode = "28313",
                    State = "Bremen",
                    Country = "Germany"
                },
                new Address
                {
                    Id = 12,
                    Street = "Mandalarion Way",
                    Number = "12",
                    PostalCode = "28314",
                    State = "Bremen",
                    Country = "Germany"
                },
                new Address
                {
                    Id = 13,
                    Street = "Hiatusweg",
                    Number = "13",
                    PostalCode = "28315",
                    State = "Bremen",
                    Country = "Germany"
                }
            );
        }
        
        private static void GetPreconfiguredFestivals(FestivalsDbContext context,
            IDateTime dateTimeService)
        {
            var today = dateTimeService.UtcNow;

            context.Festivals.AddRange(
                new Festival
                {
                    Id = 1,
                    Title = "Mittelalterfest 1",
                    Description = "",
                    StartDate = today.AddHours(5),
                    EndDate = today.AddDays(3),
                    AddressId = 1
                },
                new Festival
                {
                    Id = 2,
                    Title = "Mittelalterfest 2",
                    Description = "",
                    StartDate = today.AddDays(2),
                    EndDate = today.AddDays(5),
                    AddressId = 2
                },
                new Festival
                {
                    Id = 3,
                    Title = "Mittelalterfest 3",
                    Description = "",
                    StartDate = today.AddDays(-2),
                    EndDate = today.AddDays(1),
                    AddressId = 3
                },
                new Festival
                {
                    Id = 4,
                    Title = "Mittelalterfest 4",
                    Description = "Greatest festival of all time",
                    StartDate = today.AddDays(47),
                    EndDate = today.AddDays(44),
                    AddressId = 4
                },
                new Festival
                {
                    Id = 5,
                    Title = "Mittelalterfest 5",
                    Description = "",
                    StartDate = today.AddDays(40),
                    EndDate = today.AddDays(43),
                    AddressId = 5
                },
                new Festival
                {
                    Id = 6,
                    Title = "Mittelalterfest 6",
                    Description = "",
                    StartDate = today.AddDays(36),
                    EndDate = today.AddDays(39),
                    AddressId = 6
                },
                new Festival
                {
                    Id = 7,
                    Title = "Mittelalterfest 7",
                    Description = "",
                    StartDate = today.AddDays(30),
                    EndDate = today.AddDays(33),
                    AddressId = 7
                },
                new Festival
                {
                    Id = 8,
                    Title = "Mittelalterfest 8",
                    Description = "",
                    StartDate = today.AddDays(20),
                    EndDate = today.AddDays(23),
                    AddressId = 8
                },
                new Festival
                {
                    Id = 9,
                    Title = "Mittelalterfest 9",
                    Description = "",
                    StartDate = today.AddHours(9),
                    EndDate = today.AddDays(5),
                    AddressId = 9
                },
                new Festival
                {
                    Id = 10,
                    Title = "Mittelalterfest 10",
                    Description = "",
                    StartDate = today.AddDays(1),
                    EndDate = today.AddDays(2),
                    AddressId = 10
                },
                new Festival
                {
                    Id = 11,
                    Title = "Mittelalterfest 11",
                    Description = "",
                    StartDate = today.AddDays(14),
                    EndDate = today.AddDays(17),
                    AddressId = 11
                },
                new Festival
                {
                    Id = 12,
                    Title = "Mittelalterfest 12",
                    Description = "",
                    StartDate = today.AddDays(10),
                    EndDate = today.AddDays(13),
                    AddressId = 12
                },
                new Festival
                {
                    Id = 13,
                    Title = "Mittelalterfest 13",
                    Description = "",
                    StartDate = today.AddDays(3),
                    EndDate = today.AddDays(6),
                    AddressId = 13
                }
            );
        }
    }
}