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
    public class ToDoListController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ToDoListController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateToDoListforUser(ToDoListDTO toDoListDTO)
        {
            try
            {
                var mappedToDoList = mapper.Map<ToDoLists>(toDoListDTO);
                var todolist = await unitOfWork.ToDoList.Create(mappedToDoList);

                UserToDoList userToDoList = new()
                {
                    UserId = toDoListDTO.UserId,
                    ToDoListId = todolist.Id
                };

                await unitOfWork.UserToDoList.Create(userToDoList);
                return CreatedAtAction("GetToDoListById", new { id = todolist.Id }, todolist);
                

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetAllToDoLists()
        {
            try
            {
                var toDoLists = await unitOfWork.ToDoList.GetAll();
                return Ok(toDoLists);
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
        public async Task<ActionResult> GetToDoListById(int id)
        {
            try
            {
                var toDoList = await unitOfWork.ToDoList.GetById(u => u.Id == id);

                if (toDoList == null)
                {
                    return NoContent();
                }
                return Ok(toDoList);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetToDoListByUserId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetToDoListByUserId(int id)
        {
            try
            {
                string[] includeProperties = { "User", "ToDoList" };
               var toDoList = await unitOfWork.UserToDoList.GetById(u=>u.UserId== id);

                if(toDoList == null)
                {
                    return NoContent();
                }
                return Ok(toDoList);

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
        public async Task<ActionResult> DeleteToDoList(int id)
        {
            try
            {
                var list = await unitOfWork.ToDoList.GetById(u => u.Id == id);

                if (list == null)
                {
                    return NoContent();
                }

                var droppedUser = await unitOfWork.ToDoList.Delete(list);
                return Ok(droppedUser);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
