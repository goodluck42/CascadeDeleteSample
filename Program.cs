// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
using ConsoleApp2;

Console.WriteLine("Hello, World!");


var context = new AppDbContext();

context.Users.Remove(new User
{
    Id = -1
});

context.SaveChanges();