using System;
using Xunit;
using Commander.Controllers;
using Commander.TEST.MockData;
using Commander.Data;
using AutoMapper;
using Commander.Models;
using Commander.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Commander.TEST
{
    public class UnitTest1
    {
        public UnitTest1()
        {
            arrange = new Arrange();
            _repo = arrange.getRepo();
            _mapper = arrange.getMapper();
            commands = arrange.getCommands();
        }

        //Arrange Mock _repo
        Arrange arrange;
        private static Mock<ICommanderRepo> _repo;
        private static IMapper _mapper;
        private Command[] commands;


        [Fact]
        public void Test1()
        {
            CommandsController controller = new CommandsController(_repo.Object, _mapper);
            //Act
            var ar = controller.GetCommandById(0).Result as OkObjectResult;
            CommandReadDTO commandDTOFromController =(CommandReadDTO) ar.Value;
            Command commandFromController = _mapper.Map<Command>(commandDTOFromController);
            Command commandFromArray = commands.FirstOrDefault(a => a.Id == 0);
            var commandFromControllerDeserialized = JsonConvert.SerializeObject(commandFromController);
            var commandFromArrayDeserialized = JsonConvert.SerializeObject(commandFromArray);

            //Assert
            Assert.Equal(commandFromControllerDeserialized, commandFromArrayDeserialized);
        }
    }
}

