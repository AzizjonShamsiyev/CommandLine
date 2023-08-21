using AutoMapper;
using CommandLine.Api.Data;
using CommandLine.Api.Dtos;
using CommandLine.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommandLine.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandAPIRepo repository;
        private readonly IMapper mapper;

        public CommandsController(ICommandAPIRepo repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = mapper.Map<Command>(commandCreateDto);

            await repository.CreateCommandAsync(commandModel);

            await repository.SaveChangesAsync();

            var commandReadDto = mapper.Map<CommandReadDto>(commandModel);
            
            return Created("", commandModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetCommands()
        {
            var commands = await repository.GetAllCommandsAsync();

            return Ok(mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommandById(int id)
        {
            var command = await repository.GetCommandByIdAsync(id);

            if(command == null) 
                return NotFound();

            return Ok(mapper.Map<CommandReadDto>(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommand(int id)
        {
            var commandModelFromRepo = await repository.GetCommandByIdAsync(id);

            if (commandModelFromRepo == null)
                return NotFound();

            repository.DeleteCommand(commandModelFromRepo);

            await repository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCommand(int id, CommandUpdateDto updateDto)
        {
            var commandModelFromRepo = await repository.GetCommandByIdAsync(id);

            if(commandModelFromRepo == null)
                return NotFound();

            mapper.Map(updateDto, commandModelFromRepo);

            await repository.UpdateCommandAsync(commandModelFromRepo);

            await repository.SaveChangesAsync();

            return NoContent();
        }
    }
}
