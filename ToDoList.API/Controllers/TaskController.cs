using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.DataAccess.IRepository;
using ToDoList.Models;
using ToDoList.Models.DTO;

namespace ToDoList.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TaskController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateTakToToDoList(TaskDTO taskDTO)
        {
            try
            {
                var mappedTask = mapper.Map<Tasks>(taskDTO);
                var tasks = await unitOfWork.Task.Create(mappedTask);
            
                return CreatedAtAction("GetTaskById", new { id = tasks.Id }, tasks);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetTaskByToDoListById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetTaskByToDoListById(int id)
        {
            try
            {
                var users = await unitOfWork.ToDoList.GetById(u=>u.);
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetTaskById(int id)
        {
            try
            {
                var user = await unitOfWork.Task.GetById(u => u.Id == id);

                if (user == null)
                {
                    return NoContent();
                }
                return Ok(user);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateTaskStatus(int id, TaskDTO taskDTO)
        {
            try
            {
                var mappedUser = mapper.Map<Tasks>(taskDTO);
                mappedUser.Id = id;
                var user = await unitOfWork.Task.Update(mappedUser);
                return Ok(user);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await unitOfWork.User.GetById(u => u.Id == id);

                if (user == null)
                {
                    return NoContent();
                }

                var droppedUser = await unitOfWork.User.Delete(user);
                return Ok(droppedUser);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
