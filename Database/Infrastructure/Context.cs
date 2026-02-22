using Microsoft.EntityFrameworkCore;

using Database.Models;

namespace Database.Infrastructure;

public class Context(DbContextOptions options) : DbContext(options)
{
    public DbSet<Invite> Invites =>  Set<Invite>();
    public DbSet<Room> Rooms =>  Set<Room>();
    public DbSet<User> Users => Set<User>();
}
