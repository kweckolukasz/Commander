using Commander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepo
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
            var commands = new List<Command>
            {
                 new Command { Id = 0, HowTo = "Do It!", Line = "Now", Platform = "kitchen" },
                 new Command { Id = 1, HowTo = "Dont Do It!", Line = "never", Platform = "Living room" },
                 new Command { Id = 2, HowTo = "Maybe", Line = "later", Platform = "Batchroom" }
            };
            return commands;
        }

        public Command GetCommandById(int Id)
        {
            return new Command { Id = 0, HowTo = "Do It!", Line = "Now", Platform = "kitchen" };
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
