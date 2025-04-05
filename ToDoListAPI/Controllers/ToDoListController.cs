using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Services;
using ToDoListAPI.DTOs;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly ToDoListService _toDoListService;

        public ToDoListController(ToDoListService toDoListService)
        {
            _toDoListService = toDoListService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoListDTO>>> GetAllToDoLists()
        {
            var toDoLists = await _toDoListService.GetAllToDoLists();
            return Ok(toDoLists);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoListDTO>> GetToDoListById(int id)
        {
            var toDoList = await _toDoListService.GetToDoListById(id);

            if (toDoList == null)
            {
                return NotFound();
            }

            return Ok(toDoList);
        }

        [HttpPost]
        public async Task<ActionResult<ToDoListDTO>> CreateToDoList(ToDoListDTO toDoListDTO)
        {
            var createdToDoList = await _toDoListService.CreateToDoList(toDoListDTO);

            return CreatedAtAction(nameof(GetToDoListById), new { id = createdToDoList.ID },
                new { message = $"The task with ID {createdToDoList.ID} has been created successfully." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateToDoList(int id, ToDoListDTO toDoListDTO)
        {
            var toDoList = await _toDoListService.GetToDoListById(id);

            if (toDoList == null)
            {
                return NotFound(new { message = $"No task found with ID {id} to update." });
            }

            if (id != toDoListDTO.ID)
            {
                return BadRequest(new { message = "The provided ID does not match the ID of the task." });
            }

            var success = await _toDoListService.UpdateToDoList(id, toDoListDTO);

            if (!success)
            {
                return NotFound( new { message = $"The task with ID {id} could not be updated." });
            }

            return Ok(new { message = $"The record with ID {id} has been updated successfully." });

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoList(int id)
        {
            var success = await _toDoListService.DeleteToDoList(id);

            if (!success)
            {
                return NotFound(new { message = "The provided ID does not match the ID of the task." });
            }

            return Ok(new { message = $"The record with ID {id} has been deleted successfully." });
        }
    }
}
