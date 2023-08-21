using CommandLine.Api.Models;

namespace CommandLine.Api.Data
{
    public interface ICommandAPIRepo
    {
        Task<IEnumerable<Command>> GetAllCommandsAsync();
        
        Task<Command> GetCommandByIdAsync(int id);

        Task CreateCommandAsync(Command command);

        Task UpdateCommandAsync(Command command);

        void DeleteCommand(Command command);
        
        Task<bool> SaveChangesAsync();
    }
}
