using CommandLine.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandLine.Api.Data
{
    public class SqlCommandAPIRepo : ICommandAPIRepo
    {
        private readonly CommandContext context;

        public SqlCommandAPIRepo(CommandContext context) => 
            this.context = context;

        public async Task CreateCommandAsync(Command command)
        {
            if (command == null) 
                throw new ArgumentNullException(nameof(command));

            await context.AddAsync(command);
        }

        public void DeleteCommand(Command command)
        {
            if(command == null) 
                throw new ArgumentNullException( nameof(command));

            context.Remove(command);
        }

        public async Task<IEnumerable<Command>> GetAllCommandsAsync() =>
            await context.Commands.ToListAsync();

        public async Task<Command> GetCommandByIdAsync(int id) => 
            await context.Commands.FirstOrDefaultAsync(command => command.Id == id);

        public async Task<bool> SaveChangesAsync() =>
            await context.SaveChangesAsync() >= 0;

        public Task UpdateCommandAsync(Command command)
        {
            throw new NotImplementedException();
        }
    }
}
