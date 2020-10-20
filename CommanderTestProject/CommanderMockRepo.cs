using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Commander.TEST.MockData
{
    class CommanderMockRepo : ICommanderRepo
    {
        public void CreateCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public void DeleteCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return new List<Command> {
            new Command {Id = 0, HowTo = "ZeroHowTo", Line = "ZeroLine", Platform = "TestPlatform1"},
            new Command {Id = 1, HowTo = "FirstHowTo", Line = "FirstLine", Platform = "TestPlatform1"},
            new Command {Id = 2, HowTo = "SecondHowTo", Line = "SecondLine", Platform = "TestPlatform2"},
            new Command {Id = 3, HowTo = "ThirdHowTo", Line = "ThirdLine", Platform = "TestPlatform2"}
            };

        }

        public Command GetCommandById(int Id)
        {
            return new Command { Id = 0, HowTo = "ZeroHowTo", Line = "ZeroLine", Platform = "TestPlatform1" };
            
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateCommand(Command command)
        {
            throw new NotImplementedException();
        }
    }
}
