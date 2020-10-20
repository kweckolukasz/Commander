using AutoMapper;
using Commander.Data;
using Commander.DTOs;
using Commander.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commander.TEST
{
    class Arrange
    {

        private Mock<ICommanderRepo> _repo;
        private IMapper _mapper;

        public Arrange()
        {
            _repo = configMock();
            _mapper = configMapper();
        }


        private Mock<ICommanderRepo> configMock()
        {
            _repo = new Mock<ICommanderRepo>();
            _repo.Setup(repo => repo.GetCommandById(It.IsAny<int>())).Returns((int Id) => commands.Where(command => command.Id == Id).Single());
            _repo.Setup(repo => repo.GetAllCommands()).Returns(commands);
            return _repo;
        }

        //Arrange Commands list
        private Command[] commands = new Command[] {
            new Command {Id = 0, HowTo = "ZeroHowTo", Line = "ZeroLine", Platform = "TestPlatform1"},
            new Command {Id = 1, HowTo = "FirstHowTo", Line = "FirstLine", Platform = "TestPlatform1"},
            new Command { Id = 2, HowTo = "SecondHowTo", Line = "SecondLine", Platform = "TestPlatform2" },
            new Command { Id = 3, HowTo = "ThirdHowTo", Line = "ThirdLine", Platform = "TestPlatform2" }
            };

        //Arrange Mapper
        private Mapper configMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CommandReadDTO, Command>();
                cfg.CreateMap<Command, CommandReadDTO>();
            });
            return (Mapper)config.CreateMapper();
        }

        public Mock<ICommanderRepo> getRepo()
        {
            return _repo;
        }

        public IMapper getMapper()
        {
            return _mapper;
        }

        public Command[] getCommands()
        {
            return commands;
        }
    }
}
