using CommandLine.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandLine.Api.Data
{
    public class CommandContext : DbContext
    {
        public CommandContext(DbContextOptions<CommandContext> options) : base(options) { }

        public DbSet<Command> Commands { get; set; }
    }
}
