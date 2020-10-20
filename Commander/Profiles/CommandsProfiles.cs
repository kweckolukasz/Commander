using AutoMapper;
using Commander.DTOs;
using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Profiles
{
    public class CommandsProfiles : Profile
    {
        public CommandsProfiles()
        {
            CreateMap<Command, CommandReadDTO>();
            CreateMap<CommandCreateUpdateDTO, Command>();
            CreateMap<Command, CommandCreateUpdateDTO>();
        }

    }
}
