using AutoMapper;
using CommandLine.Api.Dtos;
using CommandLine.Api.Models;

namespace CommandLine.Api.Profiles
{
    public class CommandProfiles : Profile
    {
        public CommandProfiles()
        {
            CreateMap<CommandCreateDto, Command>();

            CreateMap<Command, CommandReadDto>();

            CreateMap<CommandUpdateDto, Command>();
        }
    }
}
