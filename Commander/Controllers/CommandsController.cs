using AutoMapper;
using Commander.Data;
using Commander.DTOs;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Controllers
{

    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {

        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commandItems));
        }

        [HttpGet("{Id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDTO> GetCommandById(int Id)
        {
            var commandItem = _repository.GetCommandById(Id);
            if (commandItem != null)
            {
                return Ok(_mapper.Map<CommandReadDTO>(commandItem));
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<CommandReadDTO> CreateCommand(CommandCreateUpdateDTO commandCreateDTO)
        {
            var command = _mapper.Map<Command>(commandCreateDTO);
            _repository.CreateCommand(command);
            _repository.SaveChanges();
            var commandReadDTO = _mapper.Map<CommandReadDTO>(command);
            return CreatedAtRoute(nameof(GetCommandById), new { commandReadDTO.Id }, commandReadDTO);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandCreateUpdateDTO commandCreateUpdateDTO)
        {
            var command = _repository.GetCommandById(id);
            if (command == null)
            {
                return NotFound();
            }
            _mapper.Map(commandCreateUpdateDTO, command);
            _repository.UpdateCommand(command);
            _repository.SaveChanges();
            return NoContent();

        }

        [HttpPatch("{id}")]
        public ActionResult PartialUpdateCommand(int id, JsonPatchDocument<CommandCreateUpdateDTO> patchDocument)
        {
            var command = _repository.GetCommandById(id);
            if (command == null)
            {
                return NotFound();
            }
            var commandToPatch = _mapper.Map<CommandCreateUpdateDTO>(command);
            patchDocument.ApplyTo(commandToPatch, ModelState);
            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(commandToPatch, command);
            _repository.UpdateCommand(command);
            _repository.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var command = _repository.GetCommandById(id);
            if (command == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(command);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}
