using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static System.IO.File;

using server.Entities;
using System;

namespace server.Data
{
    public class Seed
    {
        public static async Task SeedСards(DataContext context)
        {
            if (await context.Cards.AnyAsync())
                return;

            var cardData = await ReadAllTextAsync("Data/CardSeedData.json");
            var cards = JsonSerializer.Deserialize<List<Card>>(cardData);

            if (cards == null)
                return;

            foreach (var card in cards)
            {
                await context.Cards.AddAsync(card);
            }
        }
        public static async Task SeedUsers(UserManager<User> userManager, RoleManager<Role> roleManager, DataContext context)
        {
            if (await userManager.Users.AnyAsync())
                return;

            var userData = await ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<User>>(userData);

            if (users == null)
                return;

            var roles = new List<Role>
            {
                new Role { Name = "Gamer" },
                new Role { Name = "Admin" }
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            var cards = await context.Cards.ToListAsync();
            var cardCount = cards.Count;
            var random = new Random();
            foreach (var user in users)
            {
                List<int> cardIds = new List<int> ();
                var userCards = new List<UserCard>();
                while (cardIds.Count != 5)
                {
                    int cardId = random.Next(1, cardCount);
                    if (!cardIds.Contains(cardId))
                    {
                        cardIds.Add(cardId);
                        userCards.Add(new UserCard() { CardId = cardId });
                    }
                }
                user.UserCards = userCards;
                user.UserName = user.UserName.ToLower();
                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Gamer");
            }

            var admin = new User
            {
                UserName = "admin1",
                Nickname = "admin1name"
            };

            await userManager.CreateAsync(admin, "Pa$$w0rd");
            await userManager.AddToRoleAsync(admin, "Admin");
        }
    }
}