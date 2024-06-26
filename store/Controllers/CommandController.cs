﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using store.Dtos.Request;
using store.Dtos.Responce;
using store.Models;
using store.Services.Contract;
using store.Services.Implementation;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly ICommandService _commandService;
        private readonly IMapper _mapper;

        public CommandController(ICommandService CommandService, IMapper mapper)
        {
            _commandService = CommandService;
            _mapper = mapper;
        }
        [HttpPost("command")]
        public async Task<ActionResult<IEnumerable<CommandResponseDto>>> GetCommands([FromBody] JsonElement data)
        {
            try
            {
              //  var connectionString = $"Data Source=.\\SQLEXPRESS;Initial Catalog={data.ConnectionString};Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=true;";

              //  var commands = await _commandService.GetAllCommand();
              //  var commandDtos = _mapper.Map<IEnumerable<CommandResponseDto>>(commands);
                //var options = new JsonSerializerOptions
                //{
                //   ReferenceHandler = ReferenceHandler.Preserve
                //};
                //var json = JsonSerializer.Serialize(commandDtos, options);
                //
                //return Ok(commandDtos);
             //   return Ok(connectionString);
                if (data.TryGetProperty("ConnectionString", out JsonElement connectionStringElement))
                {
                    string connectionString = connectionStringElement.GetString();
                     var connectionString2 = $"Data Source=.\\SQLEXPRESS;Initial Catalog={connectionString};Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=true;";
                    var commands = await _commandService.GetAllCommand(connectionString2);
                     var commandDtos = _mapper.Map<IEnumerable<CommandResponseDto>>(commands);
                    return Ok(commandDtos);


                    // Process the connectionString as needed
                    // return Ok(new { message = "Received connection string", connectionString });
                }
                else
                {
                    return BadRequest(new { message = "ConnectionString property is missing" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving commands");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommandResponseDto>> GetCommand(int id)
        {
            //var options = new JsonSerializerOptions
            //{
              //  ReferenceHandler = ReferenceHandler.Preserve
            //};
            var command = await _commandService.GetCommandById(id);
            if (command == null)
            {
                return NotFound();
            }

            var commandDto = _mapper.Map<CommandResponseDto>(command);
            //var json = JsonSerializer.Serialize(commandDto, options);
            return Ok(commandDto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCommand(CommandRequestDto requestDto)
        {
            try
            {
                var command = _mapper.Map<Command>(requestDto);
                await _commandService.AddCommand(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating Command");
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCommande(int id)
        {

            var commande = _mapper.Map<CommandResponseDto>(await _commandService.GetCommandById(id));
            if (commande == null)
            {
                return NotFound();
            }
            await _commandService.DeleteCommand(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AnnulerCommande(int id)
        {
                var result = await _commandService.AnnulerCommande(id);

                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
        }
        [HttpGet("client/{clientId}")]
        public async Task<ActionResult<IEnumerable<CommandResponseDto>>> GetCommandsByClient(int clientId)
        {
            try
            {
                var commands = await _commandService.GetCommandsByClient(clientId);
                var commandDtos = _mapper.Map<IEnumerable<CommandResponseDto>>(commands);
                return Ok(commandDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving commands for client");
            }
        }
        [HttpGet("{id}/total")]
        public async Task<ActionResult<double>> GetCommandTotal(int id)
        {
            try
            {
                var total = await _commandService.CalculerTotalCommande(id);
                return Ok(total);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error calculating total");
            }
        }

    }
}
